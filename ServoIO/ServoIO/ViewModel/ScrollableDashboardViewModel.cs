using ServoIO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace ServoIO.ViewModel
{
    public class ScrollableDashboardViewModel:ViewModelBase
    {
        public ICommand MyCommand { get; set; }
        private List<Dashboard> _DashboardData;
        List<Dashboard> tempList = new List<Dashboard>();

        public List<Dashboard> DashboardData
        {
            get { return _DashboardData; }
            set { SetProperty(ref  _DashboardData ,value); }
        }

        public ScrollableDashboardViewModel()
        {
            MyCommand = new Command(TileClicked);

            tempList.Add(new Dashboard { Title = "Performance Report", TileOrder = 1, TileColor = Color.Red, Icon = ImageSource.FromFile("Performance.png"), SubTitle="212" });
            tempList.Add(new Dashboard { Title = "Incentive Report", TileOrder = 2, TileColor = Color.Red, Icon = ImageSource.FromFile("Incentive.png"), SubTitle = "212" });
            tempList.Add(new Dashboard { Title = "Animated Charts", TileOrder = 3, TileColor = Color.Red, Icon = ImageSource.FromFile("Charts.png"), SubTitle = "212" });
            tempList.Add(new Dashboard { Title = "Primary vs Secondary", TileOrder = 3, TileColor = Color.Red, Icon = ImageSource.FromFile("PriVsSecSales.png"), SubTitle = "212" });
            tempList.Add(new Dashboard { Title = "Ledger Report", TileOrder = 4, TileColor = Color.Red, Icon = ImageSource.FromFile("LedgerReport.png"), SubTitle = "212" });
            DashboardData = tempList;
        }

        public void TileClicked(object obj)
        {
           var result = obj as Dashboard;

        }
    }
}
