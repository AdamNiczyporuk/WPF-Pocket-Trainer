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

namespace WPF_Pocket_Trainer.Views
{
    /// <summary>
    /// Interaction logic for LogIN.xaml
    /// </summary>
    public partial class LogIN : Page
    {
        private readonly LogINController _loginController;
        public LogIN()
        {
            InitializeComponent();
            _loginController = new LogINController();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Prosta weryfikacja
            if (_loginController.ValidateData(username, password))
            {
                _loginController.ShowSuccessMessage();
                DashboardView dashboardView = new DashboardView();
                dashboardView.Show();

                // Close the current SignIN page's window
                Window.GetWindow(this).Close();
            }
            else
            {
             _loginController.ShowErrorMessage();
            }
        }
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignIN());
        }
    }
}
