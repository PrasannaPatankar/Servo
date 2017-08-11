using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ServoIO.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageIOMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetailPageIOMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPageIOMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPageIOMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPageIOMenuItem> MenuItems { get; set; }

            public MasterDetailPageIOMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPageIOMenuItem>(new[]
                {
                    new MasterDetailPageIOMenuItem { Id = 0,  Icon ="hm.png", Title = "Home", TargetType=typeof(Dashboard) },
                    new MasterDetailPageIOMenuItem { Id = 1, Icon ="report1.png", Title = "Reports", TargetType=typeof(PrimarySecondarySaleList) },
                     new MasterDetailPageIOMenuItem { Id = 1, Icon ="report1.png", Title = "Incentives", TargetType=typeof(IncentivesList) },
                    new MasterDetailPageIOMenuItem { Id = 2, Icon ="logout1.png", Title = "Log Out", TargetType=typeof(Dashboard) },
                    //new MasterDetailPageIOMenuItem { Id = 3,  Icon ="icon.png", Title = "", TargetType=typeof(Dashboard) },
                    //new MasterDetailPageIOMenuItem { Id = 4,  Icon ="icon.png", Title = "", TargetType=typeof(Dashboard) },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}