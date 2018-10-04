using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServoIO.Service
{
    public static class Constants
    {
        public static string PrimarySecondaryYearlyReport_List = @"http://172.25.29.70:1272/Service1.svc/json/Get_PrimarySecReport/";

        public static string InsentiveReport_List = @"http://172.25.29.70:1272/Service1.svc/json/Get_SSRIncentiveReport/";

        public static string SSRPerformance = @"http://172.25.29.70:1272/Service1.svc/json/Get_SSRPerformanceReport/";

        public static string LedgerReport = @"http://172.25.29.70:1272/Service1.svc/json/Get_LedgerReport/";

        public static string LedgerName = @"http://172.25.29.70:1272/Service1.svc/json/Get_LedgerNames";
    }
}
