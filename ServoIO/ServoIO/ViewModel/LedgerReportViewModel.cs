using ServoIO.Common;
using ServoIO.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ServoIO.ViewModel
{
    public class LedgerReportViewModel : ViewModelBase
    {
        public ICommand ShowReportCommand { get; set; }

        private List<LedgerReport> _LstLedgerReport;

        public List<LedgerReport> LstLedgerReport
        {
            get { return _LstLedgerReport; }
            set { SetProperty(ref _LstLedgerReport, value); }
        }

        private List<LedgerName> _PartyNameList;

        public List<LedgerName> PartyNameList
        {
            get { return _PartyNameList; }
            set { SetProperty(ref _PartyNameList, value); }
        }

        private DateTime _FromDate;

        public DateTime FromDate
        {
            get { return _FromDate; }
            set { SetProperty(ref _FromDate, value);
                //GetPartyNames();
            }
        }

        private DateTime _ToDate;

        public DateTime ToDate
        {
            get { return _ToDate; }
            set { SetProperty(ref _ToDate, value);
              // GetPartyNames();
            }
        }

        public LedgerReportViewModel()
        {
            GetPartyNames();
            ShowReportCommand = new Command(ShowReport);
        }

        private void ShowReport()
        {
            try
            {
                GetLedgerReport();


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        

        public void GetLedgerReport()
        {
            try
            {
                //Task task = Task.Run(async () => LstLedgerReport = await ReportService.Get_LedgerReport(FromDate.ToString("MM-dd-yyyy"), ToDate.ToString("MM-dd-yyyy"), "Younis Auto Parts"));
                Task task = Task.Run(async () => LstLedgerReport = await ReportService.Get_LedgerReport(FromDate.ToString("01-01-2010"), ToDate.ToString("01-01-2017"), "Younis Auto Parts"));
                task.Wait();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public async Task GetPartyNames()//picker
        {
            try
            {
                Task task = Task.Run(async () => PartyNameList = await ReportService.Get_LedgerName());
                task.Wait();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
