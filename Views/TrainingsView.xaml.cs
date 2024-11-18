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

            var dashboardView = Application.Current.MainWindow as DashboardView;
            if (dashboardView != null)
            {
                dashboardView.DataContext = new ExercisesView();
            }
            else
            {
                MessageBox.Show("DashboardView is null");
            }
        }

 

        private void NavigateToTrainingPlans(object sender, RoutedEventArgs e)
        {
            // Implement navigation to Training Plans
            MessageBox.Show("Navigating to Training Plans");
        }

        private void NavigateToTrainings(object sender, RoutedEventArgs e)
        {
            // Implement navigation to Trainings
            MessageBox.Show("Navigating to Trainings");
        }

        private void NavigateToStatistics(object sender, RoutedEventArgs e)
        {
            // Implement navigation to Statistics
            MessageBox.Show("Navigating to Statistics");
        }
    }
}
