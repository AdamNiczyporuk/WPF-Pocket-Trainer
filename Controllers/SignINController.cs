using KCK_Project__Console_Pocket_trainer_.Repositories;
using KCK_Project__Console_Pocket_trainer_.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCK_Project__Console_Pocket_trainer_.Models;
using System.Windows;
using Microsoft.IdentityModel.Tokens;
using WPF_Pocket_Trainer.Models;


namespace WPF_Pocket_Trainer.Controllers
{
    class SignINController
    {
        public bool ValidateData(string username, string password)
        {
            if(username == null|| password == null)
            {
                ShowMessage("Please fill all fields.");
                return false;
            } 
            using(var context = new ApplicationDbContext ())
            {
                var userRepository = new UserRepository(context);
                var existingUser = userRepository.GetUserByUserName(username);
                if(existingUser != null)
                {
                    ShowMessage("Uer already exists if it's you please login\nor try other username.");
                    return false;
                }
                else
                {
                    User user = new User()
                    {
                        UserName = username,
                        Password = password
                    };
                    UserSession.CurrentUser = user;
                    userRepository.Add(user);
                    return true;
                }
            }
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

    }
}
