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
    public partial class NewDashBoard : ContentPage
    {
        public NewDashBoard()
        {
            InitializeComponent();
        }

        private void btnReports_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new MasterDetailPageIODetail());
            }
            catch (Exception)
            {

                throw;
            }
        }

        

        private void btnIncentives_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new IncentivesList());
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
