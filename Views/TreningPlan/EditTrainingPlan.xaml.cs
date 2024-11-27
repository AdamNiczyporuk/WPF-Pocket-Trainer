using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using System.Windows;
using System.Windows.Controls;
using WPF_Pocket_Trainer.Models;

namespace WPF_Pocket_Trainer.Views
{
    /// <summary>
    /// Interaction logic for EditTrainingPlan.xaml
    /// </summary>
    public partial class EditTrainingPlan : UserControl
    {
        private TrainingPlan _trainingPlan;
        private readonly TrainingPlanRepository _trainingPlanRepository;
        public EditTrainingPlan(TrainingPlan trainingPlan)
        {
            InitializeComponent();
            _trainingPlan = trainingPlan;
            _trainingPlanRepository = new TrainingPlanRepository(new ApplicationDbContext());
            DataContext = _trainingPlan;
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            
           
            bool isUpdated = _trainingPlanRepository.Update(_trainingPlan);
            if (isUpdated)
            {
                
                MessageBox.Show("Training plan updated successfully!");
                if (Window.GetWindow(this) is DashboardView mainWindow)
                {
                    mainWindow.ChangeView(new TrainingPlans());
                }
            }
            else
            {
                MessageBox.Show("Failed to update Training plan. Please try again.");
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            // Return to the previous view
            if (Window.GetWindow(this) is DashboardView mainWindow)
            {
                mainWindow.ChangeView(new TrainingPlans());
            }
        }
    }
}