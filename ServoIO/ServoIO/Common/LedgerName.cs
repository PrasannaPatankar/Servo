using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServoIO.Common
{
    public class LedgerName
    {
        public string LName { get; set; }
        public override string ToString()
        {
            return  LName;
        }
    }
}
