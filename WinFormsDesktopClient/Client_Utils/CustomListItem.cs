using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsDesktopClient.Client_Utils
{
    class CustomListItem
    {
        public int Value { get; set; }

        public string Text { get; set; }

        public CustomListItem(int value, string text)
        {
            this.Value = value;
            this.Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
