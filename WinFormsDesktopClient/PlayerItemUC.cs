using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;
using Utilities.SetupUtils;

namespace WinFormsDesktopClient
{
    public partial class PlayerItemUC : UserControl
    {
        public PlayerItemUC()
        {
            InitializeComponent();
        }

        public PlayerItemUC(string name, long number, string position, string captain )
        {
            InitializeComponent();
            lblName.Text = name;
            lblShirtNumber.Text = number.ToString();
            lblPosition.Text = position;
            lblCaptain.Text = captain;
            imgPlayer.ImageLocation = AppConstants.DEFAULT_PLAYER_IMG_PATH;          
        }

        public PlayerItemUC(PlayerItemUC player)
        {
            InitializeComponent();
            lblName.Text = player.lblName.Text;
            lblShirtNumber.Text = player.lblShirtNumber.Text;
            lblPosition.Text = player.lblPosition.Text;
            lblCaptain.Text = player.lblCaptain.Text;
            imgPlayer.ImageLocation = AppConstants.DEFAULT_PLAYER_IMG_PATH;       
        }

        private void PlayerItemUC_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.pnlPlayerData.Controls)
            {
                control.MouseDown += pnlPlayerData_MouseDown;
               
            }
        }

        public MatchPlayer GetMatchPlayerFromControl()
        {
            return new MatchPlayer(
                lblName.Text,
                lblCaptain.Text == "Yes" ?  true : false, 
                int.Parse(lblShirtNumber.Text), 
                lblPosition.Text);
        }

        private void pnlPlayerData_MouseDown(object sender, MouseEventArgs e)
        {
           if(e.Button == MouseButtons.Left)
           {
                this.DoDragDrop(this, DragDropEffects.Move);
           }

            if (sender.GetType() == typeof(CheckBox))
            {
                this.checkBoxPlayer.Checked = !this.checkBoxPlayer.Checked;
            }

            if (sender.GetType() == typeof(PictureBox))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Slike|*.jpg;*.jpeg;*.png;*.bmp|Sve datoteke|*.*";
                openFileDialog.InitialDirectory = Application.StartupPath;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                   
                    string imageFilename = openFileDialog.FileName;
                    string imgExtension = imageFilename.Substring(imageFilename.LastIndexOf('.'));

                    Image image = Image.FromFile(imageFilename);
                    imgPlayer.Image = image;

                    string[] playerFullname = lblName.Text.Split(' ');

                    string savedImageFilename = 
                        AppConstants.IMAGE_SAVE_FOLDER_PATH + 
                        @"\" + $"{playerFullname[0]}_{playerFullname[1]}" +
                        imgExtension.ToLower();


                    string pathToOriginDir = 
                        AppSettingUtil.GetBaseSaveDirPath() + 
                        @"\" + 
                        savedImageFilename;



                    image.Save(pathToOriginDir, image.RawFormat);
                    image.Save(savedImageFilename, image.RawFormat);

                }
            }
        }

        public void SetFavouriteIcon()
        {
            Image favImage = Image.FromFile("assets/fav_icon.jpg");
            iconFavourite.Image = favImage;
        }

        private void pnlPlayerData_Click(object sender, EventArgs e)
        {
           
        }
    }
}
