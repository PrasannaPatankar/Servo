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
    public partial class LedgerReportView : ContentPage
    {
        private LedgerReportViewModel viewModel;
        public LedgerReportView()
        {
            try
            {
                InitializeComponent();
               // DynamicGrid.ItemTemplate = typeof(SubControlsView);
                this.BindingContext = new LedgerReportViewModel();
                viewModel = (LedgerReportViewModel)this.BindingContext;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
