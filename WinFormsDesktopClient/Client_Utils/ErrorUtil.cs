
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsDesktopClient.Client_Utils
{
    class ErrorUtil
    {
        private const string GENERIC_MSG = "Something went wrong, try again!";
        private const string GENERIC_SHUTDOWN_MSG = "Something went wrong, restart application!";

        public static void ShowErrorMessageBox(string msg = GENERIC_MSG)
        {        
            MessageBox.Show(string.Format(msg));     
        }

        public static void ShowErrorMsgAndCloseApp(string msg = GENERIC_SHUTDOWN_MSG)
        {
            MessageBox.Show(string.Format(msg));
            Application.Exit();
        }
    }
}
