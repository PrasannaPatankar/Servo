using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Rg.Plugins.Popup.Extensions;
using ServoIO.Common;
using ServoIO.View;
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
    public class SSRperformanceSalesPieChartViewModel : ViewModelBase
    {
        private List<SSRPerformance> _LstSSRPerformance;
        public List<SSRPerformance> LstSSRPerformance
        {
            get { return _LstSSRPerformance; }
            set { SetProperty(ref _LstSSRPerformance, value); }
        }

        private DateTime dtFrom = DateTime.Now.Date.AddYears(-2);
        public DateTime FromDate
        {
            get { return dtFrom; }
            set { SetProperty(ref dtFrom, value); CreatePieChartAsync(false, "Sales In Rs."); }
        }

        private DateTime dtTo = DateTime.Now.Date.AddYears(-1);
        public DateTime ToDate
        {
            get { return dtTo; }
            set
            { //SetProperty(ref dtTo, value);
                if (SetProperty(ref dtTo, value, "Name"))
                    CreatePieChartAsync(false, "Sales In Rs.");
            }
        }

        private Boolean showactivityindicator;
        public Boolean ShowActivityIndicator
        {
            get { return showactivityindicator; }
            set { SetProperty(ref showactivityindicator, value); }
        }

        private PlotModel modelP1;
        public PlotModel Model1
        {
            get { return modelP1; }
            set { modelP1 = value; }
        }

        public SSRperformanceSalesPieChartViewModel()
        { }

        public void CreatePieChartAsync(bool stacked, string title)
        {
            try
            {

                if (dtFrom.Date >= dtTo.Date)
                {
                    var page = new ErrorMsg("From date shloud be less than To date");
                    Application.Current.MainPage.Navigation.PushPopupAsync(page);
                    return;
                }
                ShowActivityIndicator = true;
                Task task = Task.Run(async () => LstSSRPerformance = await Service.ReportService.Get_SSRPerformanceReport(dtFrom.ToString("MM-dd-yyyy"), dtTo.ToString("MM-dd-yyyy")));
                task.Wait();
                modelP1 = new PlotModel { };
                //modelP1.Title = title;
                dynamic seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.5, AngleSpan = 360, StartAngle = 0, InnerDiameter = 0.4, Diameter = 1 };

                //if (LstSSRPerformance != null)
                foreach (SSRPerformance ssritem in LstSSRPerformance)
                {
                    seriesP1.Slices.Add(new PieSlice(ssritem.EmployeeName.Substring(0, ssritem.EmployeeName.IndexOf(' ') + 1), Convert.ToDouble(ssritem.SaleInRs)) { IsExploded = false });
                }

                modelP1.Series.Add(seriesP1);
                ShowActivityIndicator = false;
            }
            catch (Exception)
            {
                ShowActivityIndicator = false;
                throw;                
            }


        }
    }
}
