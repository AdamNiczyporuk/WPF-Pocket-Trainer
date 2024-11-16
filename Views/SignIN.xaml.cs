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
    /// Interaction logic for SignIN.xaml
    /// </summary>
    public partial class SignIN : Page
    {
        public SignIN()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Sprawdzanie danych logowania
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (username == "admin" && password == "password") // Przykładowa logika logowania
            {
                // Po zalogowaniu, przejdź do głównego widoku
                var mainWindow = new MainWindow(); // Główne okno aplikacji
                mainWindow.Show();
                ((Window)this.Parent).Close(); // Zamknij stronę logowania
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
