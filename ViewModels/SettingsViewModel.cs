using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WPF_Pocket_Trainer.Views.SettingsView;

namespace WPF_Pocket_Trainer.ViewModels
{
    class SettingsViewModel
    {
        public ObservableCollection<SettingItem> Settings { get; set; }

        public SettingsViewModel()
        {
            // Przykładowe dane
            Settings = new ObservableCollection<SettingItem>
        {
            new SettingItem { Property = "Username", Value = "JohnDoe" },
            new SettingItem { Property = "Email", Value = "john.doe@example.com" }
        };
        }
    }
}
