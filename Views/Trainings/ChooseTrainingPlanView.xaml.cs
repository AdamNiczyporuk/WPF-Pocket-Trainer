using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WPF_Pocket_Trainer.Models;
using WPF_Pocket_Trainer.ViewModels;

namespace WPF_Pocket_Trainer.Views.Trainings
{
    public partial class ChooseTrainingPlanView : UserControl
    {
        private readonly TrainingPlanRepository _trainingPlanRepository;
        private readonly ExerciseToTrainingPlanRepository _exerciseToTrainingPlanRepository;
        private List<ChooseTrainingPlanViewModel> ViewModel { get; set; }

        public ChooseTrainingPlanView()
        {
            _trainingPlanRepository = new TrainingPlanRepository(new ApplicationDbContext());
            _exerciseToTrainingPlanRepository = new ExerciseToTrainingPlanRepository(new ApplicationDbContext());
            ViewModel = new List<ChooseTrainingPlanViewModel>();
            var trainingPlans = _trainingPlanRepository.GetUserTrainingPlans(UserSession.CurrentUser.Id);
            foreach (var trainingPlan in trainingPlans)
            {
                ViewModel.Add(new ChooseTrainingPlanViewModel(trainingPlan));
            }
            InitializeComponent();

            TrainingPlansDataGrid.ItemsSource = ViewModel;
            DataContext = this; // Ustawienie DataContext na bieżący obiekt
            
        }

        public void StartTraining_Click(object sender, RoutedEventArgs e)
        {
            //todo
        }
    }
}