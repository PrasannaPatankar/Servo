using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ServoIO.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScrollableDashboard : ContentPage
    {
        //public ScrollableDashboardViewModel viewModel { get; set; }
        public ScrollableDashboard()
        {
            InitializeComponent();
            //DashboardGrid.ItemTemplate = typeof(DashboardTiles);
            // this.BindingContext = new ScrollableDashboardViewModel();
            //viewModel = (ScrollableDashboardViewModel)this.BindingContext;
        }


        public void PerformanceReportTapped(object sender, EventArgs args)
        {
            Navigation.PushAsync(new SSRPerformanceReport());
        }

        public void IncentiveReportTapped(object sender, EventArgs args)
        {
            Navigation.PushAsync(new SSRIncentiveGraphical());
        }

        public void AnimatedChartsTapped(object sender, EventArgs args)
        {
            Navigation.PushAsync(new AnimatedCharts());
        }

        public void PrimarySecChartTapped(object sender, EventArgs args)
        {
            Navigation.PushAsync(new PrimarySecondaryReport());
        }

        public void LedgerReportTapped(object sender, EventArgs args)
        {
            Navigation.PushAsync(new LedgerReportView());
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
           
        }
    }

}