using Microcharts;
using ServoIO.Common;
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
    public partial class SSRReports : ContentPage
    {
        public List<Entry> entries = new List<Entry>
            {  
            };
        public SSRReports()
        {
            InitializeComponent();
        }
        public SSRReports(object obj)
        {
            InitializeComponent();
            
            var result = obj as IncentiveReport;
            lblEmpName.Text = result.EmpName;

            entries.Add(new Entry(Convert.ToInt64(result.Basic_Salary))
            {
                Label = result.Basic_Salary,
                TextColor = SKColor.Parse("#54d25b"),
                Color = SKColor.Parse("#54d25b"),
                ValueLabel = "Basic Salary",
               
            });
            entries.Add(new Entry(Convert.ToInt64(result.Cash_Discount))
            {
                Label = result.Cash_Discount,
                TextColor = SKColor.Parse("#3dbac5"),
                Color = SKColor.Parse("#3dbac5"),
                ValueLabel = "Cash Discount"
            });
            entries.Add(new Entry(Convert.ToInt64(result.Cheque_Bounce))
            {
                Label = result.Cheque_Bounce,
                TextColor = SKColor.Parse("#f6841b"),
                Color = SKColor.Parse("#f6841b"),
                ValueLabel = "Cheque Bounce"
            });
            entries.Add(new Entry(Convert.ToInt64(result.Credit_Note))
            {
                Label = result.Credit_Note,
                TextColor = SKColor.Parse("#fb727e"),
                Color = SKColor.Parse("#fb727e"),
                ValueLabel = "Credit Note"
            });
            entries.Add(new Entry(Convert.ToInt64(result.Receipt))
            {
                Label = result.Receipt,
                TextColor = SKColor.Parse("#dd3434"),
                Color = SKColor.Parse("#dd3434"),
                ValueLabel = "Receipt"
            });
            //entries.Add(new Entry(Convert.ToInt64(result.Salary_Incentive))
            //{
            //    Label = "Salary Incentive",
            //    TextColor = SKColor.Parse("#266489"),
            //    Color = SKColor.Parse("#266489"),
            //    ValueLabel = result.Salary_Incentive
            //});
            entries.Add(new Entry(Convert.ToInt64(result.Spacial_Discount))
            {
                Label = result.Spacial_Discount,
                TextColor = SKColor.Parse("#fc616f"),
                Color = SKColor.Parse("#fc616f"),
                ValueLabel = "Spacial Discount"
            });
            //entries.Add(new Entry(Convert.ToInt64(result.Total_Incentive))
            //{
            //    Label = "Total Incentive",
            //    TextColor = SKColor.Parse("#fc616f"),
            //    Color = SKColor.Parse("#fc616f"),
            //    ValueLabel = result.Total_Incentive
            //});
            entries.Add(new Entry(Convert.ToInt64(result.Total_Receipts))
            {
                Label = result.Total_Receipts,
                TextColor = SKColor.Parse("#05aded"),
                Color = SKColor.Parse("#05aded"),
                ValueLabel = "Total Receipts"
            });
            //var chart = new LineChart() { Entries = entries, LineMode = LineMode.Spline, LabelTextSize = 20};
            var chart = new BarChart() { Entries = entries };
            this.chartView.Chart = chart;
          
        }

       
        protected override void OnAppearing()
        {
            //base.OnAppearing();
            //var chart = new BarChart() { Entries = entries };
            //this.chartView.Chart = chart;
        }
    }
}