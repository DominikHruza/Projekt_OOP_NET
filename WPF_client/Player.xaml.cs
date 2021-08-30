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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Utilities;
using Utilities.SetupUtils;

namespace WPF_client
{
    /// <summary>
    /// Interaction logic for Player.xaml
    /// </summary>
    public partial class Player : UserControl
    {
        public Player()
        {
            InitializeComponent();
        }

        public void SetNum(long num)
        {
            lbNum.Content = num.ToString();
        }

        public void SetName(string name)
        {
            lbName.Content = name;
        }


        public void SetSavedImageIfExists(string playerName)
        {
            List<string> imgList = Directory.GetFiles(AppSettingUtil.GetBaseSaveDirPath()+ @"\" + AppConstants.IMAGE_SAVE_FOLDER_PATH).ToList();
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

        private void DockPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
