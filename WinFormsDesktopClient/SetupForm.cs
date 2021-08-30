using DAL.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
using WinFormsDesktopClient.Properties;


namespace WinFormsDesktopClient
{
    public partial class AppSetupDialog : Form
    {
        
        public AppSetupDialog()
        {
            InitializeComponent();
            LoadLanguageDropdown();
            LoadContestDropdown();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var selectedContestItem = ddlContest.SelectedItem as CustomListItem;
            var selectedLanguageItem = ddlLang.SelectedItem as CustomListItem;

            if(selectedContestItem == null || selectedLanguageItem == null)
            {
                MessageBox.Show(string.Format("Pogresan unos!"));
                Application.Exit();
                return;
            }

            string lang = GetSelectedOption(
                selectedLanguageItem, typeof(LanguageOption));

            string contest = GetSelectedOption(
                selectedContestItem, typeof(ContestType));

            AppSettingUtil.SaveOptionToSetupFile(
                lang,
               AppConstants.LANGUAGE_SETTINGS_PATH);

            AppSettingUtil.SaveOptionToSetupFile(
                contest, 
                AppConstants.CONTEST_SETTINGS_PATH);
        }

      
        private string GetSelectedOption(CustomListItem selectedOption, Type optionType)
        {
            string option = null;
            foreach (int value in Enum.GetValues(optionType))
            {
                if (value == selectedOption.Value)
                {
                    option = Enum.GetName(optionType, value);
                }
            }

            return option;
        }

        private void LoadLanguageDropdown()
        {
            
            ddlLang.Items.Add(new CustomListItem(
                (int)LanguageOption.hr, 
                "Hrvatski"));

            ddlLang.Items.Add(new CustomListItem(
                (int)LanguageOption.en, 
                "English"));
        }

        private void LoadContestDropdown()
        {
            ddlContest.Items.Add( new CustomListItem(
                (int)ContestType.WORLDCUP_MEN_2018, 
                "World Cup 2018 Men"));

            ddlContest.Items.Add(new CustomListItem(
                (int)ContestType.WORLDCUP_WOMEN_2019,
                "World Cup 2019 Women"));
        }
    }
}
