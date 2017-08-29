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
    public partial class SSRPerformanceTabbed : TabbedPage
    {
        public SSRPerformanceTabbed()
        {
            try
            {
                InitializeComponent();
                Children.Add(new SSRPerformanceReport());
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