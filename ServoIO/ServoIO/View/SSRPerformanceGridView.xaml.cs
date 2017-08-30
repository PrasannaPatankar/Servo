using Rg.Plugins.Popup.Extensions;
using ServoIO.ViewModel;
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
using Xamarin.Forms.Xaml;

namespace ServoIO.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SSRPerformanceGridView : ContentPage
    {
        public SSRPerformanceGridView()
        {
            try
            {
                InitializeComponent();
                BindingContext = new SSRPerformanceGridViewModel();
            }
            catch (Exception ex)
            {
                var page = new ErrorMsg(ex.Message);
                Navigation.PushPopupAsync(page);
            }
        }

    }
}
