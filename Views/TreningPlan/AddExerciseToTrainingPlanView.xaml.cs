using KCK_Project__Console_Pocket_trainer_.Models;
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
    /// Interaction logic for AddExerciseToTrainingPlanView.xaml
    /// </summary>
    public partial class AddExerciseToTrainingPlanView : UserControl
    {
        private AddExerciseToTrainingPlanViewModel _viewModel;
        public AddExerciseToTrainingPlanView(Exercise exercise, TrainingPlan trainingPlan)
        {
            InitializeComponent();
            _viewModel = new AddExerciseToTrainingPlanViewModel
            {
                Exercise = exercise,
                TrainingPlan = trainingPlan
            };
            DataContext = _viewModel;
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

                repsList.Add(repsTextBox.Text);
                weightList.Add(weightTextBox.Text);
            }

            var exerciseToTrainingPlan = new ExerciseToTrainingPlan
            {
                ExerciseId = _viewModel.Exercise.Id,
                TrainingPlanId = _viewModel.TrainingPlan.Id,
                Sets = SetsPanel.Children.Count,
                Reps = string.Join(",", repsList),
                Weight = string.Join(",", weightList)
            };

            // Add logic to save exerciseToTrainingPlan to the database or training plan

            MessageBox.Show("Exercise added to training plan!");
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is DashboardView mainWindow)
            {
                mainWindow.ChangeView(new ExercisesView());
            }
        }
    }
}
