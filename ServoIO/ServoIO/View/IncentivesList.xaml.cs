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
    public partial class IncentivesList : ContentPage
    {
        private IncentivesListViewModel viewModel;
        public IncentivesList()
        {
            try
            {
                InitializeComponent();
                DateTime dtFromDate, dtToDate;
                dtFrom.Date = System.DateTime.Now.Date.AddDays(-7000);
                dtFromDate = dtFrom.Date;
                dtToDate = dtTo.Date;
                this.BindingContext = new IncentivesListViewModel(dtFromDate.ToString("MM-dd-yyyy"), dtToDate.ToString("MM-dd-yyyy"));
                viewModel = (IncentivesListViewModel)this.BindingContext;
            }
            catch (Exception ex)
            {
                DisplayAlert("", ex.Message, "Ok");
            }
            
        }

        private void btnSearch_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (dtFrom.Date <= dtTo.Date)
                {
                    this.BindingContext = new IncentivesListViewModel(dtFrom.Date.ToString("MM-dd-yyyy"), dtTo.Date.ToString("MM-dd-yyyy"));
                    viewModel = (IncentivesListViewModel)this.BindingContext;
                }
                else
                {
                    DisplayAlert("", "From date must be less than To date.", "Ok");
                }
                
            }
            catch (Exception ex)
            {
                DisplayAlert("", ex.Message, "Ok");
            }
        }
    }
}