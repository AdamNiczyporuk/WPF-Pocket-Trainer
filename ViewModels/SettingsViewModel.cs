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
        public ICommand ChangeToEditSettingsViewCommand { get; }

        public SettingsViewModel()
        {
            ChangeToEditSettingsViewCommand = new RelayCommand(ChangeToEditSettings);
        }

        private void ChangeToEditSettings()
        {
            Messenger.Default.Send(new ViewChangeMessage(new EditSettingViewModel()));
        }
    }
}
