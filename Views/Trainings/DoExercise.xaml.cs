using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using KCK_Project__Console_Pocket_trainer_.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Pocket_Trainer.Models;
using WPF_Pocket_Trainer.Views.TreningPlan;

namespace WPF_Pocket_Trainer.Views.Trainings
{
    /// <summary>
    /// Interaction logic for DoExercise.xaml
    /// </summary>
    public partial class DoExercise : UserControl, INotifyPropertyChanged
    {
        private ExerciseWithSets _exercise;
        public ExerciseWithSets Exercise
        {
            get => _exercise;
            set
            {
                _exercise = value;
                OnPropertyChanged(nameof(Exercise));
            }
        }

        private readonly Training _training;

        public DoExercise(Training training, ExerciseWithSets exerciseToDo)
        {
            _exercise = exerciseToDo;
            _training = training;
            InitializeComponent();
            DataContext = this;
        }

        private void SetsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetsPanel.Children.Clear();
            int numberOfSets = int.Parse((SetsComboBox.SelectedItem as ComboBoxItem).Content.ToString());

            for (int i = 1; i <= numberOfSets; i++)
            {
                var setPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 5) };

                var repsLabel = new TextBlock { Text = $"Set {i} Reps:", Foreground = Brushes.White, Width = 80, VerticalAlignment = VerticalAlignment.Center };
                var repsTextBox = new TextBox { Width = 50, Margin = new Thickness(5, 0, 10, 0), Background = new SolidColorBrush(Color.FromRgb(44, 47, 48)), Foreground = Brushes.White, BorderBrush = new SolidColorBrush(Color.FromRgb(76, 79, 80)) };

                var weightLabel = new TextBlock { Text = "Weight:", Foreground = Brushes.White, Width = 50, VerticalAlignment = VerticalAlignment.Center };
                var weightTextBox = new TextBox { Width = 50, Margin = new Thickness(5, 0, 10, 0), Background = new SolidColorBrush(Color.FromRgb(44, 47, 48)), Foreground = Brushes.White, BorderBrush = new SolidColorBrush(Color.FromRgb(76, 79, 80)) };

                setPanel.Children.Add(repsLabel);
                setPanel.Children.Add(repsTextBox);
                setPanel.Children.Add(weightLabel);
                setPanel.Children.Add(weightTextBox);

                SetsPanel.Children.Add(setPanel);
            }
        }

        private void AddExerciseButton_Click(object sender, RoutedEventArgs e)
        {
            var repsList = new List<string>();
            var weightList = new List<string>();

            foreach (StackPanel setPanel in SetsPanel.Children)
            {
                var repsTextBox = setPanel.Children[1] as TextBox;
                var weightTextBox = setPanel.Children[3] as TextBox;

                if (string.IsNullOrWhiteSpace(repsTextBox.Text) || !int.TryParse(repsTextBox.Text, out int reps) || reps <= 0 || reps >= 100)
                {
                    MessageBox.Show($"Please enter a valid number of reps (1-99) for set {SetsPanel.Children.IndexOf(setPanel) + 1}.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(weightTextBox.Text) || !int.TryParse(weightTextBox.Text, out int weight) || weight <= 0 || weight >= 500)
                {
                    MessageBox.Show($"Please enter a valid weight (1-499) for set {SetsPanel.Children.IndexOf(setPanel) + 1}.");
                    return;
                }

                repsList.Add(repsTextBox.Text);
                weightList.Add(weightTextBox.Text);
            }
            if(repsList.Count==0)
            {
                MessageBox.Show($"You need to do at least one set of exercise to finish it");
                return;
            }

            var exerciseDone = new ExerciseDone
            {
                ExerciseId = _exercise.Id,
                TrainingId = _training.Id,
                UserId = UserSession.CurrentUser.Id,
                Reps = string.Join(",", repsList),
                Weight = string.Join(",", weightList),
                Sets = repsList.Count
            };
            var context = new ApplicationDbContext();
            var exerciseDoneRepository = new ExerciseDoneRepository(context);
            var trainingPlanRepository = new TrainingPlanRepository(context);
            if (exerciseDoneRepository.Add(exerciseDone))
            {
                var trainingPlan = trainingPlanRepository.GetTrainingPlanById(_training.TreningPlanId);
                MessageBox.Show("Exercise finished!");
                if (Window.GetWindow(this) is DashboardView mainWindow)
                {
                    mainWindow.ChangeView(new DoTrainingView(trainingPlan, _training));
                }
            }
            else
            {
                MessageBox.Show("Error while adding exercise to Training plan!");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var context = new ApplicationDbContext();

            var trainingPlanRepository = new TrainingPlanRepository(context);

            var trainingPlan = trainingPlanRepository.GetTrainingPlanById(_training.TreningPlanId);

            if (Window.GetWindow(this) is DashboardView mainWindow)
            {
                mainWindow.ChangeView(new DoTrainingView(trainingPlan, _training));
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
