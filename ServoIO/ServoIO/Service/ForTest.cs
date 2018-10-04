using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServoIO.Service
{
    public class ForTest
    {
        public class SSRCreditAnalysisReport
        {
            public List<SSRCreditAnalysisData> SSRCreditAnalysisData { get; set; }
        }

        public class SSRCreditAnalysisData
        {
            public string Cust_ID { get; set; }
            public string Cust_Name { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string BillNos { get; set; }
            public string Total { get; set; }
            public string PreviousDues { get; set; }
            public List<MonthData> MonthsData { get; set; }
        }

        public class MonthData
        {
            public string Month { get; set; }
            public string Value { get; set; }
        }
    }
}
