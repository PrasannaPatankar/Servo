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

        public DashboardViewModel(List<PrimarySecReport> ObjPS)
        {
            Task.Factory.StartNew(async () =>
            {
                ObjPS = await ReportService.GetPrimarySecondaryReport("2014");
                BarModel = await CreateBarChartAsync(false, "Comparison Bar Chart", ObjPS);
            });
            
        }


        private async Task<PlotModel> CreateBarChartAsync(bool stacked, string title, List<PrimarySecReport> ObjPS)
        {          
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

