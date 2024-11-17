using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Pocket_Trainer.Models;
using KCK_Project__Console_Pocket_trainer_.Models;

namespace WPF_Pocket_Trainer.Controllers
{
    class LogINController
    {
        public bool ValidateData(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ShowErrorMessage("Username or password cannot be empty.");
                return false;
            }

            using (var context = new ApplicationDbContext())
            {
                var userRepository = new UserRepository(context);
                var existingUser = userRepository.GetUserByUserName(username);

                if (existingUser == null)
                {
                    ShowErrorMessage("User not found.");
                    return false;
                }

                if (existingUser.Password == password)
                {
                    // Ustawienie danych użytkownika w sesji
                    UserSession.CurrentUser = new User
                    {
                        UserName = existingUser.UserName,
                        Height = existingUser.Height,
                        Weight = existingUser.Weight
                    };
                    return true;
                }
                else
                {
                    ShowErrorMessage("Incorrect password.");
                    return false;
                }
            }
        }

        public void ShowMessage(string message, string title, string button, string image)
        {
            MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public void ShowErrorMessage()
        {
            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
        public void ShowSuccessMessage()
        {
            MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
