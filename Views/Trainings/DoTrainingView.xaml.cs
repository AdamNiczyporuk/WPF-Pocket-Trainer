using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using KCK_Project__Console_Pocket_trainer_.ViewModels;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Pocket_Trainer.Views.Trainings
{
    public partial class DoTrainingView : UserControl, INotifyPropertyChanged
    {
        private TrainingPlan _trainingPlan;
        public TrainingPlan TrainingPlan
        {
            get => _trainingPlan;
            set
            {
                _trainingPlan = value;
                OnPropertyChanged(nameof(TrainingPlan));
            }
        }

        private readonly Training _training;
        private readonly ExerciseRepository _exerciseRepository;
        private readonly ExerciseDoneRepository _exerciseDoneRepository;
        public List<ExerciseWithSets> ExercisesToDo { get; set; }
        public List<ExerciseWithSets> DoneExercises { get; set; }

        public DoTrainingView(TrainingPlan trainingPlan, Training training)
        {
            var context = new ApplicationDbContext();
            _exerciseRepository = new ExerciseRepository(context);
            _exerciseDoneRepository = new ExerciseDoneRepository(context);
            TrainingPlan = trainingPlan;
            _training = training;
            InitializeComponent();
            LoadExercises();
            DataContext = this;
        }

        public void LoadExercises()
        {
            var trainingPlanExercises = _exerciseRepository.GetExercisesByTrainingPlan(TrainingPlan.Id);
            var doneExercises = _exerciseDoneRepository.GetExercisesDoneByTraining(_training.Id);
            var exercisesToDo = trainingPlanExercises.Except(doneExercises, new ExerciseComparer()).ToList();
            ExercisesToDo = exercisesToDo;
            DoneExercises = doneExercises;
        }

        public void DoExercise_Click(object sender, RoutedEventArgs e)
        {
            var exercise = (sender as Button).DataContext as ExerciseWithSets;
            if (Window.GetWindow(this) is DashboardView mainWindow)
            {
                mainWindow.ChangeView(new DoExercise(_training, exercise));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void FinishTraining_Click(object sender, RoutedEventArgs e)
        {
            _training.EndTime = DateTime.Now;
            var context = new ApplicationDbContext();
            var trainingRepository = new TrainingRepository(context);
            if (trainingRepository.Update(_training))
            {
                MessageBox.Show("Training finished!");
                if (Window.GetWindow(this) is DashboardView mainWindow)
                {
                    mainWindow.ChangeView(new TrainingsView());
                }
            }
            else
            {
                MessageBox.Show("Error while finishing training!");
            }
          
        }
    }

    public class ExerciseComparer : IEqualityComparer<ExerciseWithSets>
    {
        public bool Equals(ExerciseWithSets x, ExerciseWithSets y)
        {
            if (x == null || y == null)
                return false;
            return x.Id == y.Id;
        }

        public int GetHashCode(ExerciseWithSets obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}