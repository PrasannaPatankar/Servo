using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ServoIO.ViewModel;
using ServoIO.Common;

namespace ServoIO.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public DashboardViewModel viewModel { get; set; }
        public Dashboard()
        {
            var YearList = new List<string>();
            YearList.Add("2012");
            YearList.Add("2013");
            YearList.Add("2014");
            YearList.Add("2015");
            YearList.Add("2016");
            YearList.Add("2017");

            InitializeComponent();
            pkrYear.ItemsSource = YearList;
            pkrYear.SelectedIndex = 0;
            this.BindingContext = new DashboardViewModel(pkrYear.SelectedItem.ToString());
            viewModel = (DashboardViewModel)this.BindingContext;

        }
        public async Task pkrYear_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            try
            {
                if (viewModel != null) 
                using (var scope = new ActivityIndicatorScope(syncIndicator, true, vwLoading))
                {
                    await viewModel.CreateBarChartAsync(false, "Year By Charts", pkrYear.SelectedItem.ToString());

                }
            }
            catch (Exception ex)
            {
                //await DisplayAlert("", ex.Message, "Ok");
            }
        }

        //protected override void OnAppearing()
        //{
        //    try
        //    {
        //        base.OnAppearing();
        //        this.Animate("", (s) => Layout(new Rectangle(X, (1 - s) * Height, Width, Height)), 0, 600, Easing.SpringIn, null, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //}

        //protected override void OnDisappearing()
        //{
        //    try
        //    {
        //        base.OnDisappearing();
        //        this.Animate("", (s) => Layout(new Rectangle(X, (s - 1) * Height, Width, Height)), 0, 600, Easing.SpringIn, null, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //}
    }
}