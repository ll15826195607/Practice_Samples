using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyDemo
{
    public class MetricsCollector
    {
        public readonly List<RequestEntity> Requests = new List<RequestEntity>();
        public void RecordRequest(RequestEntity re)
        {
            this.Requests.Add(re);
        }
    }
}
