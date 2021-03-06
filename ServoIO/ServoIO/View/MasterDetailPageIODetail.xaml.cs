﻿using Rg.Plugins.Popup.Extensions;

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
    public partial class MasterDetailPageIODetail : TabbedPage
    {
       // public DetailViewModel viewModel { get; set; }
        public MasterDetailPageIODetail()
        {
            try
            {
                InitializeComponent();
                Children.Add(new PrimarySecondarySaleList());
                Children.Add(new Dashboard());
            }
            catch (Exception ex)
            {
                var page = new ErrorMsg(ex.Message);
                Navigation.PushPopupAsync(page);
            }
            
            //this.BindingContext = new DetailViewModel();
            //viewModel = (DetailViewModel)this.BindingContext;
        }

        //private void btnSubmit_Clicked(object sender, EventArgs e)
        //{
        //    Navigation.PushModalAsync(new TestPage());
        //}
    }
}