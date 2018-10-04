using Rg.Plugins.Popup.Extensions;
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
    public partial class SSRPerformanceSalePieChartLtr : ContentPage
    {
        public SSRPerformanceSalePieChartLtr()
        {
            try
            {
                InitializeComponent();
                BindingContext = new SSRPerformanceSalePieChartLtrViewModel();
            }
            catch (Exception ex)
            {
                var page = new ErrorMsg(ex.Message);
                Navigation.PushPopupAsync(page);
            }
        }
    }
}