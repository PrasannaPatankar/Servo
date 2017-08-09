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
                using (var scope = new ActivityIndicatorScope(syncIndicator, true, vwLoading))
                {
                    this.BindingContext = new PrimarySecondarySaleListViewModel(pkrYear.SelectedItem.ToString());
                    viewModel = (PrimarySecondarySaleListViewModel)this.BindingContext;
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("", ex.Message, "Ok");
            }
            
        }
    }
}