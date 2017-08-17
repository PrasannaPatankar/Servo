using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServoIO.Common;
using ServoIO.ViewModel;

using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using ServoIO.Service;
using Xamarin.Forms;
using System.Windows.Input;

namespace ServoIO.View
{
    public class DashboardViewModel : ViewModelBase
    {


        private PlotModel barmodel;

        public PlotModel BarModel
        {
            get { return barmodel; }
            set { SetProperty(ref barmodel, value); }
        }
        List<string> selectyear = new List<string>() { "2012", "2013", "2014", "2016", "2017" };

        private object  SelectedIndex;

        public  object selectedIndex
        {
            get { return SelectedIndex; }
            set { SetProperty(ref SelectedIndex, value);
                 
                MethodAsync();
            }
        }

        public async Task MethodAsync()
        {
            BarModel = await CreateBarChartAsync(false, "Sales Report", SelectedIndex.ToString());
        }

        private List<string> _SelectYear;

        public List<string> SelectYear
        {
            get { return _SelectYear; }
            set { SetProperty(ref _SelectYear, value); }
        }

        //public DashboardViewModel()
        //{

        //}

        public void SetIndex(int index)
        {
            selectedIndex = index;
        }

        public DashboardViewModel(string Year)
        {
            SelectYear = selectyear;
            Task.Factory.StartNew(async () =>
            {

                BarModel = await CreateBarChartAsync(false, "Sales Report", Year);
            });

        }


        public async Task<PlotModel> CreateBarChartAsync(bool stacked, string title, string Year)
        {

            List<PrimarySecReport> ObjPS = await ReportService.GetPrimarySecondaryReport(Year);
            var model = new PlotModel
            {
                Title = title,
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };

            var SC = ObjPS.Select(x => x.SubCategory).Distinct();
            string[] subCategoryItems = SC.Select(p => p.ToString()).ToArray();

            var s1 = new BarSeries { Title = "Primary", IsStacked = stacked, StrokeColor = OxyColors.Black, StrokeThickness = 1, LabelPlacement = LabelPlacement.Inside, LabelFormatString = "{0}" };

            var s2 = new BarSeries { Title = "Secondary", IsStacked = stacked, StrokeColor = OxyColors.Black, StrokeThickness = 1, LabelPlacement = LabelPlacement.Inside, LabelFormatString = "{0}" };

            foreach (string scitem in subCategoryItems)
            {
                foreach (PrimarySecReport psitem in ObjPS)
                {
                    if (psitem.MainCategory == "Primary")
                        s1.Items.Add(new BarItem { Value = Convert.ToInt32(psitem.Total) });
                    else
                        s2.Items.Add(new BarItem { Value = Convert.ToInt32(psitem.Total) });
                }

            }

            var categoryAxis = new CategoryAxis { Position = CategoryAxisPosition() };
            foreach (string item in subCategoryItems)
            {
                categoryAxis.Labels.Add(item);
            }

            var valueAxis = new LinearAxis { Position = ValueAxisPosition(), MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0 };
            model.Series.Add(s1);
            model.Series.Add(s2);

            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);
            BarModel = model;
            return model;
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

    }
}

