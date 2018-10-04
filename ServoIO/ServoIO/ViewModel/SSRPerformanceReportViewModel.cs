using Microcharts;
using Microcharts.Forms;
using ServoIO.Common;
using ServoIO.Service;
using ServoIO.View;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static ServoIO.Service.ForTest;

namespace ServoIO.ViewModel
{
    public class TestChart
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }

    public class SSRPerformanceReportViewModel : ViewModelBase
    {
        #region Properties

        public event Action<List<SSRPerformance>> OnReportChanged;
        public ICommand ShowCommand { get; set; }

        private List<SSRPerformance> _TestChartList;

        public List<SSRPerformance> TestChartList
        {
            get { return _TestChartList; }
            set { SetProperty(ref _TestChartList, value); }
        }

        private List<SSRPerformance> _LstSSRPerformance;
        public List<SSRPerformance> LstSSRPerformance
        {
            get { return _LstSSRPerformance; }
            set { SetProperty(ref _LstSSRPerformance, value); }
        }

        private string _EmployeeCode;

        public string EmployeeCode
        {
            get { return _EmployeeCode; }
            set { SetProperty(ref _EmployeeCode, value); }
        }

        private string _EmployeeName;

        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { SetProperty(ref _EmployeeName, value); }
        }

        private string _Outstandings;

        public string Outstandings
        {
            get { return _Outstandings; }
            set { SetProperty(ref _Outstandings, value); }
        }

        private string _Receipts;

        public string Receipts
        {
            get { return _Receipts; }
            set { SetProperty(ref _Receipts, value); }
        }
        private string _SaleInLtr;

        public string SaleInLtr
        {
            get { return _SaleInLtr; }
            set { SetProperty(ref _SaleInLtr, value); }
        }
        private string _SaleInRs;

        public string SaleInRs
        {
            get { return _SaleInRs; }
            set { SetProperty(ref _SaleInRs, value); }
        }
        private DateTime dtFrom = DateTime.Now.Date.AddYears(-2);
        public DateTime FromDate
        {
            get { return dtFrom; }
            set
            {
                SetProperty(ref dtFrom, value);
                if (CheckDate())
                {
                    Device.BeginInvokeOnMainThread(async () =>
                         await GetReport()
                    );

                } 
                else
                {
                    var page = new ContentPage();
                    var result = page.DisplayAlert("Error", "Invalid Date", "OK");
                }
                 //ShowCommand.Execute(null);
            }
        }

        public bool CheckDate()
        {
            if (FromDate >= ToDate)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private DateTime dtTo = DateTime.Now.Date.AddYears(-1);
        public DateTime ToDate
        {
            get { return dtTo; }
            set
            {
                //SetProperty(ref dtTo, value);
                //ShowCommand = new Command(async () => await GetReport());
                // ShowCommand.Execute(null);
                if (SetProperty(ref dtTo, value, "Name"))
                if (CheckDate())
                    {
                        GetReport();
                    }
                    else
                    {
                        var page = new ContentPage();
                        var result = page.DisplayAlert("Error", "Invalid Date", "OK");
                    }
              }
        }
        
        #endregion

        public INavigation Navigation { get; set; }

        public SSRPerformanceReportViewModel()
        {
            try
            {
                Title = "Performance Report";
                Icon = "icon.png";

                //ShowCommand = new Command(async () => await GetReport());
                ShowCommand = new Command(GetDetails);

                if (LstSSRPerformance != null)
                {
                    EmployeeCode = LstSSRPerformance[0].EmployeeCode.ToString();
                    EmployeeName = LstSSRPerformance[0].EmployeeName.ToString();
                    Outstandings = LstSSRPerformance[0].Outstandings.ToString();
                    Receipts = LstSSRPerformance[0].Receipts.ToString();
                    SaleInLtr = LstSSRPerformance[0].SaleInLtr.ToString();
                    SaleInRs = LstSSRPerformance[0].SaleInRs.ToString();
                }
                else
                {
                    EmployeeCode = "";
                    EmployeeName = "";
                    Outstandings = "";
                    Receipts = "";
                    SaleInLtr = "";
                    SaleInRs = "";
                }
            }
            catch (Exception)
            {

                throw;
            }
           

        }

       
        public void GetDetails(object obj)
        {
            var res = obj as SSRPerformance;
            if (res != null)
            {
                EmployeeCode = res.EmployeeCode;
                EmployeeName = res.EmployeeName;
                Outstandings = res.Outstandings;
                Receipts = res.Receipts;
                SaleInLtr = res.SaleInLtr;
                SaleInRs = res.SaleInRs;
            }
            else
            {
                EmployeeCode = "";
                EmployeeName = "";
                Outstandings = "";
                Receipts = "";
                SaleInLtr = "";
                SaleInRs = "";
            }

        }


        public async Task GetReport()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            var error = false;
            try
            {
                //SSRCreditAnalysisReport res =new  SSRCreditAnalysisReport ();
                //res= await Service.ReportService.GetCreditAnalysisReport();

                //await Task.Delay(1000);
                LstSSRPerformance = await Service.ReportService.Get_SSRPerformanceReport(dtFrom.ToString("MM-dd-yyyy"), dtTo.ToString("MM-dd-yyyy"));

               GetDetails(LstSSRPerformance.FirstOrDefault());
               
                if (OnReportChanged != null)
                {
                    OnReportChanged.Invoke(LstSSRPerformance);
                }
                TestChartList = new List<SSRPerformance>();
                foreach (var item in LstSSRPerformance)
                {
                    TestChartList.Add(new SSRPerformance
                    {
                        EmployeeName = item.EmployeeName.ToString(),
                        Sales = Convert.ToInt32(item.SaleInRs.Substring(0, 3)),
                        Outs = Convert.ToInt32(item.Outstandings.Substring(0, 3)),
                        Receipt = Convert.ToInt32(item.Receipts.Substring(0, 3)),
                    });
                }

            }
            catch
            {

                error = true;
            }
            if (error)
            {
                var page = new ContentPage();
                var result = page.DisplayAlert("Error", "Unable to load report.", "OK");
            }
            IsBusy = false;
        }

    }
}
