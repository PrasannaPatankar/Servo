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
	public partial class DashboardNew : ContentPage
	{
		public DashboardNew ()
		{
			InitializeComponent ();
            DashboardGrid.ItemTemplate = typeof(DashboardTiles);
            this.BindingContext = new ScrollableDashboardViewModel();
            
		}
	}
}