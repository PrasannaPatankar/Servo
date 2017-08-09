using ServoIO.Common;
using ServoIO.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ServoIO.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async Task entSubmit_ClickedAsync(object sender, EventArgs e)
        {
            using (var scope = new ActivityIndicatorScope(syncIndicator, true, vwLoading))
            {
                await GetPSRrport();
                Application.Current.MainPage = new MasterDetailPageIO();
            }
                
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            //stkMain.TranslateTo(0, 50, 2000, Easing.BounceIn);
            //stkMain.TranslateTo(0, 200, 2000, Easing.BounceOut);
            //stkMain.ScaleTo(2, 2000, Easing.CubicIn);
            //stkMain.ScaleTo(2, 2000, Easing.CubicInOut);
            //stkMain.RotateTo(360, 2000, Easing.SinInOut);
            //stkMain.ScaleTo(1, 2000, Easing.CubicOut);
            //stkMain.TranslateTo(0, -200, 2000, Easing.BounceOut);

        }

        public async Task GetPSRrport()
        {
            try
            {
                var ds = await ReportService.GetPrimarySecondaryReport("2014");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }



}
