using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTricingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            EtwServer etwServer = new EtwServer();
            etwServer.ReceivedEvent += EtwServer_ReceivedEvent;
            etwServer.Start();
            Console.Read();
        }

        private static void EtwServer_ReceivedEvent(object sender, InterprocessCommunicaitonContract.DataReceivedEventArgs e)
        {
            Console.WriteLine("消息来了" + e.Data);
        }
    }
}
