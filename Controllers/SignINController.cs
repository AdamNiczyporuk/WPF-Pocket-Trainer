using KCK_Project__Console_Pocket_trainer_.Repositories;
using KCK_Project__Console_Pocket_trainer_.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCK_Project__Console_Pocket_trainer_.Models;
using System.Windows;


namespace WPF_Pocket_Trainer.Controllers
{
    class SignINController
    {
        public bool ValidateData(string username, string password)
        {
            using(var context = new ApplicationDbContext ())
            {
                var userRepository = new UserRepository(context);
                var existingUser = userRepository.GetUserByUserName(username);
                if(existingUser != null)
                {
                    return false;
                }
                else
                {
                    User user = new User()
                    {
                        UserName = username,
                        Password = password
                    };
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
