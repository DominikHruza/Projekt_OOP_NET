using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;
using Utilities.OptionUtils;
using Utilities.SetupUtils;
using WinFormsDesktopClient.Client_Utils;

namespace WinFormsDesktopClient
{
    public partial class MainForm : Form
    {
       

        private string appLanguage = "";
        private string selectedContest = "";
       

        public MainForm()
        {
            AppSettingUtil.SetGlobalization();
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            try
            {
                LoadSettingsFromFile();
                if (!IsAppConfigured())
                {
                    OpenSetupDialog(null);
                }


                this.tabTeams.Controls.Add(new TeamsTabUC());
            }
            catch (Exception)
            {

               
            }
        }

       

        private static void OpenSetupDialog(Button btn)
        {
            var appSetupDialog = new AppSetupDialog();

            if (appSetupDialog.ShowDialog() == DialogResult.Abort && btn.Name != "btnSettingsChange")
            {
                Application.Exit();
            }
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
                MessageBox.Show(e.Message, e.StackTrace);
                
            }     
        }

        private void tabMain_Selected(object sender, TabControlEventArgs e)
        {

            if (tabMain.SelectedTab == tabTeams)
            {
                this.tabTeams.Controls.Clear();
                this.tabTeams.Controls.Add(new TeamsTabUC());
            }

            if (tabMain.SelectedTab == tabPlayers)
            {
                this.tabPlayers.Controls.Clear();
                this.tabPlayers.Controls.Add(new PlayersTabUC());
            }

            if (tabMain.SelectedTab == tabRankingsPlayer)
            {
                this.tabRankingsPlayer.Controls.Clear();
                this.tabRankingsPlayer.Controls.Add(new PlayerRankingsUC());
            }

            if (tabMain.SelectedTab == tabMatchRankings)
            {
                this.tabMatchRankings.Controls.Clear();
                this.tabMatchRankings.Controls.Add(new MatchRankingsTabUC());
            }
        }

        private void btnSettingsChange_Click(object sender, EventArgs e)
        {
            OpenSetupDialog(sender as Button);
            
            Application.Restart();
            Environment.Exit(0);
            ////tabMain.SelectedTab = tabTeams;
            //this.tabTeams.Controls.Clear();
            //this.tabTeams.Controls.Add(new TeamsTabUC());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show(
                    "About to exit program?", 
                    "Confirm Exit", MessageBoxButtons.OKCancel, 
                    MessageBoxIcon.Question) 
                != DialogResult.OK)
                    e.Cancel = true;
            }
        }
    }
}
