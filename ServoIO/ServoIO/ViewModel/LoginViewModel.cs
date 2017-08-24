﻿using ServoIO.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ServoIO.ViewModel
{
   public class LoginViewModel :ViewModelBase
    {
        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set {SetProperty(ref _UserName , value);  }
        }
        public  ICommand Cmd_Login { get; set; }
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); var res = validPassword(); }
        }
        
       

        List<string> userrole = new List<string>() { "Admin", "SSAGWL" };

        private List<string> _UserRole;
        public List<string> UserRole
        {
            get { return _UserRole; }
            set { SetProperty(ref _UserRole, value); }
        }

        private string validPassword()
        {
            // entPassword.Text = CheckLength(entPassword.Text, 10);
            Password = CheckLength(Password, 10);
            return "";
        }
        private string CheckLength(string str, int reqLength)
        {
            try
            {
                if (str.Length >= reqLength)
                {
                    return str.Substring(0, reqLength);
                }
                else
                {
                    return str;
                }
            }
            catch (Exception ex)
            {
                string ab = ex.ToString();
                return null;
            }
        }

        public LoginViewModel()
        {
            UserRole = userrole;
            Cmd_Login = new Command(NextClick);
        }

         
       

        public void NextClick()
        {
            Application.Current.MainPage = new MasterDetailPageIO();
        }
        
    }
}
