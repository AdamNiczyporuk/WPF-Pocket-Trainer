using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_Pocket_Trainer.Dashboard.Core;
using WPF_Pocket_Trainer.Services;

namespace WPF_Pocket_Trainer.ViewModels
{
     class SettingsViewModel : ObservableObject
    {
        public ICommand ChangeToTrainingsViewCommand { get; }

        public SettingsViewModel()
        {
            ChangeToTrainingsViewCommand = new RelayCommand(ChangeToTrainingsView);
        }

        private void ChangeToTrainingsView()
        {
            Messenger.Default.Send(new ViewChangeMessage(new TrainignsViewModel()));
        }
    }
}
