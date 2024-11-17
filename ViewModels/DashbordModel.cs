using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Pocket_Trainer.Dashboard.Core;
namespace WPF_Pocket_Trainer.ViewModels
{
    class DashbordModel : ObservableObject
    {
        public RelayCommand DashboardViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }

        public TrainignsViewModel TrainignsVM { get; set; }
        public SettingViewModel SettingVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set {
                _currentView = value;
                OnPropertyChange();
            }
            
        }



        public DashbordModel()
        {
            TrainignsVM = new TrainignsViewModel();
            SettingVM = new SettingViewModel();
            CurrentView = TrainignsVM;
        }
    }
}
