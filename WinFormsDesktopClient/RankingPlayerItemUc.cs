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

namespace WinFormsDesktopClient
{
    public partial class RankingPlayerItemUc : UserControl
    {
        public RankingPlayerItemUc()
        {
            InitializeComponent();
            imgPlayer.ImageLocation = AppConstants.DEFAULT_PLAYER_IMG_PATH;
        }

       
        public void SetName(string name)
        {
            this.lbName.Text = name;
        }

        public void SetImage(string filename)
        {
            this.imgPlayer.Image = Image.FromFile(filename);
        }

        public void SetGoals(int count)
        {
            this.lbGoals.Text = count.ToString();
        }
        public void SetYellowCards(int count)
        {
            this.lbCards.Text = count.ToString();
        }
        public void SetPlayedGameCount(int count)
        {
            this.lbPlayed.Text = count.ToString();
        }

    }

}
