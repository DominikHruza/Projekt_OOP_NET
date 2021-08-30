using Models;
using Services;
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
using Utilities.OptionUtils;
using Utilities.SetupUtils;

namespace WPF_client
{
    /// <summary>
    /// Interaction logic for FavouriteTeamTab.xaml
    /// </summary>
    public partial class FavouriteTeamTab : UserControl
    {
        private Team selectedTeam;
        private Team selectedOpp;
        private List<TeamInMatch> opponents = new List<TeamInMatch>();
        private List<Team> teams = new List<Team>();
        private List<MatchData> matches = new List<MatchData>();
        private Window parentWindow;

        public List<MatchData> Matches { get => matches; }
        public Team FavouriteTeam { get => selectedTeam; }
        public Team OpponentTeam { get => selectedOpp; }


        private IWorldCupServiceAsync worldCupServiceAsync;

        public FavouriteTeamTab()
        {
            InitializeComponent();
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            parentWindow = Window.GetWindow(this);
            SetService();
            FillTeamsDropdown();

        }

        private async void FillOpponentsDropdown(string fifaCode)
        {
            
            parentWindow.Cursor = Cursors.Wait;

            opponents.Clear();
            cbOpponentPick.Items.Clear();
            matches = await worldCupServiceAsync.GetMatchByCountryCodeAsync(fifaCode);

            matches.ForEach(match =>
            {
                if (!match.AwayTeam.Code.Equals(fifaCode))
                {
                    opponents.Add(match.AwayTeam);
                }

                if (!match.HomeTeam.Code.Equals(fifaCode))
                {
                    opponents.Add(match.HomeTeam);
                }

            });

            opponents.ForEach(opponent =>
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Tag = opponent.Code;
                item.Content = opponent.ToString();
                cbOpponentPick.Items.Add(
                    item);

            });

            cbOpponentPick.SelectedItem = cbOpponentPick.Items[0];
            parentWindow.Cursor = Cursors.Arrow;
            btnOppDetails.IsEnabled = true;
        }

        private void cbFavoritePick_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.selectedTeam = cbFavoritePick.SelectedItem as Team;
            FillOpponentsDropdown(selectedTeam.FifaCode);
            SaveSelectedTeamFifaCode();
        }

        private void SetService()
        {
            if (!File.Exists(AppConstants.CONTEST_SETTINGS_PATH))
            {
                return;

            }

            ContestType? contestConfig = AppSettingUtil.GetContestConfig();
            if (contestConfig.HasValue)
            {
                try
                {
                    this.worldCupServiceAsync = WorldCupServiceFactory.GetAsyncService(
                       contestConfig.Value);
                }
                catch (Exception e)
                {

                }

            };
        }

        private async void FillTeamsDropdown()
        {
            try
            {
           
                parentWindow.Cursor = Cursors.Wait;

                this.teams = await worldCupServiceAsync.GetAllTeamsAsync();
                this.teams.ForEach(team => cbFavoritePick.Items.Add(team));

                if (GetSavedTeamFromFile() != null)
                {
                    SetSelectectedItem(GetSavedTeamFromFile());
                }

                parentWindow.Cursor = Cursors.Arrow;
                btnFavDetails.IsEnabled = true;
            }
            catch (Exception e)
            {
                ErrorUtil.ShowErrorMessageBox();
            }

        }

        private void SaveSelectedTeamFifaCode()
        {
            try
            {

                string teamId = selectedTeam.FifaCode;
                AppSettingUtil.SaveOptionToSetupFile(teamId,
                   AppConstants.FAVOURITE_TEAM_PATH);
            }
            catch (Exception)
            {
                ErrorUtil.ShowErrorMessageBox(
                    "Save failed, try again!");
            }
        }

        private void SetSelectectedItem(string idFromFile)
        {
            try
            {
                this.selectedTeam = teams.First((team) => team.FifaCode.Equals(idFromFile));
                cbFavoritePick.SelectedItem = selectedTeam;

            }
            catch (Exception e)
            {

                ErrorUtil.ShowErrorMessageBox("Error loading saved team!");
            }

        }

        private string GetSavedTeamFromFile()
        {
            try
            {
                string favoriteTeamCode = AppSettingUtil.GetSettingFromSetupFile(
                        AppConstants.FAVOURITE_TEAM_PATH);

                if (favoriteTeamCode == "")
                {
                    return null;
                }
                return favoriteTeamCode;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                ErrorUtil.ShowErrorMessageBox();
                return null;
            }

        }

        private void cbOpponentPick_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbOpponentPick.SelectedItem != null)
            {
                string tag = ((ComboBoxItem)cbOpponentPick.SelectedItem).Tag.ToString();

                selectedOpp = teams.Find(opponent =>
                opponent.FifaCode.Equals(tag));
                GetMatchResult();
            }
            
        }

        private void GetMatchResult()
        {
            matches.ForEach(match =>
            {
                
                if (match.AwayTeam.Code.Equals(selectedOpp.FifaCode) || match.HomeTeam.Code.Equals(selectedOpp.FifaCode))
                {


                    if (match.AwayTeam.Code.Equals(selectedTeam.FifaCode))
                    {
                        lbResult.Content = 
                        $"{match.AwayTeam.Goals} ({match.AwayTeam.Penalties}) : " +
                        $"{match.HomeTeam.Goals} ({match.HomeTeam.Penalties})";
                    }

                    if (match.HomeTeam.Code.Equals(selectedTeam.FifaCode))
                    {
                        lbResult.Content = 
                        $"{match.HomeTeam.Goals} ({match.HomeTeam.Penalties}) : " +
                        $"{match.AwayTeam.Goals} ({match.AwayTeam.Penalties})";
                    }
                }
            });
        }

        private void btnFavDetails_Click(object sender, RoutedEventArgs e)
        {
            var detailsWindow = new TeamDetails();
            detailsWindow.Team = teams.Find(team => team.FifaCode.Equals(selectedTeam.FifaCode));
            detailsWindow.ShowDialog();
        }

        private void btnOppDetails_Click(object sender, RoutedEventArgs e)
        {
            var detailsWindow = new TeamDetails();
            detailsWindow.Team = teams.Find(team => team.FifaCode.Equals(selectedOpp.FifaCode));
            detailsWindow.ShowDialog();
        }
    }


}

