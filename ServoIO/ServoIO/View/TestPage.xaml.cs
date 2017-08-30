using Rg.Plugins.Popup.Extensions;
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
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();
            var firstLabel = PandSSales;
            firstLabel.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => PrimarySecondaryClick()),
            });

            var incentivesLabel = IncentiveRepot;
            incentivesLabel.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => IncentiveClick())
            });

            var ssrperformance = SSRPerformance;
            ssrperformance.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => SSRPerformanceClicked())
            });

            var ssrperformancegrid = SSRPerformanceGrid;
            ssrperformancegrid.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => SSRPerformanceGridClicked())
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

        public void SSRPerformanceGridClicked()
        {
            try
            {
                Navigation.PushAsync(new SSRPerformanceGridView());
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

        public void SSRPerformanceClicked()
        {
            try
            {
                Navigation.PushAsync(new SSRPerformanceReport());

            }
            catch (Exception ex)
            {
                var page = new ErrorMsg(ex.Message);
                Navigation.PushPopupAsync(page);
            }
        }

    }
}
