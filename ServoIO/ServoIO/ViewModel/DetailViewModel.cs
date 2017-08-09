using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ServoIO.ViewModel
{
    public class DetailViewModel : ViewModelBase
    {


        private List<string> _StartDate;

        public List<string> StartDate
        {
            get { return _StartDate; }
            set { SetProperty(ref _StartDate, value); }
        }

        private List<string> _EndDate;

        public List<string> EndDate
        {
            get { return _EndDate; }
            set { SetProperty(ref _EndDate, value); }
        }

        public List<string> GetYearData()
        {
            List<string> strYear = new List<string>();
            strYear.Add("2014");
            strYear.Add("2015");
            strYear.Add("2016");
            strYear.Add("2017");
            strYear.Add("2018");
            strYear.Add("2019");
            strYear.Add("2020");
            return strYear;
        }
        public DetailViewModel()
        {
            StartDate = GetYearData();
            EndDate = GetYearData();
        }

        public void ValidateYear()
        {
            var str = StartDate.ToString();
            var str1 = EndDate.ToString();
        }

    }
}