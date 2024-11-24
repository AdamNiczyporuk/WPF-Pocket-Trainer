using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Pocket_Trainer.ViewModels
{
    public class ManageTrainingPlanExercisesViewModel
    {
        public TrainingPlan TrainingPlan { get; set; }
        public List<ExerciseWithSets> TrainingPlanExercises { get; set; }
        public List<Exercise> AvailableExercises { get; set; }

        public ManageTrainingPlanExercisesViewModel(TrainingPlan trainingPlan, List<ExerciseWithSets> trainingPlanExercises, List<Exercise> availableExercises)
        {
            TrainingPlan = trainingPlan;
            TrainingPlanExercises = trainingPlanExercises;
            AvailableExercises = availableExercises;
        }
    }
}
