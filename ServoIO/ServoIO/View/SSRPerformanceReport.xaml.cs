using Microcharts;
using Microcharts.Forms;
using ServoIO.ViewModel;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;


namespace ServoIO.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SSRPerformanceReport : ContentPage
    {
        public SSRPerformanceReportViewModel viewModel { get; set; }
        public List<Entry> entries; 

        public SSRPerformanceReport()
        {
            InitializeComponent();
            customGrid.ItemTemplate = typeof(PerformanceView);
            this.BindingContext = new SSRPerformanceReportViewModel();
            viewModel = (SSRPerformanceReportViewModel)this.BindingContext;
            viewModel.OnReportChanged += ViewModel_OnReportChanged;
           
        }

       
        private void ViewModel_OnReportChanged(List<Common.SSRPerformance> obj)
        {
            entries = new List<Entry> { };

            if (obj != null)
            {
                foreach (var item in obj)
                {
                    entries.Add(new Entry(Convert.ToInt64(item.SaleInRs.Substring(0, 3)))
                    {
                        Label = item.SaleInRs,
                        TextColor = SKColor.Parse("#4291c1"),
                        Color = SKColor.Parse("#4291c1"),
                        ValueLabel = item.EmployeeName,

                    });
                }

                var chart = new BarChart() { Entries = entries };
                this.chartView.Chart = chart;

            }
        }


        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    entries = new List<Entry> { };

        //    if (viewModel.LstSSRPerformance != null)
        //    {
        //        foreach (var item in viewModel.LstSSRPerformance)
        //        {
        //            entries.Add(new Entry(Convert.ToInt64(item.SaleInRs.Substring(0, 3)))
        //            {
        //                Label = item.SaleInRs,
        //                TextColor = SKColor.Parse("#54d25b"),
        //                Color = SKColor.Parse("#54d25b"),
        //                ValueLabel = item.EmployeeName,

        //            });
        //            //entries.Add(new Entry(Convert.ToInt64(item.SaleInLtr.Substring(0, 3)))
        //            //{
        //            //    Label = item.SaleInLtr,
        //            //    TextColor = SKColor.Parse("#54d25b"),
        //            //    Color = SKColor.Parse("#54d25b"),
        //            //    ValueLabel = "Sale in Ltr",

        //            //});
        //        }

        //        var chart = new BarChart() { Entries = entries };
        //        this.chartView.Chart = chart;
        //    }
        //}
    }
}