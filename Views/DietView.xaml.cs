using Azure;
using CHATAPI;
using KCK_Project__Console_Pocket_trainer_.Data;
using KCK_Project__Console_Pocket_trainer_.Interfaces;
using KCK_Project__Console_Pocket_trainer_.Models;
using KCK_Project__Console_Pocket_trainer_.Repositories;
using System;
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
using WPF_Pocket_Trainer.Data;
using WPF_Pocket_Trainer.Models;


namespace WPF_Pocket_Trainer.Views
{
    /// <summary>
    /// Interaction logic for DietView.xaml
    /// </summary>
    public partial class DietView : UserControl
    {
        
        private User _currentUser;
        private ApplicationDbContext _context;
        private UserRepository _userRepository;
        private DietRepository _dietRepository;

        public DietView()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            _userRepository = new UserRepository(_context);
            _dietRepository = new DietRepository(_context);
            CheckUserDataAsync();
        }
        private async Task CheckUserDataAsync()
        {
            _currentUser = _userRepository.GetUserById(UserSession.CurrentUser.Id);

            if (_currentUser.Height == null || _currentUser.Weight == null || _currentUser.TrainingsPerWeek == null)
            {
                WarningTextBlock.Visibility = Visibility.Visible;
                WarningButton.Visibility = Visibility.Visible;
                WarningBorder.Visibility = Visibility.Visible;
            }
            else
            {
                if (_dietRepository.GetUserDiets(UserSession.CurrentUser.Id).Count() ==0)
                {
                    GenerateDiet(_dietRepository);
                }
                else if (_dietRepository.GetUserDiets(UserSession.CurrentUser.Id).Any())
                {
                    var existingDiet = _dietRepository.GetUserDiets(UserSession.CurrentUser.Id);
                    var dietParts = SplitDietIntoTwoColumns(existingDiet[0].Text);
                    FormatTextBlock(DietTextBlock1, dietParts.Item1);
                    FormatTextBlock(DietTextBlock2, dietParts.Item2);
                }
                
                

            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Diet diet = new Diet()
            {
                Text = DietTextBlock1.Text + DietTextBlock2.Text,
                UserId = UserSession.CurrentUser.Id
            };
            _dietRepository.Add(diet);
            MessageBox.Show("Diet saved successfully!");

        }
        private void GenerateButton_Click(object sender, RoutedEventArgs e) 
        {
            GenerateDiet(_dietRepository);
            
        }

        private void NavigateToSettings(object sender, RoutedEventArgs e)
        {

            if (Window.GetWindow(this) is DashboardView mainWindow)
            {
                mainWindow.ChangeView(new SettingsView());
            }
        }
        private  async void GenerateDiet(DietRepository dietRepository)
        {

            // Show "Generating Diet" message
            DietTextBlock1.Text = "Generating Diet...";
            DietTextBlock2.Text = "";

            ChatGPT_diet.SetUpSetting();
            string prompt = ($"My weigh={UserSession.CurrentUser.Weight},Height={UserSession.CurrentUser.Height},TrainingsPerWeek={UserSession.CurrentUser.TrainingsPerWeek}.Write me a diet plan for 7 seven days.");

            var responseTask = ChatGPT_diet.SendRequestToChatGPT(prompt);

            var  response = await responseTask;

           

           
            var dietParts = SplitDietIntoTwoColumns(response);
            FormatTextBlock(DietTextBlock1, dietParts.Item1);
            FormatTextBlock(DietTextBlock2, dietParts.Item2);


           
        }
        private Tuple<string, string> SplitDietIntoTwoColumns(string diet)
        {
            var dietLines = diet.Split(new[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var firstColumn = new StringBuilder();
            var secondColumn = new StringBuilder();
            bool isSecondColumn = false;

            foreach (var line in dietLines)
            {
                if (line.Contains("5"))
                {
                    isSecondColumn = true;
                }

                if (isSecondColumn)
                {
                    secondColumn.AppendLine(line);
                }
                else
                {
                    firstColumn.AppendLine(line);
                }
            }

            return new Tuple<string, string>(firstColumn.ToString(), secondColumn.ToString());
        }
        private void FormatTextBlock(TextBlock textBlock, string text)
        {
            textBlock.Inlines.Clear();
            var lines = text.Split(new[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                if (line.StartsWith("**Day"))
                {
                    var run = new Run(line) { FontWeight = FontWeights.Bold, Foreground = Brushes.Yellow };
                    textBlock.Inlines.Add(run);
                }
                else
                {
                    var run = new Run(line) { Foreground = Brushes.White };
                    textBlock.Inlines.Add(run);
                }
                textBlock.Inlines.Add(new LineBreak());
            }
        }

    }
}
