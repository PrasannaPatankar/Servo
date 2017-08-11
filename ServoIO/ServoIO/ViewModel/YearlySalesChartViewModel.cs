using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServoIO.Common;

using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace ServoIO.ViewModel
{
    public class YearlySalesChartViewModel : ViewModelBase
    {
        private PlotModel barmodel;

        public PlotModel BarModel
        {
            get { return barmodel; }
            set { SetProperty(ref barmodel, value); }
        }


        public YearlySalesChartViewModel(PrimarySecReport ObjPS)
        {
            try
            {
                BarModel = CreateBarChart(false, ObjPS.SubCategory + " ("+ ObjPS.MainCategory + ")" , ObjPS);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private PlotModel CreateBarChart(bool stacked, string title, PrimarySecReport ObjPS)
        {
            var model = new PlotModel
            {
                Title = title,
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };

            var s1 = new BarSeries { Title = "Monthly Sale", IsStacked = stacked, StrokeColor = OxyColors.Black, StrokeThickness = 1, LabelPlacement=LabelPlacement.Inside, LabelFormatString= "{0}" };

            if (ObjPS.April != "")
            {
                s1.Items.Add(new BarItem { Value = Convert.ToInt32(ObjPS.April) });
            }
            else
            {
                s1.Items.Add(new BarItem { Value = 0 });
            }

            if (ObjPS.May != "")
            {
                s1.Items.Add(new BarItem { Value = Convert.ToInt32(ObjPS.May) });
            }
            else
            {
                s1.Items.Add(new BarItem { Value = 0 });
            }

            if (ObjPS.June != "")
            {
                s1.Items.Add(new BarItem { Value = Convert.ToInt32(ObjPS.June) });
            }
            else
            {
                s1.Items.Add(new BarItem { Value = 0 });
            }

            if (ObjPS.July != "")
            {
                s1.Items.Add(new BarItem { Value = Convert.ToInt32(ObjPS.July) });
            }
            else
            {
                s1.Items.Add(new BarItem { Value = 0 });
            }

            if (ObjPS.August != "")
            {
                s1.Items.Add(new BarItem { Value = Convert.ToInt32(ObjPS.August) });
            }
            else
            {
                s1.Items.Add(new BarItem { Value = 0 });
            }

            if (ObjPS.September != "")
            {
                s1.Items.Add(new BarItem { Value = Convert.ToInt32(ObjPS.September) });
            }
            else
            {
                s1.Items.Add(new BarItem { Value = 0 });
            }

            if (ObjPS.October != "")
            {
                s1.Items.Add(new BarItem { Value = Convert.ToInt32(ObjPS.October) });
            }
            else
            {
                s1.Items.Add(new BarItem { Value = 0 });
            }

            if (ObjPS.November != "")
            {
                s1.Items.Add(new BarItem { Value = Convert.ToInt32(ObjPS.November) });
            }
            else
            {
                s1.Items.Add(new BarItem { Value = 0 });
            }

            if (ObjPS.December != "")
            {
                s1.Items.Add(new BarItem { Value = Convert.ToInt32(ObjPS.December) });
            }
            else
            {
                s1.Items.Add(new BarItem { Value = 0 });
            }

            if (ObjPS.January != "")
            {
                s1.Items.Add(new BarItem { Value = Convert.ToInt32(ObjPS.January) });
            }
            else
            {
                s1.Items.Add(new BarItem { Value = 0 });
            }

            if (ObjPS.February != "")
            {
                s1.Items.Add(new BarItem { Value = Convert.ToInt32(ObjPS.February) });
            }
            else
            {
                s1.Items.Add(new BarItem { Value = 0 });
            }

            if (ObjPS.March != "")
            {
                s1.Items.Add(new BarItem { Value = Convert.ToInt32(ObjPS.March) });
            }
            else
            {
                s1.Items.Add(new BarItem { Value = 0 });
            }

            var categoryAxis = new CategoryAxis { Position = CategoryAxisPosition() };

            categoryAxis.Labels.Add("April");
            categoryAxis.Labels.Add("May");
            categoryAxis.Labels.Add("June");
            categoryAxis.Labels.Add("July");
            categoryAxis.Labels.Add("Augest");
            categoryAxis.Labels.Add("September");
            categoryAxis.Labels.Add("October");
            categoryAxis.Labels.Add("November");
            categoryAxis.Labels.Add("December");
            categoryAxis.Labels.Add("January");
            categoryAxis.Labels.Add("February");
            categoryAxis.Labels.Add("March");
            var valueAxis = new LinearAxis { Position = ValueAxisPosition(), MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0 };
            model.Series.Add(s1);

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
