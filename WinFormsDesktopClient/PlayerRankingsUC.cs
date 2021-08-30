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
    public partial class PlayerRankingsUC : UserControl
    {
        private IWorldCupServiceAsync worldCupServiceAsync;
        private string fifaCode;
        private List<TeamEvent> yellowCards;
        private List<TeamEvent> goalEvents;
        private Dictionary<MatchPlayer, PlayerRankingCriteria> playersRankingData =
           new Dictionary<MatchPlayer, PlayerRankingCriteria>();

        public PlayerRankingsUC()
        {
            InitializeComponent();
            this.fifaCode = AppSettingUtil.GetSettingFromSetupFile(
                                 AppConstants.FAVOURITE_TEAM_PATH);
        }

        private void PlayerRankingsUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Bottom;
            SetService();
            PrepareData();
        }

        private void yellowCardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortByYellowCards();
            PopulatePanel();
        }

        private void goalsScoredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortByGoalsScored();
            PopulatePanel();
        }

        private void GetPlayersGoalCount()
        {

            playersRankingData.ToList().ForEach(playerData =>
            {
                int goalCount = goalEvents
                    .FindAll(goalEvent => goalEvent.Player.Equals(playerData.Key.Name))
                    .Count;

                playerData.Value.GoalsScored = goalCount;
            });    
        }

        private void GetPlayersYellowCardCount()
        {
            playersRankingData.ToList().ForEach(playerData =>
            {
                int cardCount = yellowCards
                    .FindAll(cardEvent => cardEvent.Player.Equals(playerData.Key.Name))
                    .Count;

                playerData.Value.YellowCards = cardCount;
            });
        }

        private void GetPlayerGamesPlayedCount(List<MatchData> matchData)
        {
            List<TeamEvent> inSubs = ExtractTeamEvents(matchData, "substitution-in");

            playersRankingData.ToList().ForEach(playerData =>
            {
                int inStartingElevenCount = PlayerStartingElevenCount(matchData, playerData.Key);

                int playedAsSubCount = inSubs
                    .FindAll(sub => sub.Player.Equals(playerData.Key.Name))
                    .Count();

                playerData.Value.GamesPlayed = inStartingElevenCount + playedAsSubCount;
            });

        }

        private int PlayerStartingElevenCount(List<MatchData> matchData, MatchPlayer player)
        {
            int count = 0;
            matchData.ForEach(match =>
            {
                if (match.HomeTeam.Code == fifaCode)
                {
                    if (match.HomeTeamStatistics.StartingEleven.Contains(player))
                    {
                        count++;
                    }
                }

                if (match.AwayTeam.Code == fifaCode)
                {
                    if (match.AwayTeamStatistics.StartingEleven.Contains(player))
                    {
                        count++;
                    }
                }
            });

            return count;
        }

        private async void PrepareData()
        {
            try
            {
                if (fifaCode != "")
                {
                    List<MatchData> matchData = await this.worldCupServiceAsync
                        .GetMatchByCountryCodeAsync(fifaCode);

                    HashSet<MatchPlayer> matchPlayers = ExtractPlayers(matchData, fifaCode);
                    matchPlayers.ToList().ForEach(
                        player => playersRankingData.Add(player, new PlayerRankingCriteria()));

                    this.yellowCards = ExtractTeamEvents(matchData, "yellow-card");
                    this.goalEvents = ExtractTeamEvents(matchData, "goal");

                    GetPlayersYellowCardCount();
                    GetPlayersGoalCount();
                    GetPlayerGamesPlayedCount(matchData);
                    PopulatePanel();
                }
            }
            catch (Exception)
            {
                ErrorUtil.ShowErrorMessageBox();
            }

        }

        private void PopulatePanel()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Image"));
            dt.Columns.Add(new DataColumn("Name"));
            dt.Columns.Add(new DataColumn("Yellow cards"));
            dt.Columns.Add(new DataColumn("Games Played"));
            dt.Columns.Add(new DataColumn("Goals"));


            pnlRankings.Controls.Clear();
            foreach (KeyValuePair<MatchPlayer, PlayerRankingCriteria> entry in playersRankingData)
            {
                RankingPlayerItemUc rankedUc = new RankingPlayerItemUc();
                rankedUc.SetName(entry.Key.Name);
                rankedUc.SetYellowCards(entry.Value.YellowCards);
                rankedUc.SetPlayedGameCount(entry.Value.GamesPlayed);
                rankedUc.SetGoals(entry.Value.GoalsScored);
                pnlRankings.Controls.Add(rankedUc);
                ImageUtils.SetSavedImageIfExists(rankedUc, (entry.Key.Name));
            }
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

        private List<TeamEvent> ExtractTeamEvents(List<MatchData> matchData, string eventType)
        {

            IEnumerable<TeamEvent> teamEvent = matchData.SelectMany(match =>
            {
                if (match.HomeTeam.Code == fifaCode)
                {

                    return match.HomeTeamEvents.FindAll(
                       matchEvent => matchEvent.TypeOfEvent.Equals(eventType));
                }

                if (match.AwayTeam.Code == fifaCode)
                {
                    return match.AwayTeamEvents.FindAll(
                      matchEvent => matchEvent.TypeOfEvent.Equals(eventType));
                }

                return null;

            });

            return teamEvent.ToList();
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
       

        private void SortByYellowCards()
        {
            playersRankingData = playersRankingData
                           .OrderBy(entry => -entry.Value.YellowCards)
                           .ToDictionary(entry => entry.Key, entry => entry.Value);
        }

        private void SortByGoalsScored()
        {
            playersRankingData = playersRankingData
                         .OrderBy(entry => -entry.Value.GoalsScored)
                         .ToDictionary(entry => entry.Key, entry => entry.Value);
        }


        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {


            Bitmap bmp = new Bitmap(this.Width, this.Height);
            for (int i = 0; i < pnlRankings.Controls.Count; i++)
            {
                
                pnlRankings.Controls[i].DrawToBitmap(bmp, new Rectangle
                {
                    X = 0,
                    Y = i * Height,
                    Width = this.Width,
                    Height = this.Height
                });

                e.Graphics.DrawImage(bmp, new Point
                {
                    X = e.MarginBounds.X,
                    Y = e.MarginBounds.Y,

                });
            }      
        }

        private void printDocument1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
    }
}
