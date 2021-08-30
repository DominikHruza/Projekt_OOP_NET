using Models;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class MatchRankingsTabUC : UserControl
    {

        private IWorldCupServiceAsync worldCupServiceAsync;
        private string fifaCode;
        List<MatchData> sortedMatches = new List<MatchData>();

        public MatchRankingsTabUC()
        {
            InitializeComponent();
            this.fifaCode = AppSettingUtil.GetSettingFromSetupFile(
                                AppConstants.FAVOURITE_TEAM_PATH);
        }

        private void MatchRankingsTabUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            SetService();
            PrepareData();
        }

        private async void PrepareData()
        {
            try
            {
                if (fifaCode != "")
                {
                    List<MatchData> matchData = await this.worldCupServiceAsync
                        .GetMatchByCountryCodeAsync(fifaCode);


                    this.sortedMatches = matchData.OrderBy(match => -match.Attendance).ToList();
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

           

            DataTable dt = new DataTable("Matches");
            dt.Columns.Add(new DataColumn("Attendance"));
            dt.Columns.Add(new DataColumn("Away Team"));
            dt.Columns.Add(new DataColumn("Home Team"));
            foreach (MatchData match in sortedMatches)
            {
                //var matchItem = new MatchRankingItemUc();
                //matchItem.setData(match.Attendance, match.HomeTeam.Country, match.AwayTeam.Country);
                //pnlRankings.Controls.Add(matchItem);
                dt.Rows.Add(match.Attendance, match.HomeTeam.Country, match.AwayTeam.Country);
            }
         
            matchesGridView. DataSource = dt;
            this.Controls.Add(matchesGridView);       
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(this.Width, this.Height);
           

            matchesGridView.DrawToBitmap(bmp, new Rectangle
            {
                X = 0,
                Y = 0,
                Width = this.Width,
                Height = this.Height
            });

            e.Graphics.DrawImage(bmp, new Point
            {
                X = e.MarginBounds.X,
                Y = e.MarginBounds.Y,

            });


          



        }

        private void printDocument1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }


    }
}

