using DAL.Models;
using DAL.Protocols;
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
    public partial class TeamsTabUC : UserControl
    {
        private Team selectedTeam;
        private List<Team> teams = new List<Team>();
        private IWorldCupServiceAsync worldCupServiceAsync;
       
        public TeamsTabUC()
        {
            InitializeComponent();
                   
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
                    MessageBox.Show($"{e.Message} { e.StackTrace}" );                 
                }
                
            };
        }


        private void TeamsTabUC_Load(object sender, EventArgs e)
        {
            try
            {
                this.Dock = DockStyle.Fill;
                SetService();
                FillTeamsDropdown();
            }
            catch (Exception)
            {
        
            }
         
           
        }
        private async void FillTeamsDropdown()
        {
            try
            {
                this.teams = await worldCupServiceAsync.GetAllTeamsAsync();
                this.teams.ForEach(team => cbTeams.Items.Add(team));

                if (GetSavedTeamFromFile() != null)
                {
                    SetSelectectedItem(GetSavedTeamFromFile());
                }
            }
            catch (Exception e)
            {
                ErrorUtil.ShowErrorMessageBox();
            }

        }

        private void cbTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedTeam = cbTeams.SelectedItem as Team;
            SaveSelectedTeamFifaCode();
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
                cbTeams.SelectedItem = selectedTeam;
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

                if(favoriteTeamCode == "")
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
    }
}
