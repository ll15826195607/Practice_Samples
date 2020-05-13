using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassDemo
{
    public class FileLogger : Logger
    {
        StreamWriter streamWriter;
        public FileLogger(String name, Boolean enabled, LogLevel level):base(name, enabled, level)
        {
            streamWriter = File.CreateText("20200512.log");
        }
        protected override void DoLog(LogLevel level, string message)
        {
            streamWriter.WriteLine(String.Format("FileLogger: {0}", message));
            streamWriter.Flush();
        }
    }
}
