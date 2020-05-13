using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassDemo
{
    public class ConsoleLogger : Logger
    {
        public ConsoleLogger(String name, Boolean enabled, LogLevel level) : base(name,enabled, level)
        {

        }
        protected override void DoLog(LogLevel level, string message)
        {
            Console.WriteLine(String.Format("ConsoleLogger: {0}",message));
        }
    }
}
