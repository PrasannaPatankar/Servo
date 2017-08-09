using ServoIO.Common;
using ServoIO.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServoIO.ViewModel
{
    public class PrimarySecondarySaleListViewModel : ViewModelBase
    {
        public PrimarySecondarySaleListViewModel(string Year)
        {
            try
            {
                Task.Factory.StartNew(async () =>
                {
                    await GetPSRrport(Year);
                });
            }
            catch (Exception)
            {

                throw;
            }
        }


        private List<PrimarySecReport> lstPS;

        public List<PrimarySecReport> ListPS
        {
            get { return lstPS; }
            set { SetProperty(ref lstPS, value); }
        }
               
        public async Task GetPSRrport(string Year)
        {
            try
            {
                ListPS = await ReportService.GetPrimarySecondaryReport(Year);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
