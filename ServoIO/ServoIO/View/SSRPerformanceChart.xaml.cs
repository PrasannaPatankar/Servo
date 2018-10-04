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
    public partial class SSRPerformanceChart : ContentPage
    {
        public SSRPerformanceChart()
        {
            try
            {
                InitializeComponent();
                BindingContext = new SSRPerformanceChartViewModel();
            }
            catch (Exception ex)
            {
                var page = new ErrorMsg(ex.Message);
                Navigation.PushPopupAsync(page);
            }

        }
    }
}