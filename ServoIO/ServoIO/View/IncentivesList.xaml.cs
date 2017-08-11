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
                this.BindingContext = new IncentivesListViewModel("10-08-2014", "10-08-2017");
                viewModel = (IncentivesListViewModel)this.BindingContext;
            }
            catch (Exception ex)
            {
                DisplayAlert("", ex.Message, "Ok");
            }
            
        }
    }
}