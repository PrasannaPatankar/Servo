﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ServoIO.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        //protected override void OnAppearing()
        //{
        //    try
        //    {
        //        base.OnAppearing();
        //        this.Animate("", (s) => Layout(new Rectangle(X, (1 - s) * Height, Width, Height)), 0, 600, Easing.SpringIn, null, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
            
        //}

        //protected override void OnDisappearing()
        //{
        //    try
        //    {
        //        base.OnDisappearing();
        //        this.Animate("", (s) => Layout(new Rectangle(X, (s - 1) * Height, Width, Height)), 0, 600, Easing.SpringIn, null, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
            
        //}
    }
}