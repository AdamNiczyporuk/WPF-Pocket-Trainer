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
using KCK_Project__Console_Pocket_trainer_.Repositories;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Data;
using WPF_Pocket_Trainer.Models;
using KCK_Project__Console_Pocket_trainer_.Interfaces;
using WPF_Pocket_Trainer.Views.TreningPlan;

namespace WPF_Pocket_Trainer.Views
{
    /// <summary>
    /// Interaction logic for TrainingPlans.xaml
    /// </summary>
    public partial class TrainingPlans : UserControl
    {
        private readonly TrainingPlanRepository _trainingPlanRepository;
        public List<TrainingPlan> UserTrainingPlans { get; set; }
        public TrainingPlan SelectedTrainingPlan { get; set; }

        public TrainingPlans()
        {
            InitializeComponent();
            _trainingPlanRepository = new TrainingPlanRepository(new ApplicationDbContext());
            LoadTrainingPlans();
        }

        private void LoadTrainingPlans()
        {

            int currentUserId = UserSession.CurrentUser.Id;
            UserTrainingPlans = _trainingPlanRepository.GetUserTrainingPlans(currentUserId);
            DataContext = this;
        }

        private void Refresh()
        {
            if (Window.GetWindow(this) is DashboardView mainWindow)
            {
                mainWindow.ChangeView(new TrainingPlans());
            }
        }

        private void AddNewTrainingPlan_Click(object sender, RoutedEventArgs e)
        {
            string planName = NewPlanName.Text.Trim();
            string planDescription = NewPlanDescription.Text.Trim();

            if (string.IsNullOrEmpty(planName) || string.IsNullOrEmpty(planDescription))
            {
                MessageBox.Show("Please enter a name and description for the Training plan");
                return;
            }

            var trainingPlan = new TrainingPlan
            {
                UserId = UserSession.CurrentUser.Id,
                Name = planName,
                Description = planDescription,
                CreatedAt = DateTime.Now
            };

            bool isAdded = _trainingPlanRepository.Add(trainingPlan);
            if (isAdded)
            {

                MessageBox.Show("Training plan added successfully!");
                Refresh();
            }
            else
            {
                MessageBox.Show("Failed to add Training plan. Please try again.");
            }
        }


        private void EditTrainingPlan_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is TrainingPlan trainingPlan)
            {
                if (Window.GetWindow(this) is DashboardView mainWindow)
                {
                    mainWindow.ChangeView(new EditTrainingPlan(trainingPlan));
                }
            }
        }
        private void DeleteTrainingPlan_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is TrainingPlan trainingPlan)
            {
                var result = MessageBox.Show($"Are you sure you want to delete the Training plan '{trainingPlan.Name}'?",
                                             "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    bool isDeleted = _trainingPlanRepository.Delete(trainingPlan);
                    if (isDeleted)
                    {
                       
                        MessageBox.Show("Training plan deleted successfully!");
                        Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete Training plan. Please try again.");
                    }
                }
            }
        }

        private void ManageExercises_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is TrainingPlan trainingPlan)
            {
                if (Window.GetWindow(this) is DashboardView mainWindow)
                {
                    mainWindow.ChangeView(new ManageTrainingPlanExercises(trainingPlan));
                }
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

            if (Window.GetWindow(this) is DashboardView mainWindow)
            {
                mainWindow.ChangeView(new TrainingsView());
            }

        }
    }
}
