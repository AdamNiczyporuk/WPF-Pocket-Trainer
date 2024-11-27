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
using WPF_Pocket_Trainer.Views.Trainings;

namespace WPF_Pocket_Trainer.Views
{
    /// <summary>
    /// Interaction logic for TrainingsView.xaml
    /// </summary>
    public partial class TrainingsView : UserControl
    {
        public TrainingsView()
        {
            InitializeComponent();
        }
        private void NavigateToExercises(object sender, RoutedEventArgs e)
        {

            if (Window.GetWindow(this) is DashboardView mainWindow)
            {
                mainWindow.ChangeView(new ExercisesView());
            }
        }

 

        private void NavigateToTrainingPlans(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is DashboardView mainWindow)
            {
                mainWindow.ChangeView(new TrainingPlans());
            }
        }

        private void NavigateToTrainings(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is DashboardView mainWindow)
            {
                mainWindow.ChangeView(new ChooseTrainingPlanView(false));
            }
        }

        private void NavigateToStatistics(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is DashboardView mainWindow)
            {
                mainWindow.ChangeView(new ChooseTrainingPlanView(true));
            }
        }
    }
}
