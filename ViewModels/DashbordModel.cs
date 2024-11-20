using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WPF_Pocket_Trainer.Dashboard.Core;
using WPF_Pocket_Trainer.Services;
using WPF_Pocket_Trainer.Views;
namespace WPF_Pocket_Trainer.ViewModels
{
    class DashbordModel : ObservableObject
    {
        public RelayCommand TrainingsViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }
        public RelayCommand DietViewCommand { get; set; }
        public RelayCommand LogOutCommand { get; set; }

        public TrainignsViewModel TrainignsVM { get; set; }
        public SettingsViewModel SettingVM { get; set; }
        public DietViewModel DietVM { get; set; }

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
            SettingVM = new SettingsViewModel();
            DietVM = new DietViewModel();
            CurrentView = TrainignsVM;

            TrainingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = TrainignsVM;
            });

            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingVM;
            });
            DietViewCommand = new RelayCommand(o =>
            {
                CurrentView = DietVM;
            });
            LogOutCommand = new RelayCommand(ExecuteLogOut);
            

            Messenger.Default.Register<ViewChangeMessage>(this, message =>
            {
                CurrentView = message.ViewModel;
            });
        }
       

        private void ExecuteLogOut(object obj)
        {
            // Pobierz bieżące okno
            var currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

            if (currentWindow != null)
            {
                // Otwórz nowe okno logowania
                LogINView logINView = new LogINView();
                logINView.Left = currentWindow.Left;
                logINView.Top = currentWindow.Top;
                logINView.Show();

                // Zamknij bieżące okno
                currentWindow.Close();
            }
        }
    }
}
