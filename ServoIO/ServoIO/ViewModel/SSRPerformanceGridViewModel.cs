using ServoIO.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ServoIO.ViewModel
{
    public class SSRPerformanceGridViewModel : ViewModelBase
    {
        public event Action<List<SSRPerformance>> OnReportChanged;
        private List<SSRPerformance> _LstSSRPerformance;
        public ICommand ShowCommand { get; set; }
        //public Command LoadItemsCommand { get; set; }

        public List<SSRPerformance> LstSSRPerformance
        {
            get { return _LstSSRPerformance; }
            set { SetProperty(ref _LstSSRPerformance, value); }
        }

        private DateTime dtFrom = DateTime.Now.Date.AddYears(-2);
        public DateTime FromDate
        {
            get { return dtFrom; }
            set { SetProperty(ref dtFrom, value); GetReport(); }
        }

        private DateTime dtTo = DateTime.Now.Date.AddYears(-1);
        public DateTime ToDate
        {
            get { return dtTo; }
            set
            { //SetProperty(ref dtTo, value);
                if (SetProperty(ref dtTo, value, "Name"))
                    GetReport();
            }
        }

        #region Properties  
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


        #endregion

        public INavigation Navigation { get; set; }

        public SSRPerformanceGridViewModel()
        {
            // LoadItemsCommand = new Command(async () => await GetReport());
           
            
            ShowCommand = new Command(GetDetails);
            //ShowCommandOnLoad = new Command(GetDetailsOnLoad);
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

        public void GetDetails(object obj)
        {
            var res = obj as SSRPerformance;
            if (res !=null)
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
            //throw new NotImplementedException();
        }

        //public void GetDetailsOnLoad()
        //{
        //    EmployeeCode = LstSSRPerformance[0].EmployeeCode.ToString();
        //    EmployeeName = LstSSRPerformance[0].EmployeeName.ToString();
        //    Outstandings = LstSSRPerformance[0].Outstandings.ToString();
        //    Receipts = LstSSRPerformance[0].Receipts.ToString();
        //    SaleInLtr = LstSSRPerformance[0].SaleInLtr.ToString();
        //    SaleInRs = LstSSRPerformance[0].SaleInRs.ToString();
        //}

        public async Task GetReport()
        {
            try
            {
                LstSSRPerformance = await Service.ReportService.Get_SSRPerformanceReport(dtFrom.ToString("MM-dd-yyyy"), dtTo.ToString("MM-dd-yyyy"));
                GetDetails(LstSSRPerformance.FirstOrDefault());
                if (OnReportChanged!=null)
                {
                    OnReportChanged.Invoke(LstSSRPerformance);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }



    }
}
