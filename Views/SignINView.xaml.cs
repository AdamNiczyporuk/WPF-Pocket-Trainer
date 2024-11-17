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
    /// Interaction logic for SignINView1.xaml
    /// </summary>
    public partial class SignINView : Window
    {
        private readonly SignINController _SignINController;
        public SignINView()
        {
            InitializeComponent();
            _SignINController = new SignINController();
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
            if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }

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
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LogINView logINview = new LogINView();
            logINview.Left = this.Left;
            logINview.Top = this.Top;
            logINview.Show();
            Window.GetWindow(this).Close();

        }

    }
}
