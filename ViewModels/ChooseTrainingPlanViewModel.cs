using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Pocket_Trainer.ViewModels
{
    public class ChooseTrainingPlanViewModel: TrainingPlan
    {
        public int exercisesCount { get; set; }
        public int trainingsCount { get; set; }
        public ChooseTrainingPlanViewModel(TrainingPlan trainingPlan)
        {
            this.Id = trainingPlan.Id;
            this.Name = trainingPlan.Name;
            this.Description = trainingPlan.Description;
            using(var context = new ApplicationDbContext())
            {
                var exerciseRepository = new ExerciseRepository(context);
                var trainingRepository = new TrainingRepository(context);
                var exercises = exerciseRepository.GetExercisesByTrainingPlan(trainingPlan.Id);
                var trainings = trainingRepository.GetTrainingsByTrainingPlan(trainingPlan.Id);

                exercisesCount = exercises?.Count ?? 0;
                trainingsCount = trainings?.Count ?? 0;

            }
        }
    }
}
