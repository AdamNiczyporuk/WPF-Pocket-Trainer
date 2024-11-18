using KCK_Project__Console_Pocket_trainer_.Data;
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
        public ExercisesView()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            _exerciseRepository = new ExerciseRepository(_context);
            LoadMuscleGroups();
        }
        private void LoadMuscleGroups()
        {
            var muscleGroups = ExerciseMuscleList.exerciseMuscles;
            MusclesListBox.ItemsSource = muscleGroups;
        }
        private void MusclesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MusclesListBox.SelectedItem != null)
            {
                string selectedMuscle = MusclesListBox.SelectedItem.ToString();
                LoadExercises();
            }
        }
        private void LoadExercises()
        {
            var selectedMuscle = MusclesListBox.SelectedItem.ToString();
            var exercises = _exerciseRepository.GetExercisesByMuscle(selectedMuscle);
           ExercisesListBox.ItemsSource = exercises;
        }
    }
}
