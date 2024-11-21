﻿using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Repositories;
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
        private UserRepository _userRepository;
        private string _userName;
        private float _height;
        private float _weight;
        private int _trainingsPerWeek;
        public EditSettingView()
        {

            InitializeComponent();
            this.DataContext = UserSession.CurrentUser;
             _context = new ApplicationDbContext();
            _userRepository = new UserRepository(_context);



        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            UserSession.CurrentUser.Height = _height;
            UserSession.CurrentUser.Weight = _weight;
            UserSession.CurrentUser.TrainingsPerWeek = _trainingsPerWeek;
            SaveData();
            NavigateToSettings( sender,e);

        }
        private void SaveData()
        {
            // Przykład: Aktualizacja danych użytkownika
            User user = _userRepository.GetUserById(UserSession.CurrentUser.Id);
            if (user != null)
            {

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
        private void UserNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _userName = ((TextBox)sender).Text;
        }

        private void HeightTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (float.TryParse(((TextBox)sender).Text, out float height))
            {
                _height = height;
            }
        }

        private void WeightTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (float.TryParse(((TextBox)sender).Text, out float weight))
            {
                _weight = weight;
            }
        }

        private void TrainingsPerWeekTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(((TextBox)sender).Text, out int trainingsPerWeek))
            {
                _trainingsPerWeek = trainingsPerWeek;
            }
        }
    }
}
