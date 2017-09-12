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
       
        public ICommand cmd_Show { get; set; }
        private List<LedgerReport> _LdrReport;
        public List<LedgerReport> LdrReport
        {
            get { return _LdrReport; }
            set { SetProperty(ref _LdrReport, value); }
        }
        List<string> userrole = new List<string>() {};
        private List<string> _UserRole;
        public List<string> UserRole
        {
            get { return _UserRole; }
            set { SetProperty(ref _UserRole, value); }
        }
        private string _SelectedRole;

        public string SelectedRole
        {
            get { return _SelectedRole; }
            set { SetProperty(ref _SelectedRole, value); }
        }

        private List<LedgerName> _LName;
        public List<LedgerName> LName
        {
            get { return _LName; }
            set { SetProperty(ref _LName, value); }
        }

        private int Total;
        public int total
        {
            get { return Total; }
            set {SetProperty(ref Total,value); }
        }

        private string _SelectedPartyName;

        public string SelectedPartyName
        {
            get { return _SelectedPartyName; }
            set { SetProperty(ref _SelectedPartyName, value); }
        }

        private DateTime dtFrom = DateTime.Now.Date.AddYears(-2);
        public DateTime FromDate
        {
            get { return dtFrom; }
            set { SetProperty(ref dtFrom, value);}
            }

        private DateTime dtTo = DateTime.Now.Date.AddYears(-1);
        public DateTime ToDate
        {
            get { return dtTo; }
            set { SetProperty(ref dtTo, value); }
        }

        public LedgerReportViewModel()
        {
            try
            {
                getparameter();
                GetLedgerNames();
                // GetLedgerReport();
                cmd_Show = new Command(PartyNameClick);
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public void PartyNameClick()
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
        public void  GetLedgerReport()//report
        {
            try
            {
                string pnm="";
                if (!string.IsNullOrEmpty(_SelectedPartyName))
                {
                    string[] Name = _SelectedPartyName.Split(new char[] { ':' }, _SelectedPartyName.Length);
                     pnm = Name[0];
                }
               
                //ShowActivityIndicator = true;
                Task task = Task.Run(async () => LdrReport = await ReportService.Get_LedgerReport(dtFrom.ToString("MM-dd-yyyy"), dtTo.ToString("MM-dd-yyyy"), pnm));
                task.Wait();
                //ShowActivityIndicator = false;
               
            }
            catch (Exception ex)
            {

                throw;
            }


        }

       
        public void getparameter()
        {
            try
            {
                Task task = Task.Run(async () => _LName = await ReportService.Get_LedgerName());
                task.Wait();
                foreach(LedgerName item in _LName)
                {
                    userrole.Add(item.LName.ToString());
                }
                UserRole = userrole;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task GetLedgerNames()//picker
        {
            try
            {
                //ShowActivityIndicator = true;
                Task task = Task.Run(async () => _LName = await ReportService.Get_LedgerName());
                task.Wait();
                //_LName = await ReportService.Get_LedgerName();
                //ShowActivityIndicator = false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
