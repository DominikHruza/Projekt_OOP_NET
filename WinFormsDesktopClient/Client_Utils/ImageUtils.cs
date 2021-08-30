using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace WinFormsDesktopClient.Client_Utils
{
    public static class ImageUtils
    {
        public static void SetSavedImageIfExists(UserControl player, string playerName)
        {
            List<string> imgList = Directory.GetFiles(AppConstants.IMAGE_SAVE_FOLDER_PATH).ToList();
            imgList.ForEach(imgPath =>
            {
                string playerNameFromString = ParseFromImagePath(imgPath);
                if (playerName.Equals(playerNameFromString))
                {
                    PictureBox playerPictureBox = (PictureBox)player.Controls.Find("imgPlayer", true).First();
                    playerPictureBox.ImageLocation = imgPath;

                };
            });
        }

       

        public static string ParseFromImagePath(string imgPath)
        {
            string imgName = imgPath.Substring(imgPath.LastIndexOf(@"\")).Replace(@"\", "");
            string[] playerNameStrings = imgName.Split('_', '.');
            return playerNameStrings[0] + " " + playerNameStrings[1];
        }
    }
}
