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

namespace WPF_Pocket_Trainer.Controllers
{
    class LogINController
    {
        public bool ValidateData(string username, string password)
        {
            using (var context = new ApplicationDbContext())
            {
                var userRepository = new UserRepository(context);

                var existingUser = userRepository.GetUserByUserName(username);
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    ShowErrorMessage();
                }
                if(existingUser != null)
                {
                    if(existingUser.Password == password)
                    {
                        ShowMessage("Login successful!", "Success", "OK", "Information");
                        return true;
                        
                    }
                    else
                    {
                       
                        return false;
                        
                    }
                }
                else
                {
                  
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
