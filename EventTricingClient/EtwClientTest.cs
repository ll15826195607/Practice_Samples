using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTricingDemo
{
    public class EtwClientTest
    {
        static void Main(string[] args)
        {
            EtwClient etwClient = new EtwClient();
            Console.WriteLine(etwClient.Name);
            etwClient.Send("Hello World");

            Console.ReadLine();
        }
    }
}
