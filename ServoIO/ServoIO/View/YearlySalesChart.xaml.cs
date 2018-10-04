using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ServoIO.ViewModel;
using ServoIO.Common;
using Rg.Plugins.Popup.Extensions;

namespace ServoIO.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class YearlySalesChart : ContentPage
	{
        public YearlySalesChartViewModel viewModel { get; set; }
        public YearlySalesChart (PrimarySecReport ObjPS)
		{
			InitializeComponent ();
            try
            {
                this.BindingContext = new YearlySalesChartViewModel(ObjPS);
                viewModel = (YearlySalesChartViewModel)this.BindingContext;
            }
            catch (Exception ex)
            {
                var page = new ErrorMsg(ex.Message);
                Navigation.PushPopupAsync(page);
            }

        }
	}
}   