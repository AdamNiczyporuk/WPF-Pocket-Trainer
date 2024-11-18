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
using KCK_Project__Console_Pocket_trainer_.Models;
using WPF_Pocket_Trainer.Models;
using WpfAnimatedGif;


namespace WPF_Pocket_Trainer.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            this.DataContext = UserSession.CurrentUser;

            InitializeComponent();
            LoadGif();
            UpdateButtonState();



        }

        private void LoadGif()
        {
            var gifUri = new Uri("pack://application:,,,/Dashboard/Images/monkey.gif");
            var gifMonkey = new BitmapImage(gifUri);
            ImageBehavior.SetAnimatedSource(MonkeyGym, gifMonkey);
            var gif1Uri = new Uri("pack://application:,,,/Dashboard/Images/HevyWieght.gif");
            var gifHeavy = new BitmapImage(gif1Uri);
            ImageBehavior.SetAnimatedSource(HeavyGym, gifHeavy);
            ImageBehavior.SetAnimatedSource(HeavyGym, gifHeavy);
            ImageBehavior.SetRepeatBehavior(HeavyGym, System.Windows.Media.Animation.RepeatBehavior.Forever); 
        }
        private void UpdateButtonState()
        {
            if (UserSession.CurrentUser != null)
            {
                ActionButton.Content = "Update Data";
            }
            else
            {
                ActionButton.Content = "Add Data";
            }
        }
        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            // Obsługa kliknięcia przycisku
            if (UserSession.CurrentUser != null)
            {
                // Update danych użytkownika
                MessageBox.Show("Updating data...");
            }
            else
            {
                // Dodawanie danych użytkownika
                MessageBox.Show("Adding data...");
            }
        }



    }
}
