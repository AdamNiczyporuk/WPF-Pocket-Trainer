using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Repositories;
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
using WPF_Pocket_Trainer.Data;

namespace WPF_Pocket_Trainer.Views
{
    /// <summary>
    /// Interaction logic for ExercisesView.xaml
    /// </summary>
    public partial class ExercisesView : UserControl
    {
        private ApplicationDbContext _context;
        private ExerciseRepository _exerciseRepository;
        private List<Exercise> _selectedExercise;
        public ExercisesView()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            _exerciseRepository = new ExerciseRepository(_context);
            _selectedExercise = LoadExercises();

        }
        private List<Exercise> LoadExercises()
        {
            var exercises = _exerciseRepository.GetAllExercises();
            ExercisesListBox.ItemsSource = exercises;
            return exercises;
        }
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();

            // Filtracja ćwiczeń
            var exercises = _exerciseRepository.GetExercisesByName(searchText.ToLower());

            // Odświeżenie listy ćwiczeń
            ExercisesListBox.ItemsSource = exercises;
        }
        private void ExercicseDetailView(object sender, RoutedEventArgs e)
        {
            if (ExercisesListBox.SelectedItem is Exercise selectedExercise)
            {
                if (Window.GetWindow(this) is DashboardView mainWindow)
                {
                    mainWindow.ChangeView(new ExerciseDetailView(selectedExercise));
                }
            }
        }
    }
}
