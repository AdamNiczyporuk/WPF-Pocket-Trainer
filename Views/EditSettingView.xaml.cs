using KCK_Project__Console_Pocket_trainer_.Data;
using Microsoft.EntityFrameworkCore;
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
using WPF_Pocket_Trainer.Models;
using WPF_Pocket_Trainer.ViewModels;

namespace WPF_Pocket_Trainer.Views
{
    /// <summary>
    /// Interaction logic for EditSettingView.xaml
    /// </summary>
    public partial class EditSettingView : UserControl
    {
        private ApplicationDbContext _context;
        public EditSettingView()
        {

            InitializeComponent();
            this.DataContext = UserSession.CurrentUser;
            

        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveData();

        }
        private void SaveData()
        {
            // Przykład: Aktualizacja danych użytkownika
            var user = _context.Users.FirstOrDefault(u => u.Id == UserSession.CurrentUser.Id);
            if (user != null)
            {
                user.UserName = UserSession.CurrentUser.UserName;
                user.Height = UserSession.CurrentUser.Height;
                user.Weight = UserSession.CurrentUser.Weight;
                user.TrainingsPerWeek = UserSession.CurrentUser.TrainingsPerWeek;

                _context.SaveChanges(); // Zapisz zmiany w bazie danych
            }
        }
        private void NavigateToSettings(object sender, RoutedEventArgs e)
        {

            if (Window.GetWindow(this) is DashboardView mainWindow)
            {
                mainWindow.ChangeView(new SettingsView());
            }
        }
    }
}
