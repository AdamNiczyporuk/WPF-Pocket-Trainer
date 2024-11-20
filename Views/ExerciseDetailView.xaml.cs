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
using KCK_Project__Console_Pocket_trainer_.Data;
namespace WPF_Pocket_Trainer.Views
{
    /// <summary>
    /// Interaction logic for ExerciseDetailView.xaml
    /// </summary>
    public partial class ExerciseDetailView : UserControl
    {
        public ExerciseDetailView(Exercise exercise)
        {
            InitializeComponent();
            DataContext = exercise;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Logika powrotu do listy ćwiczeń, np. zmiana widoku
        }
    }
}
