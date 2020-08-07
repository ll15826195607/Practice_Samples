using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProxyDemo
{
    public class SimpleUserControlProxy : IUserController
    {
        public MetricsCollector metricsCollector { get; private set; }
        public UserController userController { get; private set; }
        public SimpleUserControlProxy(MetricsCollector metricsCollector, UserController userController)
        {
            this.metricsCollector = metricsCollector;
            this.userController = userController;
        }
        public bool Login(string name, string password)
        {
            DateTime dtNow = DateTime.Now;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Boolean result = this.userController.Login(name, password);
            stopwatch.Stop();
            this.metricsCollector.RecordRequest(new RequestEntity("Login", stopwatch.ElapsedMilliseconds, dtNow.Ticks));
            return result;
        }

        public bool Register(string name)
        {
            DateTime dtNow = DateTime.Now;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Boolean result = this.userController.Register(name);
            stopwatch.Stop();
            this.metricsCollector.RecordRequest(new RequestEntity("Register", stopwatch.ElapsedMilliseconds, dtNow.Ticks));
            return result;
        }
    }
}
