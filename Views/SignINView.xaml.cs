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
using WPF_Pocket_Trainer.Controllers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WPF_Pocket_Trainer.Views
{
    /// <summary>
    /// Interaction logic for SignIN.xaml
    /// </summary>
    public partial class SignIN : Page
    {
        private readonly SignINController _SignINController;
        public SignIN()
        {
            InitializeComponent();
            _SignINController = new SignINController();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LogIN());
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
           
            if (_SignINController.ValidateData(UsernameTextBox.Text, PasswordBox.Password))
            {

                _SignINController.ShowMessage("User created successfully!");

                // Open DashboardView window
                DashboardView dashboardView = new DashboardView();
                dashboardView.Show();

                // Close the current SignIN page's window
                Window.GetWindow(this).Close();
            }
            else
            {
                _SignINController.ShowMessage("User already exists if it's you please login\nor try other username.");
            }
           
        }
    }
}
