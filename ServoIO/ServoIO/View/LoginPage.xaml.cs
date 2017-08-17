using ServoIO.Common;
using ServoIO.ViewModel;
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
        public LoginViewModel _ViewModel { get; set; }
        public LoginPage()
        {
           
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
            _ViewModel = (LoginViewModel)this.BindingContext;
            ChangeBgAnimation();
        }


        public void ChangeBgAnimation()
        {
            var repeatCount = 0;
            this.StkMain.Animate(
                name: "ChangeBg",
            // create the animation object and callback
            animation: new Xamarin.Forms.Animation((val) => {
                    // val will be a from 0 - 1 and can use that to set a BG color
                    if (repeatCount == 0)
                    this.StkMain.BackgroundColor = Color.FromRgb(1 - val, 1 - val, 1 - val);
                else
                    this.StkMain.BackgroundColor = Color.FromRgb(val, val, val);
            }),

            // set the length
            length: 800,

            // set the repeat action to update the repeatCount
            finished: (val, b) => {
                repeatCount++;
            },

            // determine if we should repeat
            repeat: () => {
                return repeatCount < 1;
            }
                );
        }
        //private void validPassword(object sender, TextChangedEventArgs e)
        //{
        //    entPassword.Text = CheckLength(entPassword.Text, 10);
        //}
        //private string CheckLength(string str, int reqLength)
        //{
        //    try
        //    {
        //        if (str.Length >= reqLength)
        //        {
        //            return str.Substring(0, reqLength);
        //        }
        //        else
        //        {
        //            return str;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string ab = ex.ToString();
        //        return null;
        //    }
        //}

        //private void entSubmit_Clicked(object sender, EventArgs e)
        //{


        //    using (var scope = new ActivityIndicatorScope(syncIndicator, true, vwLoading))
        //        Application.Current.MainPage = new MasterDetailPageIO();
        //}


        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    entSubmit.AnchorX = 0.48;
        //    entSubmit.AnchorY = 0.48;

        //StkMain.TranslateTo(0, 50, 2000, Easing.BounceIn);
        //StkMain.TranslateTo(0, 200, 2000, Easing.BounceOut);
        //StkMain.ScaleTo(2, 2000, Easing.CubicIn);
        //StkMain.ScaleTo(2, 2000, Easing.CubicInOut);
        //StkMain.RotateTo(360, 2000, Easing.SinInOut);
        //StkMain.ScaleTo(1, 2000, Easing.CubicOut);
        //StkMain.TranslateTo(0, -200, 2000, Easing.BounceOut);
        //  }
    }
    


}
