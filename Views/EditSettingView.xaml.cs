﻿using System;
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
 
        public EditSettingView()
        {

            InitializeComponent();
            this.DataContext = UserSession.CurrentUser;


        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //UserSession.CurrentUser.UserName = UserNameTextBox.Text;

        }
    }
}
