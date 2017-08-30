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
    public partial class SSRPerformanceChartTabbed : TabbedPage
    {
        public SSRPerformanceChartTabbed ()
        {
            try
            {
                InitializeComponent();                
                Children.Add(new SSRperformanceSalesPieChart());
                Children.Add(new SSRPerformanceSalePieChartLtr());
                Children.Add(new SSRPerformanceChart());
            }
            catch (Exception ex)
            {
                var page = new ErrorMsg(ex.Message);
                Navigation.PushPopupAsync(page);
            }
        }
    }
}