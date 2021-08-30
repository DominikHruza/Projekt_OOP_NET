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
using System.Windows.Shapes;
using Utilities;
using Utilities.SetupUtils;

namespace WPF_client
{
    /// <summary>
    /// Interaction logic for PlayerDetails.xaml
    /// </summary>
    public partial class PlayerDetails : Window
    {
        private string name;
        private MatchData match;
        private List<TeamEvent> matchEvents;

        public PlayerDetails()
        {
            InitializeComponent();
        }

        public PlayerDetails(string playerName, MatchData data)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            name = playerName;
            match = data;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                MatchPlayer selectedPlayer = match.AwayTeamStatistics.StartingEleven
                            .Union(match.HomeTeamStatistics.StartingEleven)
                            .First(player => player.Name.Equals(name));

                matchEvents = match.AwayTeamEvents
                    .Concat(match.HomeTeamEvents).ToList();

                tfName.Content = name;
                tfNum.Content = selectedPlayer.ShirtNumber;
                tfPos.Content = selectedPlayer.Position;
                tfGoals.Content = GetEventCount("goal-penalty", "goal");
                tfCards.Content = GetEventCount("yellow-card");
                SetSavedImageIfExists(name);
            }
            catch 
            {

                ErrorUtil.ShowErrorMessageBox();
            }
        }

        private int GetEventCount(params string[] eventParams)
        {
            int count = 0;
            matchEvents.ForEach(matchevent =>
            {
                foreach (var param in eventParams)
                {
                    if (matchevent.TypeOfEvent == param && matchevent.Player == name)
                    {
                        count++;
                    }
                }

            });

            return count;
        }


        public void SetSavedImageIfExists(string playerName)
        {
            List<string> imgList = Directory.GetFiles(
                AppSettingUtil.GetBaseSaveDirPath() + @"\" + AppConstants.IMAGE_SAVE_FOLDER_PATH).ToList();

            imgList.ForEach(imgPath =>
            {
                string playerNameFromString = ParseFromImagePath(imgPath);
                if (playerName.Equals(playerNameFromString))
                {
                    img.Source = new BitmapImage(new Uri(imgPath));


                };
            });
        }

        private string ParseFromImagePath(string imgPath)
        {
            string imgName = imgPath.Substring(imgPath.LastIndexOf(@"\")).Replace(@"\", "");
            string[] playerNameStrings = imgName.Split('_', '.');
            return playerNameStrings[0] + " " + playerNameStrings[1];
        }

    }
}
