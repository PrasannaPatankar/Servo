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
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();
        }

        //private void setTitleBarBAckground()
        //{
        //    var titleBar = ApplicationView.GetCurrentView().TitleBar;
        //}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                //this.Animate("", s => Layout(new Rectangle(((-1 + s) * Width), Y, Width, Height)), 16, 250, Easing.Linear, null, null);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                throw;
            }

        }
    }
}
