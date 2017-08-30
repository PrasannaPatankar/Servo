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
    public partial class SubControlsView : Grid
    {
        public SubControlsView()
        {
            InitializeComponent();
        }

        public SubControlsView(object item)
        {
            InitializeComponent();
            BindingContext = item;
        }
    }
}
