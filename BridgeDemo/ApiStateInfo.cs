using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDemo
{
    public class ApiStateInfo
    {
        public String api { get; set; }
        public Int64 requestCount { get; set; }
        public Int64 errorCount { get; set; }
        public Int64 durationOfSeconds { get; set; }
    }
}
