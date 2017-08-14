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
    public partial class PrimarySecondarySaleList : ContentPage
    {
        private PrimarySecondarySaleListViewModel viewModel;
        //private DashboardViewModel VMDashBD = new DashboardViewModel();
        public PrimarySecondarySaleList()
        {
            var YearList = new List<string>();
            YearList.Add("2012");
            YearList.Add("2013");
            YearList.Add("2014");
            YearList.Add("2015");    
            YearList.Add("2016");
            YearList.Add("2017");
            try
            {
                InitializeComponent();
                pkrYear.ItemsSource = YearList;
                pkrYear.SelectedIndex = 0;
                this.BindingContext = new PrimarySecondarySaleListViewModel(pkrYear.SelectedItem.ToString());
                viewModel = (PrimarySecondarySaleListViewModel)this.BindingContext;
            }
            catch (Exception ex)
            {
                DisplayAlert("", ex.Message, "Ok");
            }

        }

        public async Task pkrYear_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            try
            {
                Application.Current.Properties["PropYear"] = pkrYear.SelectedItem.ToString();

                if (viewModel != null) { }
                using (var scope = new ActivityIndicatorScope(syncIndicator, true, vwLoading))
                {
                    await viewModel.GetPSRrport(pkrYear.SelectedItem.ToString());
                    
                }
            }
            catch (Exception ex)
            {
                //await DisplayAlert("", ex.Message, "Ok");
            }
        }

        private async Task lstPrimarySecondarySale_ItemTappedAsync(object sender, ItemTappedEventArgs e)
        {
            try
            {
                PrimarySecReport ObjPS = e.Item as PrimarySecReport;
                await Navigation.PushAsync(new YearlySalesChart(ObjPS));
                lstPrimarySecondarySale.SelectedItem = null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}