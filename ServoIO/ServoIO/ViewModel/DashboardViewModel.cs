using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using ServoIO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServoIO.View
{
    public class DashboardViewModel : ViewModelBase
    {
        public PlotModel BarModel { get; set; }
        public DashboardViewModel()
        {
            BarModel = CreateBarChart(false, "Comparison Bar Chart");
        }


        private PlotModel CreateBarChart(bool stacked, string title)
        {
            var model = new PlotModel
            {
                Title = title,
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };

            var s1 = new BarSeries { Title = "Primary Charts", IsStacked = stacked, StrokeColor = OxyColors.Black, StrokeThickness = 1 };
            //s1.Items.Add(new BarItem { Value = 25 });
            //s1.Items.Add(new BarItem { Value = 137 });
            //s1.Items.Add(new BarItem { Value = 18 });
            //s1.Items.Add(new BarItem { Value = 40 });

            var s2 = new BarSeries { Title = "Secondary Charts", IsStacked = stacked, StrokeColor = OxyColors.Black, StrokeThickness = 1 };
            //s2.Items.Add(new BarItem { Value = 12 });
            //s2.Items.Add(new BarItem { Value = 14 });
            //s2.Items.Add(new BarItem { Value = 120 });
            //s2.Items.Add(new BarItem { Value = 26 });

            var categoryAxis = new CategoryAxis { Position = CategoryAxisPosition() };
            categoryAxis.Labels.Add("2T");
            categoryAxis.Labels.Add("4T");
            categoryAxis.Labels.Add("GEN_OILS");
            categoryAxis.Labels.Add("GREASE");
            categoryAxis.Labels.Add("LUBE");
            
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

