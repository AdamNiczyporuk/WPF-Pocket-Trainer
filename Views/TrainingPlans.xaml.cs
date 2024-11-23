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
using KCK_Project__Console_Pocket_trainer_.Repositories;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Data;
using WPF_Pocket_Trainer.Models;

namespace WPF_Pocket_Trainer.Views
{
    /// <summary>
    /// Interaction logic for TrainingPlans.xaml
    /// </summary>
    public partial class TrainingPlans : UserControl
    {
        private readonly TrainingPlanRepository _trainingPlanRepository;
        public List<TrainingPlan> UserTrainingPlans { get; set; }

        public TrainingPlans()
        {
            InitializeComponent();
            _trainingPlanRepository = new TrainingPlanRepository(new ApplicationDbContext());
            LoadTrainingPlans();
        }

        private void LoadTrainingPlans()
        {
            // Assuming you have a way to get the current user's ID
            int currentUserId = UserSession.CurrentUser.Id;
            UserTrainingPlans = _trainingPlanRepository.GetUserTrainingPlans(currentUserId);
            DataContext = this;
        }

      

        private void AddNewTrainingPlan_Click(object sender, RoutedEventArgs e)
        {
            // Placeholder for adding a new training plan
            MessageBox.Show("Add New Training Plan clicked");
        }

        private void EditTrainingPlan_Click(object sender, RoutedEventArgs e)
        {
            // Placeholder for editing the selected training plan
            MessageBox.Show("Edit Training Plan clicked");
        }

        private void DeleteTrainingPlan_Click(object sender, RoutedEventArgs e)
        {
            // Placeholder for deleting the selected training plan
            MessageBox.Show("Delete Training Plan clicked");
        }

        private void ManageExercises_Click(object sender, RoutedEventArgs e)
        {
            // Placeholder for managing exercises in the selected training plan
            MessageBox.Show("Manage Exercises clicked");
        }
    }
}