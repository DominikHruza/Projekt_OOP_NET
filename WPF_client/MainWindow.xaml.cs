using Models;
using System;
using System.Collections.Generic;
using System.IO;
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
using Utilities;
using Utilities.SetupUtils;

namespace WPF_client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string appLanguage = "";
        private string selectedContest = "";
        private MatchData matchData;
        private HashSet<MatchPlayer> startingElevenFav = new HashSet<MatchPlayer>();
        private HashSet<MatchPlayer> startingElevenOpp = new HashSet<MatchPlayer>();

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            SetResolution();
            pnlFavTeam.cbFavoritePick.SelectionChanged += CbFavoritePick_SelectionChanged;
            pnlFavTeam.cbOpponentPick.SelectionChanged += CbOpponentPick_SelectionChanged;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadSettingsFromFile();
                if (!IsAppConfigured())
                {
                    OpenSetupDialog();
                }
            }
            catch
            {
                
            }

        }

        private void CbOpponentPick_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                gridField.Children.Clear();
                FillGridWithPlayers();
            }
            catch
            {
                ErrorUtil.ShowErrorMessageBox();
            }
        }

        private void CbFavoritePick_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gridField.Children.Clear();
        }

        private void SetResolution()
        {
            try
            {
                string res = ReadResolutionSettings();
                if (res == "")
                {
                    return;
                }

                string[] resolutionData = res.Split('x');

                if (resolutionData[0].ToLower() == "fullscreen")
                {
                    this.WindowState = WindowState.Maximized;
                    return;
                }
                this.Width = int.Parse(resolutionData[0]);
                this.Height = int.Parse(resolutionData[1]);
            }
            catch
            {

                ErrorUtil.ShowErrorMessageBox();
            }

        }

        private string ReadResolutionSettings()
        {
            try
            {

                string fullName = Directory.GetParent(
                Directory.GetCurrentDirectory())
                .Parent.FullName;

                string[] settings = File.ReadAllLines(fullName + @"\resolution.txt");
                return settings[0];
            }
            catch
            {
                return "";
            }
        }

        
        private static void OpenSetupDialog()
        {
            var appSetupDialog = new SetupWindow();
            appSetupDialog.ShowDialog();

        }
     

        private bool IsAppConfigured()
        {
            if (appLanguage == "" || selectedContest == "")
            {
                return false;
            }

            return true;
        }

        private void LoadSettingsFromFile()
        {
            try
            {
                this.appLanguage = AppSettingUtil.GetSettingFromSetupFile(
                    AppConstants.LANGUAGE_SETTINGS_PATH);

                this.selectedContest = AppSettingUtil.GetSettingFromSetupFile(
                     AppConstants.CONTEST_SETTINGS_PATH);


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            OpenSetupDialog();
          
        }

        public void FillGridWithPlayers()
        {
            matchData = pnlFavTeam.Matches.Find((match) =>
            {
                return (match.AwayTeamCountry.Equals(pnlFavTeam.OpponentTeam.Country) ||
                       match.HomeTeamCountry.Equals(pnlFavTeam.OpponentTeam.Country));
            });

            SetStartingEleven();
            string favTeamTactic = GetTactic(pnlFavTeam.FavouriteTeam.Country);
            string oppTeamTactic = GetTactic(pnlFavTeam.OpponentTeam.Country);

            PopulatePlayers(favTeamTactic, oppTeamTactic);
        }

        private void SetStartingEleven()
        {
            if (matchData.AwayTeam.Country.Equals(pnlFavTeam.FavouriteTeam.Country))
            {
                startingElevenFav = matchData.AwayTeamStatistics.StartingEleven;
            }
            else
            {
                startingElevenFav = matchData.HomeTeamStatistics.StartingEleven;
            }


            if (matchData.AwayTeam.Country.Equals(pnlFavTeam.OpponentTeam.Country))
            {
                startingElevenOpp = matchData.AwayTeamStatistics.StartingEleven;
            }
            else
            {
                startingElevenOpp = matchData.HomeTeamStatistics.StartingEleven;
            }
        }


        void PopulatePlayers(string favTeamTactic, string oppTeamTactic)
        {
            PopulateFavourites(favTeamTactic);
            PopulateOpponents(oppTeamTactic);

        }

        private void PopulateOpponents(string oppTeamTactic)
        {
            List<string> list = oppTeamTactic.Split('-').ToList();
            List<int> tacticData = list.Select(str => int.Parse(str)).ToList();


            int forwardRowStart;
            int forwardRowStep;

            int midRowStart;
            int midRowStep;

            int defenderRowStart;
            int defenderRowStep;

            DetermineGridCells(out forwardRowStart, out forwardRowStep, tacticData[2]);
            DetermineGridCells(out midRowStart, out midRowStep, tacticData[1]);
            DetermineGridCells(out defenderRowStart, out defenderRowStep, tacticData[0]);

            foreach (MatchPlayer player in startingElevenOpp)
            {

                Player playerCtrl = new Player();
                playerCtrl.MouseDown += PlayerCtrl_MouseDown;
                playerCtrl.SetNum(player.ShirtNumber);
                playerCtrl.SetName(player.Name);
                playerCtrl.SetSavedImageIfExists(player.Name);
                playerCtrl.HorizontalAlignment = HorizontalAlignment.Center;
                playerCtrl.VerticalAlignment = VerticalAlignment.Center;

                if (player.Position.Equals("Goalie"))
                {

                    Grid.SetRow(playerCtrl, 3);
                    Grid.SetColumn(playerCtrl, 7);

                }

                if (player.Position.Equals("Defender"))
                {

                    Grid.SetRow(playerCtrl, defenderRowStart);
                    Grid.SetColumn(playerCtrl, 6);
                    Grid.SetRowSpan(playerCtrl, 2);
                    defenderRowStart += defenderRowStep;
                }

                if (player.Position.Equals("Midfield"))
                {
                    Grid.SetRow(playerCtrl, midRowStart);
                    Grid.SetColumn(playerCtrl, 5);
                    Grid.SetRowSpan(playerCtrl, 2);
                    midRowStart += midRowStep;
                }

                if (player.Position.Equals("Forward"))
                {
                    Grid.SetRow(playerCtrl, forwardRowStart);
                    Grid.SetColumn(playerCtrl, 4);
                    Grid.SetRowSpan(playerCtrl, 2);
                    forwardRowStart += forwardRowStep;
                }


                gridField.Children.Add(playerCtrl);
            }
        }

        private void PlayerCtrl_MouseDown(object sender, MouseButtonEventArgs e)
        {

            try
            {
                var detailsWindow = new PlayerDetails(((Player)sender).lbName.Content.ToString(), matchData);
                detailsWindow.ShowDialog();
            }
            catch 
            {
                ErrorUtil.ShowErrorMessageBox();
            }
        }

        private void PopulateFavourites(string favTeamTactic)
        {
            List<string> list = favTeamTactic.Split('-').ToList();
            List<int> tacticData = list.Select(str => int.Parse(str)).ToList();


            int forwardRowStart;
            int forwardRowStep;

            int midRowStart;
            int midRowStep;

            int defenderRowStart;
            int defenderRowStep;

            DetermineGridCells(out forwardRowStart, out forwardRowStep, tacticData[2]);
            DetermineGridCells(out midRowStart, out midRowStep, tacticData[1]);
            DetermineGridCells(out defenderRowStart, out defenderRowStep, tacticData[0]);

            foreach (MatchPlayer player in startingElevenFav)
            {

                Player playerCtrl = new Player();
                playerCtrl.MouseDown += PlayerCtrl_MouseDown;
                playerCtrl.SetNum(player.ShirtNumber);
                playerCtrl.SetName(player.Name);
                playerCtrl.SetSavedImageIfExists(player.Name);
                playerCtrl.HorizontalAlignment = HorizontalAlignment.Center;
                playerCtrl.VerticalAlignment = VerticalAlignment.Center;

                if (player.Position.Equals("Goalie"))
                {

                    Grid.SetRow(playerCtrl, 3);
                    Grid.SetColumn(playerCtrl, 0);

                }

                if (player.Position.Equals("Defender"))
                {

                    Grid.SetRow(playerCtrl, defenderRowStart);
                    Grid.SetColumn(playerCtrl, 1);
                    Grid.SetRowSpan(playerCtrl, 2);
                    defenderRowStart += defenderRowStep;
                }

                if (player.Position.Equals("Midfield"))
                {
                    Grid.SetRow(playerCtrl, midRowStart);
                    Grid.SetColumn(playerCtrl, 2);
                    Grid.SetRowSpan(playerCtrl, 2);
                    midRowStart += midRowStep;
                }

                if (player.Position.Equals("Forward"))
                {
                    Grid.SetRow(playerCtrl, forwardRowStart);
                    Grid.SetColumn(playerCtrl, 3);
                    Grid.SetRowSpan(playerCtrl, 2);
                    forwardRowStart += forwardRowStep;
                }


                gridField.Children.Add(playerCtrl);
            }
        }
        private void DetermineGridCells(out int rowStart, out int rowStep, int playersInLine)
        {
            switch (playersInLine)
            {
                case 1:
                    rowStart = 3;
                    rowStep = 0;
                    break;
                case 2:
                    rowStart = 2;
                    rowStep = 2;
                    break;
                case 3:
                    rowStart = 1;
                    rowStep = 2;
                    break;
                case 4:
                    rowStart = 0;
                    rowStep = 2;
                    break;
                case 5:
                    rowStart = 1;
                    rowStep = 1;
                    break;
                default:
                    rowStart = 0;
                    rowStep = 1;
                    break;
            }
        }


        private string GetTactic(string country)
        {
            int defender = 0;
            int midfield = 0;
            int forward = 0;

            if (matchData.AwayTeam.Country.Equals(country))
            {
                defender = matchData.AwayTeamStatistics.StartingEleven.Count(
                    player => player.Position.Equals("Defender"));

                midfield = matchData.AwayTeamStatistics.StartingEleven.Count(
                    player => player.Position.Equals("Midfield"));

                forward = matchData.AwayTeamStatistics.StartingEleven.Count(
                    player => player.Position.Equals("Forward"));
            }

            if (matchData.HomeTeam.Country.Equals(country))
            {
                defender = matchData.HomeTeamStatistics.StartingEleven.Count(
                   player => player.Position.Equals("Defender"));

                midfield = matchData.HomeTeamStatistics.StartingEleven.Count(
                    player => player.Position.Equals("Midfield"));

                forward = matchData.HomeTeamStatistics.StartingEleven.Count(
                    player => player.Position.Equals("Forward"));
            }

            return $"{defender}-{midfield}-{forward}";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            if (MessageBox.Show(
                "About to exit program?",
                "Confirm Exit", MessageBoxButton.OKCancel) != MessageBoxResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
