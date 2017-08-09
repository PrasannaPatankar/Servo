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
            try
            {
                InitializeComponent();
                using (var scope = new ActivityIndicatorScope(syncIndicator, true, vwLoading))
                {
                    this.BindingContext = new PrimarySecondarySaleListViewModel();
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