using ServoIO.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ServoIO.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SSRIncentiveGraphical : ContentPage
    {
        private SSRIncentiveGraphicalViewModel viewModel;
        public SSRIncentiveGraphical ()
		{
			InitializeComponent ();
            customGrid.ItemTemplate = typeof(SubControlsView);
            this.BindingContext = new SSRIncentiveGraphicalViewModel(Navigation);
            viewModel = (SSRIncentiveGraphicalViewModel)this.BindingContext;
        }

        
    }
}