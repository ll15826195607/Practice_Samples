using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassDemo
{
    public abstract class Logger
    {
        private String name;
        private Boolean enabled;
        private LogLevel minPermittedLevel;
        public Logger(String name, Boolean enabled, LogLevel level)
        {
            this.name = name;
            this.enabled = enabled;
            this.minPermittedLevel = level;
        }

        public void Log(LogLevel level,  String message)
        {
            if (enabled && (Int32)level >= (Int32)minPermittedLevel)
            {
                DoLog(level, message);   
            }
        }

        protected abstract void DoLog(LogLevel level, String message);
    }
}
