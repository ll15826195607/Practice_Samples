using InterprocessCommunicaitonContract;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTricingDemo
{
    public class EtwClient : EventSource, IIpcClient
    {
        
        public static readonly EtwClient Instance = new EtwClient();
        public EtwClient():base("LogEvent")
        {

        }
        public void Send(String data)
        {
            this.Write("LogEvent", new { Data = data });
        }
    }
}
