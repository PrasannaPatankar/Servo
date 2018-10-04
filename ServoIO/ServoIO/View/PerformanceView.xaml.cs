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
    public partial class PerformanceView : Grid
    {
        public PerformanceView()
        {
            InitializeComponent();
        }

        public PerformanceView(object item)
        {
            InitializeComponent();
            BindingContext = item;
        }
    }

}