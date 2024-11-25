using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Interfaces;
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
using WPF_Pocket_Trainer.ViewModels;

namespace WPF_Pocket_Trainer.Views.TreningPlan
{
    /// <summary>
    /// Interaction logic for ManageTrainingPlanExercises.xaml
    /// </summary>
    public partial class ManageTrainingPlanExercises : UserControl
    {
        private readonly ExerciseRepository _exerciseRepository;
        private List<Exercise> _allExercises;
        private ManageTrainingPlanExercisesViewModel _viewModel;
        private ExerciseToTrainingPlanRepository _exerciseToTrainingPlanRepository;


        public ManageTrainingPlanExercises(TrainingPlan trainingPlan)
        {
            InitializeComponent();
            
            _exerciseRepository = new ExerciseRepository(new ApplicationDbContext());
            _exerciseToTrainingPlanRepository = new ExerciseToTrainingPlanRepository(new ApplicationDbContext() );
            LoadData(trainingPlan);
        }
        private void Refresh()
        {
            if (Window.GetWindow(this) is DashboardView mainWindow)
            {
                mainWindow.ChangeView(new ManageTrainingPlanExercises(_viewModel.TrainingPlan));
            }
        }

        private void LoadData(TrainingPlan trainingPlan)
        {
            var trainingPlanExercises = _exerciseRepository.GetExercisesByTrainingPlan(trainingPlan.Id);
            _allExercises = _exerciseRepository.GetAllExercises();
            var availableExercises = _allExercises.Where(e => !trainingPlanExercises.Any(te => te.Id == e.Id)).ToList();

            var viewModel = new ManageTrainingPlanExercisesViewModel(trainingPlan, trainingPlanExercises, availableExercises);
            AvailableExercisesListBox.ItemsSource = _allExercises;
            _viewModel = viewModel;
            DataContext = viewModel;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchTextBox.Text.ToLower();
            var filteredExercises = _allExercises.Where(ex => ex.Name.ToLower().Contains(searchText)).ToList();
            AvailableExercisesListBox.ItemsSource = filteredExercises;
        }
        private void AddExercise_Click(object sender, RoutedEventArgs e)
        {

            if (sender is Button button && button.CommandParameter is Exercise exercise)
            {
                if (Window.GetWindow(this) is DashboardView mainWindow)
                {
                    mainWindow.ChangeView(new AddExerciseToTrainingPlanView(exercise, _viewModel.TrainingPlan));
                }

            }
        }
        private void RemoveExercise_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var exerciseWithSets = button.CommandParameter as ExerciseWithSets;
           

            var result = MessageBox.Show($"Are you sure you want to delete this exercise from your training plan?",
                                         "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                bool isDeleted = _exerciseToTrainingPlanRepository.Delete( _viewModel.TrainingPlan.Id,exerciseWithSets.Id);
                if (isDeleted)
                {

                    MessageBox.Show("Exercise deleted successfully!");
                    Refresh();
                }
                else
                {
                    MessageBox.Show("Failed to delete exercise. Please try again.");
                }
            }
        }
    }
}
