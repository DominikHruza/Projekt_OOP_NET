using Models;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;
using Utilities.OptionUtils;
using Utilities.SetupUtils;
using WinFormsDesktopClient.Client_Utils;

namespace WinFormsDesktopClient
{
    public partial class PlayersTabUC : UserControl
    {
        private IWorldCupServiceAsync worldCupServiceAsync;
        private HashSet<MatchPlayer> players = new HashSet<MatchPlayer>();
        private HashSet<MatchPlayer> favouritePlayers = new HashSet<MatchPlayer>();
        public PlayerItemUC markedPlayer;

        // private Set<> players = new HashSet<>
        public PlayersTabUC()
        {
            InitializeComponent();
        }

        private void PlayersTabUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            SetService();
            LoadPlayers();
            LoadFavoritesFromFile();
            FillPanelWithPlayers();

        }

        private async void LoadPlayers()
        {
            try
            {
                string fifaCode = AppSettingUtil.GetSettingFromSetupFile(
                           AppConstants.FAVOURITE_TEAM_PATH);

                if (fifaCode != "")
                {
                    List<MatchData> matchData = await this.worldCupServiceAsync
                        .GetMatchByCountryCodeAsync(fifaCode);

                    this.players = ExtractPlayers(matchData, fifaCode);
                    FillPanelWithPlayers();

                }
            }
            catch (Exception)
            {

                ErrorUtil.ShowErrorMessageBox();
            }

        }

        private void FillPanelWithPlayers()
        {
            foreach (var player in players)
            {
                PlayerItemUC playerItem = new PlayerItemUC(
                     player.Name,
                     player.ShirtNumber,
                     player.Position,
                     player.Captain ? "Yes" : "No"
                  );

                playerItem.ContextMenuStrip = contextMenuPlayerAdd;
                playerItem.Name = "playerItem";
                ImageUtils.SetSavedImageIfExists(playerItem, player.Name);
                if (favouritePlayers.Contains(player))
                {
                    playerItem.SetFavouriteIcon();
                    pnlFavourites.Controls.Add(playerItem);
                }
                else
                {
                    pnlPlayers.Controls.Add(playerItem);
                }

            }
        }



        private HashSet<MatchPlayer> ExtractPlayers(List<MatchData> matchData, string fifaCode)
        {
            MatchData firstGame = matchData.First();
            if (firstGame.HomeTeam.Code == fifaCode)
            {
                return new HashSet<MatchPlayer>(firstGame.HomeTeamStatistics.StartingEleven
                     .Union(firstGame.HomeTeamStatistics.Substitutes)
                   );
            }

            if (firstGame.AwayTeam.Code == fifaCode)
            {
                return new HashSet<MatchPlayer>(firstGame.AwayTeamStatistics.StartingEleven
                    .Union(firstGame.AwayTeamStatistics.Substitutes));

            }

            return new HashSet<MatchPlayer>();
        }


        private void SetService()
        {
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
                    MessageBox.Show($"{e.Message} { e.StackTrace}");
                }

            };
        }

        private void SetFavourite()
        {
            if (!FavouritesValid())
            {
                return;
            };

            try
            {

                markedPlayer.BorderStyle = BorderStyle.None;
                markedPlayer.ContextMenuStrip = contextMenuPlayerRemove;
                markedPlayer.SetFavouriteIcon();
                pnlFavourites.Controls.Add(markedPlayer);

                favouritePlayers.Add(markedPlayer.GetMatchPlayerFromControl());
                UpdateFavouriteFile();
                markedPlayer = null;
            }
            catch
            {
                ErrorUtil.ShowErrorMsgAndCloseApp();
            }
        }

        private void UpdateFavouriteFile()
        {

            string[] favourites = favouritePlayers
                 .Select(player => player.ParseToFileLine())
                 .ToArray();

            AppSettingUtil.SaveOptionToSetupFile(favourites,
                AppConstants.FAVOURITE_PLAYERS_PATH);
        }

        private void LoadFavoritesFromFile()
        {
            try
            {
                string[] playerLines = AppSettingUtil.GetLinesFromSetupFile(
                    AppConstants.FAVOURITE_PLAYERS_PATH);

                foreach (var line in playerLines)
                {
                    favouritePlayers.Add(
                        MatchPlayer.ParseFromFileLine(line));
                }
            }
            catch 
            {
                return;
            }
        }

        //################# CONTEXT MENU FUNCTIONS ##########################
        private void contextMenuPlayer_Opened(object sender, EventArgs e)
        {
            if (markedPlayer != null)
            {
                markedPlayer.BorderStyle = BorderStyle.None;
            }

            var menu = sender as ContextMenuStrip;
            PlayerItemUC playerControl = menu.SourceControl as PlayerItemUC;
            playerControl.BorderStyle = BorderStyle.Fixed3D;
            markedPlayer = playerControl;
        }

        private void contextMenuPlayer_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            var menu = sender as ContextMenuStrip;
            PlayerItemUC playerControl = menu.SourceControl as PlayerItemUC;
            playerControl.BorderStyle = BorderStyle.FixedSingle;

        }

        private void addToFavoritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetFavourite();
        }



        private void removeFromFavouritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveFavourite();
        }

        private void RemoveFavourite()
        {
            try
            {

                markedPlayer.ContextMenuStrip = contextMenuPlayerAdd;
                pnlPlayers.Controls.Add(markedPlayer);

                var foundFavourite = favouritePlayers.First(
                    player => player.Equals(
                        markedPlayer.GetMatchPlayerFromControl()));

                favouritePlayers.Remove(foundFavourite);
                UpdateFavouriteFile();
                markedPlayer = null;
            }
            catch
            {

                ErrorUtil.ShowErrorMsgAndCloseApp();
            }
        }

        //################# DRAG AND DROP FUNCTIONS ##########################
        private bool FavouritesValid()
        {

            try
            {
                if (pnlFavourites.Controls.Count >= 3)
                {
                    ErrorUtil.ShowErrorMessageBox(
                        "Max number of favourite players reached!");
                    return false;
                }


                MatchPlayer matchPlayer = markedPlayer.GetMatchPlayerFromControl();
                if (favouritePlayers.Contains(matchPlayer))
                {
                    ErrorUtil.ShowErrorMessageBox(
                        "Player already added to favourites!");
                    return false;
                }

                return true;
            }
            catch
            {
                ErrorUtil.ShowErrorMsgAndCloseApp();
                return false;

            }
        }

        private void pnlFavourites_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void pnlFavourites_DragDrop(object sender, DragEventArgs e)
        {
            markedPlayer = e.Data.GetData(
                typeof(PlayerItemUC)) as PlayerItemUC;
            SetFavourite();
        }

        private void pnlPlayers_DragDrop(object sender, DragEventArgs e)
        {

            FlowLayoutPanel currentPanel = sender as FlowLayoutPanel;
            PlayerItemUC playerItemUC = e.Data.GetData(typeof(PlayerItemUC)) as PlayerItemUC;
            Control parentPanel = playerItemUC.Parent;

            if (currentPanel == parentPanel)
            {
                return;
            }
            markedPlayer = e.Data.GetData(
               typeof(PlayerItemUC)) as PlayerItemUC;
            RemoveFavourite();
        }

        //################# MULTISELECT FUNCTIONS ##########################
        private void btnFromFavourite_Click(object sender, EventArgs e)
        {

            try
            {
                foreach (var playerItem in
                      pnlFavourites.Controls.Find("playerItem", false))
                {
                    CheckBox checkbox = playerItem.Controls
                        .Find("checkBoxPlayer", true)
                        .First()
                        as CheckBox;


                    if (checkbox.Checked)
                    {
                        markedPlayer = playerItem as PlayerItemUC;
                        checkbox.Checked = false;
                        RemoveFavourite();
                    }
                }
            }
            catch (Exception)
            {

                ErrorUtil.ShowErrorMsgAndCloseApp();
            }
        }

        private void btnToFavorite_Click(object sender, EventArgs e)
        {

            try
            {
                foreach (var playerItem in
                        pnlPlayers.Controls.Find("playerItem", false))
                {
                    CheckBox checkbox = playerItem.Controls
                        .Find("checkBoxPlayer", true)
                        .First()
                        as CheckBox;


                    if (checkbox.Checked)
                    {
                        markedPlayer = playerItem as PlayerItemUC;
                        checkbox.Checked = false;
                        SetFavourite();
                    }
                }
            }
            catch (Exception)
            {

                ErrorUtil.ShowErrorMsgAndCloseApp();
            }
        }
    }
}
