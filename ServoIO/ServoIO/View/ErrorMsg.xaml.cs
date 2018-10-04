using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServoIO.Animations;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ServoIO.View
{   
    public partial class ErrorMsg : PopupPage
    {
        public ErrorMsg(string ErrorMsg)
        {
            InitializeComponent();
            lblMsg.Text = ErrorMsg;
        }

        private void OnClose(object sender, EventArgs e)
        {
            PopupNavigation.PopAsync();
        }
    }
}