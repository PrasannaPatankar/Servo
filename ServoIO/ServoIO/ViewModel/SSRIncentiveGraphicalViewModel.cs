using Newtonsoft.Json;
using ServoIO.Common;
using ServoIO.Service;
using ServoIO.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ServoIO.ViewModel
{
    public class SSRIncentiveGraphicalViewModel:ViewModelBase
    {
        public ICommand ViewCommand { get; set; }

        private List<IncentiveReport> _IncentiveReport;

        public List<IncentiveReport> IncentiveReport
        {
            get { return _IncentiveReport; }
            set { SetProperty(ref _IncentiveReport , value); }
        }

        public INavigation Navigation { get; set; }

        public SSRIncentiveGraphicalViewModel(INavigation navigation)
        {
            //var res= NotifyTaskCompletion

            this.Navigation = navigation;
            Task.Factory.StartNew(async () =>
            {
                await GetIncentiveReportAsync();
            });

            ViewCommand = new Command(GetSSRReports);
        }
        
        private void GetSSRReports(object obj)
        {
            var res = obj as IncentiveReport;
            Navigation.PushAsync(new SSRReports(obj));
        }


        private async Task GetIncentiveReportAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.GetAsync(Constants.InsentiveReport_List + "/" + "2014-02-02" + "/" + "2015-01-01");
                result.EnsureSuccessStatusCode();
                string stringJson = await result.Content.ReadAsStringAsync();
                List<IncentiveReport> ObjRoot = JsonConvert.DeserializeObject<List<IncentiveReport>>(stringJson);
                ObjRoot[0].ColorCode =Color.FromHex("#68A1B9") ;
                ObjRoot[1].ColorCode = Color.FromHex("#68A1B0");
                ObjRoot[2].ColorCode = Color.FromHex("#fc616f");
                ObjRoot[3].ColorCode = Color.FromHex("#fcA1B0");
                ObjRoot[4].ColorCode = Color.FromHex("#611DE9");
                ObjRoot[5].ColorCode = Color.FromHex("#804AED");
                
                  IncentiveReport = ObjRoot;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
