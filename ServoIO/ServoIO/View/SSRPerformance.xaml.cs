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
    public partial class SSRPerformance : ContentPage
    {
        public SSRPerformance()
        {

            InitializeComponent();
            List<string> SSRName = new List<string>()
            {
               "Anil","Gopal","Key","Nitin","Nitin"
            };

            Grid grd = new Grid();
            for (int i = 0; i < SSRName.Count; i++)
            {
                grd.ColumnDefinitions.Add(new ColumnDefinition { Width = 150 });
                grd.Children.Add(new Label
                {
                    Text = SSRName[i].ToString(),
                    BackgroundColor = Color.Gray,
                    TextColor = Color.DarkSalmon,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand,

                }, i, 0);


                Button bt = new Button();
                bt.Text = SSRName[i].ToString();
                bt.BackgroundColor = Color.Gray;
                bt.TextColor = Color.DarkSalmon;
                bt.VerticalOptions = LayoutOptions.FillAndExpand;
                bt.HorizontalOptions = LayoutOptions.FillAndExpand;
                bt.Image= "psreports.png";
                

                grd.Children.Add(bt, i, 0);
                bt.Clicked += Bt_Clicked;
                // var firstLabel = PandSSales;
                //grd.GestureRecognizers.Add(new TapGestureRecognizer
                //{
                //    Command = new Command(() => PrimarySecondaryClick((object)i.ToString())),
                //    CommandParameter = i.ToString(),
                    
                //}) ;
             
            
            }
            //tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "RowTappedCommand");
            //var binding = new Binding();
            //binding.Source = i.ToString();
            //tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandParameterProperty, binding); // This is the index of the row
            //grd.GestureRecognizers.Add(tapGestureRecognizer);


            stklower.Children.Add(grd);
        }

        private void Bt_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PrimarySecondaryClick(object children)
        {
            throw new NotImplementedException();
        }
    }
}
