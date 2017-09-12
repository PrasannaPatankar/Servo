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
    public partial class MenuHide : ContentPage
    {
        public MenuHide()
        {
            InitializeComponent();
            var hide = hideclick;
            hide.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await ShowHideClickAsync()),

            });
            //var sh = show;
            ImageOne.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>ShowClick()),

            });
        }

        public async Task ShowHideClickAsync()
        {
            //var clickFlag=true;

            //if ( clickFlag==true)
            //{
            //    ImageOne.IsVisible = true;
            //    ImageTwo.IsVisible = true;
            //   clickFlag = false;
            //}
            //else
            //{
            //    if (clickFlag == false)
            //    {
            //        ImageOne.IsVisible = false;
            //        ImageTwo.IsVisible = false;
            //       // clickFlag = false;
            //    }
            //}

            var clickFlag = true;
            if (ImageOne.IsVisible == true || ImageTwo.IsVisible == true)
            {
                clickFlag = false;

                ImageOne.IsVisible = false;
                ImageTwo.IsVisible = false;
            }
            else
            {
               
                await Task.Delay(200);
                ImageTwo.IsVisible = true;
                await Task.Delay(400);
                ImageOne.IsVisible = true;
                clickFlag = true;
            }
        }

        public void ShowClick()
        {
            Navigation.PushAsync(new LedgerReportView());
        }
    }
}
