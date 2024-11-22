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
using System.Windows.Shapes;
using WPF_Pocket_Trainer.Controllers;

namespace WPF_Pocket_Trainer.Views
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class LogINView : Window
    {


        private readonly LogINController _loginController;
        public LogINView()
        {
            InitializeComponent();
            _loginController = new LogINController();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.ChangedButton == MouseButton.Left && e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        public void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Prosta weryfikacja
            if (_loginController.ValidateData(username, password))
            {
                DashboardView dashboardView = new DashboardView();
                dashboardView.Show();

                // Close the current SignIN page's window
                Window.GetWindow(this).Close();
            }
            
        }
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            SignINView signINView = new SignINView();
            signINView.Left = this.Left;
            signINView.Top = this.Top;
            signINView.Show();
            Window.GetWindow(this).Close();

        }
    }

     
}
