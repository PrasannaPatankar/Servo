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
    class SSRPerformanceChartViewModel : ViewModelBase
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
            set { SetProperty(ref dtFrom, value); CreateBarChart(false,""); }
        }

        private DateTime dtTo = DateTime.Now.Date.AddYears(-1);
        public DateTime ToDate
        {
            get { return dtTo; }
            set
            { //SetProperty(ref dtTo, value);
                if (SetProperty(ref dtTo, value, "Name"))
                    CreateBarChart(false, "");
            }
        }

        private Boolean showactivityindicator;
        public Boolean ShowActivityIndicator
        {
            get { return showactivityindicator; }
            set { SetProperty(ref showactivityindicator, value); }
        }

        private PlotModel barmodel;
        public PlotModel BarModel
        {
            get { return barmodel; }
            set { SetProperty(ref barmodel, value); }
        }

        public SSRPerformanceChartViewModel()
        {
            try
            {
                //showactivityindicator = true;
                //CreateBarChartAsync(false, "", "","");
                //showactivityindicator = false;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void CreateBarChart(bool stacked, string title)
        {
            try
            {
                if (dtFrom.Date >= dtTo.Date)
                {
                    var page = new ErrorMsg("From date shloud be less than To date");
                    Application.Current.MainPage.Navigation.PushPopupAsync(page);
                    return;
                }

                Task task = Task.Run(async () => LstSSRPerformance = await Service.ReportService.Get_SSRPerformanceReport(dtFrom.ToString("MM-dd-yyyy"), dtTo.ToString("MM-dd-yyyy")));
                task.Wait();

                var model = new PlotModel
                {
                    Title = title,
                    LegendPlacement = LegendPlacement.Outside,
                    LegendPosition = LegendPosition.BottomCenter,
                    LegendOrientation = LegendOrientation.Horizontal,
                    LegendBorderThickness = 0
                };


                var s1 = new BarSeries { Title = "in Rs.", IsStacked = stacked, StrokeColor = OxyColors.Black, StrokeThickness = 1, LabelPlacement = LabelPlacement.Outside, LabelFormatString = "{0:.00}%" };

                var s2 = new BarSeries { Title = "in Ltr.", IsStacked = stacked, StrokeColor = OxyColors.Black, StrokeThickness = 1, LabelPlacement = LabelPlacement.Outside, LabelFormatString = "{0:.00}%" };

                double sums1 = 0, sums2 = 0;

                foreach (SSRPerformance ssritem in LstSSRPerformance)
                {
                    sums1 = sums1 + Convert.ToDouble(ssritem.SaleInRs);
                    sums2 = sums2 + Convert.ToDouble(ssritem.SaleInLtr);
                }

                foreach (SSRPerformance ssritem in LstSSRPerformance)
                {
                    s1.Items.Add(new BarItem { Value = Convert.ToDouble(ssritem.SaleInRs) / sums1 * 100 });
                    s2.Items.Add(new BarItem { Value = Convert.ToDouble(ssritem.SaleInLtr) / sums2 * 100 });
                }

                var categoryAxis = new CategoryAxis { Position = CategoryAxisPosition() };
                foreach (SSRPerformance ssritem in LstSSRPerformance)
                {
                    categoryAxis.Labels.Add(ssritem.EmployeeName.Substring(0, ssritem.EmployeeName.IndexOf(' ') + 1));
                }

                var valueAxis = new LinearAxis { Position = ValueAxisPosition(), MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0 };
                model.Series.Add(s1);
                model.Series.Add(s2);

                model.Axes.Add(categoryAxis);
                model.Axes.Add(valueAxis);
                BarModel = model;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private AxisPosition CategoryAxisPosition()
        {
            if (typeof(BarSeries) == typeof(ColumnSeries))
            {
                return AxisPosition.Bottom;
            }

            return AxisPosition.Left;
        }

        private AxisPosition ValueAxisPosition()
        {
            if (typeof(BarSeries) == typeof(ColumnSeries))
            {
                return AxisPosition.Left;
            }

            return AxisPosition.Bottom;
        }

        private PlotModel modelP1;
        public PlotModel Model1
        {
            get { return modelP1; }
            set { modelP1 = value; }
        }

        public async Task<PlotModel> CreatePieChartAsync(bool stacked, string title)
        {
            try
            {
                ShowActivityIndicator = true;
                LstSSRPerformance = await Service.ReportService.Get_SSRPerformanceReport(dtFrom.ToString("MM-dd-yyyy"), dtTo.ToString("MM-dd-yyyy"));
                modelP1 = new PlotModel { };

                dynamic seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.5, AngleSpan = 360, StartAngle = 0, InnerDiameter = 0.4, Diameter = 1 };

                //if (LstSSRPerformance != null)
                foreach (SSRPerformance ssritem in LstSSRPerformance)
                {
                    seriesP1.Slices.Add(new PieSlice(ssritem.EmployeeName.Substring(0, ssritem.EmployeeName.IndexOf(' ') + 1), Convert.ToDouble(ssritem.SaleInLtr)) { IsExploded = false });
                }

                modelP1.Series.Add(seriesP1);
                ShowActivityIndicator = false;
                return modelP1;
            }
            catch (Exception)
            {
                ShowActivityIndicator = false;
                throw;
                return null;
            }


        }

    }
}
