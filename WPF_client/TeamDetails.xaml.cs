using Models;
using System;
using System.Collections.Generic;
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

namespace WPF_client
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TeamDetails : Window
    {

        public Team Team { get; set; }

        public TeamDetails()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                FillData();
            }
            catch 
            {

                ErrorUtil.ShowErrorMessageBox();
            }
        }

        public void FillData()
        {
            lbCountry.Content = $"{Team.Country} {Team.FifaCode}";
            lbGames.Content = $"{Team.GamesPlayed}/{Team.Wins}/{Team.Losses}/{Team.Draws}";
            lbGoals.Content = $"{Team.GoalsFor}/{Team.GoalsAgainst}/{Team.GoalDifferential}";
        }

       
    }
}
