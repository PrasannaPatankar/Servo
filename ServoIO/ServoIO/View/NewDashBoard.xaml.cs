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
    public partial class NewDashBoard : ContentPage
    {
        public NewDashBoard()
        {

            InitializeComponent();
            var firstLabel = Firstreport;
            firstLabel.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => PrimarySecondaryClick()),
            });

            var incentivesLabel = Secondreport;
            incentivesLabel.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => IncentiveClick())
            });

        }

        public void IncentiveClick()
        {
            try
            {
                Navigation.PushAsync(new IncentivesList());

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void PrimarySecondaryClick()
        {
            // Application.Current.MainPage = new MasterDetailPageIO();
            try
            {
                Navigation.PushAsync(new MasterDetailPageIODetail());
            }
            catch (Exception)
            {

                throw;
            }

        }


        //private void btnReports_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Navigation.PushAsync(new MasterDetailPageIODetail());
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}



        //private void btnIncentives_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Navigation.PushAsync(new IncentivesList());
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}
    }
}
