using ServoIO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ServoIO.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AnimatedCharts : ContentPage
	{
        //public SSRPerformanceReportViewModel _ViewModel { get; set; }
        public AnimatedCharts ()
		{
			InitializeComponent ();
            this.BindingContext = new SSRPerformanceReportViewModel();

            //this.BindingContext = new SSRPerformanceReportViewModel();
            //_ViewModel = (SSRPerformanceReportViewModel)this.BindingContext;
            //_ViewModel.ShowCommand.Execute(null);
        }
	}
}