using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ServoIO.ViewModel;

namespace ServoIO.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public DashboardViewModel viewModel { get; set; }
        public Dashboard()
        {
            InitializeComponent();
            this.BindingContext = new DashboardViewModel();
            viewModel = (DashboardViewModel)this.BindingContext;
        }
    }
}