using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Repositories;
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
using WPF_Pocket_Trainer.Data;
using WPF_Pocket_Trainer.Models;

namespace WPF_Pocket_Trainer.Views
{
    /// <summary>
    /// Interaction logic for DietView.xaml
    /// </summary>
    public partial class DietView : UserControl
    {
        private User _currentUser;
        private ApplicationDbContext _context;
        private UserRepository _userRepository;
        
        public DietView()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            _userRepository = new UserRepository(_context);
            CheckUserData();
        }
        private void CheckUserData()
        {
            _currentUser = _userRepository.GetUserById(UserSession.CurrentUser.Id);

            if (_currentUser.Height == null || _currentUser.Weight == null || _currentUser.TrainingsPerWeek == null)
            {
                WarningTextBlock.Visibility = Visibility.Visible;
            }
        }

       
    }
}
