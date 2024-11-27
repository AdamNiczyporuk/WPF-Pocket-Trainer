using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using KCK_Project__Console_Pocket_trainer_.Services;
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using WPF_Pocket_Trainer.Views.Trainings;

namespace WPF_Pocket_Trainer.Views.Statistics
{
    public partial class StatisticsView : UserControl
    {
        public StatisticsView(TrainingPlan trainingPlan)
        {
            InitializeComponent();
            DataContext = new StatisticsViewModel(trainingPlan);
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
           

            if (Window.GetWindow(this) is DashboardView mainWindow)
            {
                mainWindow.ChangeView(new TrainingsView());
            }

        }
    }

    public class StatisticsViewModel : INotifyPropertyChanged
    {
        private SeriesCollection _seriesCollection;
        public string Name { get; set; }
        public SeriesCollection SeriesCollection
        {
            get => _seriesCollection;
            set
            {
                _seriesCollection = value;
                OnPropertyChanged();
            }
        }

        private List<string> _labels;
        public List<string> Labels
        {
            get => _labels;
            set
            {
                _labels = value;
                OnPropertyChanged();
            }
        }

        public StatisticsViewModel(TrainingPlan trainingPlan)
        {
            Name = trainingPlan.Name;
            LoadData(trainingPlan);
        }

        public void LoadData(TrainingPlan trainingPlan)
        {
            var context = new ApplicationDbContext();
            var trainingRepository = new TrainingRepository(context);
            var trainings = trainingRepository.GetTrainingsByTrainingPlan(trainingPlan.Id);
            trainings.RemoveAll(t => t.EndTime == null);
            List<int> volumes = new List<int>();
            foreach (var training in trainings)
            {
                volumes.Add(TrainingService.getVolume(training));
            }

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Training Volume",
                    Values = new ChartValues<int>(volumes)
                }
            };

            Labels = trainings.Select(t => t.StartTime.ToString("g")).ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
