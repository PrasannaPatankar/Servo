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
    public partial class MasterDetailPageIODetail : ContentPage
    {
        public DetailViewModel viewModel { get; set; }
        public MasterDetailPageIODetail()
        {
            InitializeComponent();
            this.BindingContext = new DetailViewModel();
            viewModel = (DetailViewModel)this.BindingContext;
        }

        private void btnSubmit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new TestPage());
        }
    }
}