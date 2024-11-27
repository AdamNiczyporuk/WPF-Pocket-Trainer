using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using KCK_Project__Console_Pocket_trainer_.ViewModels;
using System;
using System.Collections.Generic;
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

namespace WPF_Pocket_Trainer.Views.Trainings
{
    /// <summary>
    /// Interaction logic for DoTrainingView.xaml
    /// </summary>
    public partial class DoTrainingView : UserControl
    {
        private readonly TrainingPlan TrainingPlan;
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
