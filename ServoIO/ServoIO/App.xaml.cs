using ServoIO.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ServoIO
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //var vSampleData = new OxyExData();
            //MainPage = new ServoIO.MainPage();

            //MainPage = new ServoIO.View.PrimaryVsSecChartReport();
            // MainPage = new NavigationPage(new ServoIO.View.SSRIncentiveGraphical());
            //MainPage = new NavigationPage(new ServoIO.View.SSRPerformanceReport());
            /// MainPage = new NavigationPage(new ServoIO.View.PrimarySecondaryReport());
            // MainPage = new NavigationPage(new DashboardNew());
            //MainPage = new NavigationPage(new ServoIO.View.AnimatedCharts());
            // Application.Current.MainPage = new LoginPage();
            //{
            //    BarBackgroundColor = Color.FromHex("#77D065"),
            //    BarTextColor = Color.White
            //};

            MainPage = new NavigationPage(new ServoIO.View.ScrollableDashboard());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

