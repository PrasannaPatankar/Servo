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
    public partial class SSRPerformanceReport : ContentPage
    {
        public SSRPerformanceReport()
        {
            try
            {
                InitializeComponent();               
                BindingContext = new SSRPerformanceReportViewModel();
            }
            catch (Exception ex)
            {
                var page = new ErrorMsg(ex.Message);
                Navigation.PushPopupAsync(page);
            }
           
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
            => ((ListView)sender).SelectedItem = null;

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                if (e.SelectedItem == null)
                    return;

                await DisplayAlert("Selected", e.SelectedItem.ToString(), "OK");

                //Deselect Item
                ((ListView)sender).SelectedItem = null;
            }
            catch (Exception ex)
            {
                var page = new ErrorMsg(ex.Message);
                await Navigation.PushPopupAsync(page);
            }

        }
    }
}
