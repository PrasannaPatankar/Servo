using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.PayPal.Android;

namespace ServoIO.Droid
{
    [Activity(Label = "Servo", Icon = "@drawable/io", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    //[Activity(Label = "ServoIO", Icon = "@drawable/io", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            OxyPlot.Xamarin.Forms.Platform.Android.PlotViewRenderer.Init();
            Xamarin.Forms.DataGrid.DataGridComponent.Init();
            LoadApplication(new App());

            //APP - 80W284485P519543T

            //CrossPayPalManager.Init(new PayPalConfiguration(
            //                                    PayPalEnvironment.NoNetwork,
            //                                    "ARzFmuX_3AyV6UiS5msSlHDuDpKD7zOfvFe34hqaupyqPm_ZuN4S4mdfALRz2oOEE5SNQJbvCVysxLYx"
            //                                    )
            //{
            //    //If you want to accept credit cards
            //    AcceptCreditCards = true,
            //    //Your business name
            //    MerchantName = "Test Store",
            //    //Your privacy policy Url
            //    MerchantPrivacyPolicyUri = "https://www.example.com/privacy",
            //    //Your user agreement Url
            //    MerchantUserAgreementUri = "https://www.example.com/legal",

            //    // OPTIONAL - ShippingAddressOption (Both, None, PayPal, Provided)
            //    ShippingAddressOption = ShippingAddressOption.Both,

            //    // OPTIONAL - Language: Default languege for PayPal Plug-In
            //    Language = "es",

            //    // OPTIONAL - PhoneCountryCode: Default phone country code for PayPal Plug-In
            //    // PhoneCountryCode = "+91",
            //}
            //                            );

        }
    }
}

