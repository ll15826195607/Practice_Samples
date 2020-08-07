using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyDemo
{
    public class RequestEntity
    {
        public String FuncName { get; private set; }
        public Int64 ResponseTime { get; private set; }
        public Int64 StartTime { get; private set; }
        public RequestEntity(String funcName, Int64 responseTime, Int64 startTime)
        {
            this.FuncName = funcName;
            this.ResponseTime = responseTime;
            this.StartTime = startTime;
        }
    }
}
