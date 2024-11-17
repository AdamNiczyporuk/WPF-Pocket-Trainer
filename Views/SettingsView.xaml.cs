using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPF_Pocket_Trainer.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public ObservableCollection<SettingItem> Settings { get; set; }
        public class SettingItem
        {
            public string Property { get; set; }
            public string Value { get; set; }
        }

        public SettingsView(object settingsData)
        {
            InitializeComponent();

            Settings = new ObservableCollection<SettingItem>
        {
            new SettingItem { Property = "Username", Value = "JohnDoe" },
            new SettingItem { Property = "Email", Value = "john.doe@example.com" }
        };


        }

       
    }
   
}
