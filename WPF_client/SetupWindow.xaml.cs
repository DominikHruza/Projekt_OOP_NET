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
using System.Windows.Shapes;
using Utilities;
using Utilities.OptionUtils;
using Utilities.SetupUtils;

namespace WPF_client
{
    /// <summary>
    /// Interaction logic for SetupWindow.xaml
    /// </summary>
    public partial class SetupWindow : Window
    {
        private string appLanguage = "";
        private string selectedContest = "";

        public SetupWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            try
            {
                LoadSettingsFromFile();
                LoadLanguageDropdown();
                LoadContestDropdown();
            }
            catch
            {
                ErrorUtil.ShowErrorMsgAndCloseApp();
            }
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            if (!IsAppConfigured())
            {
                Application.Current.Shutdown();
                return;
            }

            this.Close();
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedContestItem = cbContest.SelectedItem as ComboBoxItem;
                var selectedLanguageItem = cbLanguage.SelectedItem as ComboBoxItem;


                if (selectedContestItem == null || selectedLanguageItem == null)
                {
                    MessageBox.Show(string.Format("Pogresan unos!"));

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

                SaveResolutionSettings();

                this.Close();

                if (MessageBox.Show(
                "Restart your app in order for changes to take effect!",
                "Confirm Exit", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {

                    Application.Current.Shutdown();
                }

            }
            catch
            {

                ErrorUtil.ShowErrorMsgAndCloseApp();
            }
        }

        private void SaveResolutionSettings()
        {
            try
            {
                string fullName = Directory.GetParent(
                Directory.GetCurrentDirectory())
                .Parent.FullName;

                if (cbResolutions.SelectedItem != null)
                {
                    File.WriteAllText(fullName + @"\resolution.txt", ((ComboBoxItem)cbResolutions.SelectedItem).Content.ToString());
                }


            }
            catch
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private string GetSelectedOption(ComboBoxItem selectedOption, Type optionType)
        {
            string option = null;
            foreach (int value in Enum.GetValues(optionType))
            {
                if (value == (int)selectedOption.Tag)
                {
                    option = Enum.GetName(optionType, value);
                }
            }

            return option;
        }

        private void LoadContestDropdown()
        {

            var menWC = new ComboBoxItem();
            var womenWC = new ComboBoxItem();

            menWC.Content = "World Cup 2018 Men";
            menWC.Tag = (int)ContestType.WORLDCUP_MEN_2018;

            womenWC.Content = "World Cup 2019 Women";
            womenWC.Tag = (int)ContestType.WORLDCUP_WOMEN_2019;

            cbContest.Items.Add(menWC);
            cbContest.Items.Add(womenWC);
        }


        private void LoadLanguageDropdown()
        {

            var english = new ComboBoxItem();
            var croatian = new ComboBoxItem();

            english.Content = "English";
            english.Tag = (int)LanguageOption.en;

            croatian.Content = "Hrvatski";
            croatian.Tag = (int)LanguageOption.hr;

            cbLanguage.Items.Add(croatian);
            cbLanguage.Items.Add(english);
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
    }
}
