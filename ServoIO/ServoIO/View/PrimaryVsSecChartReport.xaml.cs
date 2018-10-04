using Microcharts;
using ServoIO.Common;
using ServoIO.Service;
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
    public partial class PrimaryVsSecChartReport : ContentPage
    {
        List<PrimarySecReport> Rpt = new List<PrimarySecReport>();
        public List<Entry> entries;

        //private PrimaryVsSecChartReportViewModel _ViewModel;
        public PrimaryVsSecChartReport()
        {
            try
            {
                
                InitializeComponent();
                PrimaryVsSecChart.BindingContext = this;
                    //this.BindingContext = new PrimaryVsSecChartReportViewModel();
                    //_ViewModel = (PrimaryVsSecChartReportViewModel)this.BindingContext;

                    //Task.Factory.StartNew(async () =>
                    //{
                    //Rpt = await ReportService.GetPrimarySecondaryReport("2014");
                    entries = new List<Entry>
                    {
                        new Entry(2002)
                        {

                            Label = "January",
                            ValueLabel =  "2002",
                            Color  = SKColor.Parse("#266489"),
                            TextColor=SKColor.Parse("#266489")
                         },
                        new Entry(40230)
                        {
                            Label = "February",
                            ValueLabel = "40230",
                            Color = SKColor.Parse("#68B9C0"),
                        },
                        new Entry(-10330)
                        {
                            Label = "March",
                            ValueLabel = "-10330",
                            Color = SKColor.Parse("#90D585"),
                        },
                          new Entry(2002)
                        {

                            Label = "April",
                            ValueLabel = "2002",
                            Color  = SKColor.Parse("#feafa0"),
                            TextColor=SKColor.Parse("#feafa0")
                         },
                        new Entry(40230)
                        {
                            Label = "May",
                            ValueLabel = "40230",
                            Color = SKColor.Parse("#fc616f"),
                        },
                        new Entry(-10330)
                        {
                            Label = "June",
                            ValueLabel = "-10330",
                            Color = SKColor.Parse("#fc616f"),
                        },
                          new Entry(2002)
                        {

                            Label = "July",
                            ValueLabel = "2002",
                            Color  = SKColor.Parse("#26739d"),
                            TextColor=SKColor.Parse("#26739d")
                         },
                        new Entry(40230)
                        {
                            Label = "August",
                            ValueLabel = "40230",
                            Color = SKColor.Parse("#ffd248"),
                        },
                        new Entry(-10330)
                        {
                            Label = "September",
                            ValueLabel = "-10330",
                            Color = SKColor.Parse("#ffd248"),
                        },
                          new Entry(2002)
                        {

                            Label = "October",
                            ValueLabel = "2002",
                            Color  = SKColor.Parse("#e81512"),
                            TextColor=SKColor.Parse("#e81512")
                         },
                        new Entry(40230)
                        {
                            Label = "November",
                            ValueLabel = "40230",
                            Color = SKColor.Parse("#ff9369"),
                        },
                        new Entry(-10330)
                        {
                            Label = "December",
                            ValueLabel = "-10330",
                            Color = SKColor.Parse("#89b416"),
                        },
                    };
                
                    //PrimaryVsSecChart.Chart = new RadialGaugeChart { Entries = entries };
                //});

            }
            catch (Exception e)
            {
                throw;
            }

        }

        protected override void OnAppearing()
        {
            PrimaryVsSecChart.Chart = new RadialGaugeChart { Entries = entries };
            //radialGaugeChart.Entries = entries;
            base.OnAppearing();
        }

    }
}