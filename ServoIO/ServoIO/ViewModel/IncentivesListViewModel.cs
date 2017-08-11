using ServoIO.Common;
using ServoIO.Service;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServoIO.ViewModel
{
    public class IncentivesListViewModel : ViewModelBase
    {
        private List<IncentiveReport> lstIR;

        public List<IncentiveReport> ListIR
        {
            get { return lstIR; }
            set { SetProperty(ref lstIR, value); }
        }

        public IncentivesListViewModel(string FromDate, string ToDate)
        {
            try
            {
                Task.Factory.StartNew(async () =>
                {
                    await GetIncentivesReport(FromDate, ToDate);
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task GetIncentivesReport(string FromDate, string ToDate)
        {
            try
            {
                ListIR = await ReportService.GetIncentiveReport(FromDate, ToDate);               
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
