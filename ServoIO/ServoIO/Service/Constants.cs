using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServoIO.Service
{
    public static class Constants
    {
        public static string PrimarySecondaryYearlyReport_List = @"http://172.25.29.70:54553/Service1.svc/json/Get_PrimarySecReport/";

        public static string InsentiveReport_List = @"http://172.25.29.70:54553/Service1.svc/json/Get_SSRIncentiveReport/";

        public static string Login_GetUserID = @"http://172.25.29.70:54553/Service1.svc/json/Get_UserID/";

        public static string SSRPerformanceReport = @"http://172.25.29.70:54553/Service1.svc/json/Get_SSRPerformanceReport/";
    }
}
