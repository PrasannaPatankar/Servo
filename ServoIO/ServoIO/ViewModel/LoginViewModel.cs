using Rg.Plugins.Popup.Extensions;
using ServoIO.Service;
using ServoIO.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ServoIO.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand Cmd_Login { get; set; }
        List<string> userrole = new List<string>() { "Administrator", "SSAGWL" };

        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { SetProperty(ref _UserName, value); }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); validPassword(); }
        }

        private List<string> _UserRole;
        public List<string> UserRole
        {
            get { return _UserRole; }
            set { SetProperty(ref _UserRole, value); }
        }

        private string _SelectedRole;

        public string SelectedRole
        {
            get { return _SelectedRole; }
            set { SetProperty(ref _SelectedRole, value); }
        }

        private Boolean showactivityindicator;
        public Boolean ShowActivityIndicator
        {
            get { return showactivityindicator; }
            set { SetProperty(ref showactivityindicator, value); }
        }



        private void validPassword()
        {
            if (Password.Length > 50)
            {
                Password = Password.Substring(0, 50);
                //var page = new ErrorMsg("whoal");
                //Application.Current.MainPage.Navigation.PushPopupAsync(page);
            }
        }

        private bool Validate()
        {
            SelectedRole = "Administrator";
            if (SelectedRole == null)
            {
                var page = new ErrorMsg("Select User Type");
                Application.Current.MainPage.Navigation.PushPopupAsync(page);
                return false;
            }

            UserName = "admin";

            if (UserName == null)
            {
                var page = new ErrorMsg("Enter Username");
                Application.Current.MainPage.Navigation.PushPopupAsync(page);
                return false;
            }

            Password = "whB5Rr75dvRE6aQMA0RuMg==";

            if (Password == null)
            {
                var page = new ErrorMsg("Enter Password");
                Application.Current.MainPage.Navigation.PushPopupAsync(page);
                return false;
            }
            return true;
        }

        public LoginViewModel()
        {
            UserRole = userrole;
            Cmd_Login = new Command(NextClickAsync);
        }

        public async void NextClickAsync()
        {
            //Application.Current.MainPage = new MasterDetailPageIO();
            try
            {
                if (Validate())
                {
                    string Result = await ReportService.GetUserID(UserName, Password, SelectedRole);
                    if (Result == "0")
                    {
                        var page = new ErrorMsg("Invalid Username or Password");
                        await Application.Current.MainPage.Navigation.PushPopupAsync(page);
                        UserName = "";
                        Password = "";
                    }
                    else
                    {
                        Application.Current.MainPage = new MasterDetailPageIO();
                    }
                }
            }
            catch (Exception ex)
            {
                var page = new ErrorMsg(ex.Message);
                await Application.Current.MainPage.Navigation.PushPopupAsync(page);
            }
            

        }

        public async Task GetUserID(string Role)
        {
            try
            {
                ShowActivityIndicator = true;
                string str = await ReportService.GetUserID(UserName, Password, Role);
                ShowActivityIndicator = false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
