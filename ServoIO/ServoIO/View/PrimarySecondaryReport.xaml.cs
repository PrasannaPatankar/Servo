using ServoIO.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ServoIO.Common;
using Microcharts;
using SkiaSharp;
using Newtonsoft.Json;
using System.Net.Http;
using Entry = Microcharts.Entry;
using Microcharts.Forms;

namespace ServoIO.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrimarySecondaryReport : ContentPage
    {
        List<Common.PrimarySecReport> ListPS = new List<PrimarySecReport>();

        public PrimarySecondaryReport()
        {
            InitializeComponent();
            List<string> countries = new List<string>
            {
                "2010",
                "2011",
                "2012",
                "2013",
                "2014",
                "2015",
                "2016",
                "2017",
                "2018",
            };
            pikYear.ItemsSource = countries;
        }

        private async Task btnShow_ClickedAsync(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var result = await client.GetAsync(Constants.PrimarySecondaryYearlyReport_List + "/" + pikYear.SelectedItem.ToString() + "");
            result.EnsureSuccessStatusCode();
            string stringJson = await result.Content.ReadAsStringAsync();
            var ObjRoot = JsonConvert.DeserializeObject<List<PrimarySecReport>>(stringJson);

            ListPS = ObjRoot as List<PrimarySecReport>;

            for (int i = 0; i < ListPS.Count; i++)
            {
                List<Entry> entries = new List<Entry> { };
                ChartView _chartview = new ChartView();
                _chartview.HeightRequest = 150;
                _chartview.Margin = 0;

                entries.Add(new Entry(Convert.ToInt64(ListPS[i].January == "" ? "0" : ListPS[i].January))
                {
                    Label = "January",
                    TextColor = SKColor.Parse("#266489"),
                    Color = SKColor.Parse("#266489"),
                    ValueLabel = ListPS[i].January
                });
                entries.Add(new Entry(Convert.ToInt64(ListPS[i].February == "" ? "0" : ListPS[i].February))
                {
                    Label = "February",
                    TextColor = SKColor.Parse("#68B9C0"),
                    Color = SKColor.Parse("#68B9C0"),
                    ValueLabel = ListPS[i].February
                });
                entries.Add(new Entry(Convert.ToInt64(ListPS[i].March == "" ? "0" : ListPS[i].March))
                {
                    Label = "March",
                    TextColor = SKColor.Parse("#90D585"),
                    Color = SKColor.Parse("#90D585"),
                    ValueLabel = ListPS[i].March
                });
                entries.Add(new Entry(Convert.ToInt64(ListPS[i].April == "" ? "0" : ListPS[i].April))
                {
                    Label = "April",
                    TextColor = SKColor.Parse("#12d25b"),
                    Color = SKColor.Parse("#12d25b"),
                    ValueLabel = ListPS[i].April
                });
                entries.Add(new Entry(Convert.ToInt64(ListPS[i].May == "" ? "0" : ListPS[i].May))
                {
                    Label = "May",
                    TextColor = SKColor.Parse("#feafa0"),
                    Color = SKColor.Parse("#feafa0"),
                    ValueLabel = ListPS[i].May
                });
                entries.Add(new Entry(Convert.ToInt64(ListPS[i].June == "" ? "0" : ListPS[i].June))
                {
                    Label = "June",
                    TextColor = SKColor.Parse("#fc616f"),
                    Color = SKColor.Parse("#fc616f"),
                    ValueLabel = ListPS[i].June
                });
                entries.Add(new Entry(Convert.ToInt64(ListPS[i].July == "" ? "0" : ListPS[i].July))
                {
                    Label = "July",
                    TextColor = SKColor.Parse("#26739d"),
                    Color = SKColor.Parse("#26739d"),
                    ValueLabel = ListPS[i].July
                });
                entries.Add(new Entry(Convert.ToInt64(ListPS[i].August == "" ? "0" : ListPS[i].August))
                {
                    Label = "August",
                    TextColor = SKColor.Parse("#ffd248"),
                    Color = SKColor.Parse("#ffd248"),
                    ValueLabel = ListPS[i].August
                });
                entries.Add(new Entry(Convert.ToInt64(ListPS[i].September == "" ? "0" : ListPS[i].September))
                {
                    Label = "September",
                    TextColor = SKColor.Parse("#e81512"),
                    Color = SKColor.Parse("#e81512"),
                    ValueLabel = ListPS[i].September
                });
                entries.Add(new Entry(Convert.ToInt64(ListPS[i].October == "" ? "0" : ListPS[i].October))
                {
                    Label = "October",
                    TextColor = SKColor.Parse("#ff9369"),
                    Color = SKColor.Parse("#ff9369"),
                    ValueLabel = ListPS[i].October
                });
                entries.Add(new Entry(Convert.ToInt64(ListPS[i].November == "" ? "0" : ListPS[i].November))
                {
                    Label = "November",
                    TextColor = SKColor.Parse("#89b416"),
                    Color = SKColor.Parse("#89b416"),
                    ValueLabel = ListPS[i].November
                });
                entries.Add(new Entry(Convert.ToInt64(ListPS[i].December == "" ? "0" : ListPS[i].December))
                {
                    Label = "December",
                    TextColor = SKColor.Parse("#12d25b"),
                    Color = SKColor.Parse("#12d25b"),
                    ValueLabel = ListPS[i].December
                });
                Label lblMainCategory = new Label() { Text = ListPS[i].SubCategory + " - " + ListPS[i].MainCategory, HorizontalOptions = LayoutOptions.Center };
                //Label lblSubCategory = new Label() { Text = ListPS[i].SubCategory };
                var chh = new BarChart() { Entries = entries };
                _chartview.Chart = chh;

                Frame fr = new Frame() { HasShadow = true, Content = _chartview };
                StackLayout stkChild = new StackLayout() { BackgroundColor = Color.White, HorizontalOptions = LayoutOptions.FillAndExpand, };
                stkChild.Children.Add(lblMainCategory);
                stkChild.Children.Add(fr);

                //stkMain.Children.Add(lblSubCategory);

                stkMain.Children.Add(stkChild);

            }


        }
    }
}