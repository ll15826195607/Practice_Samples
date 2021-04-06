using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingleInstanceApp
{
    public class SingleInstanceAppMonitor
    {
        private EventWaitHandle EWH;
        private Boolean isStart = false;
        public static SingleInstanceAppMonitor Instance = new SingleInstanceAppMonitor();
        private SingleInstanceAppMonitor()
        {
            EWH = new EventWaitHandle(true, EventResetMode.AutoReset, "SingleInstanceApp");
        }

        public void Monitor()
        {
            if (!isStart)
            {
                isStart = true;
                MonitorApp();
            }
        }

        private void MonitorApp()
        {
            Task.Run(() =>
            {
                EWH.Reset();
                EWH.WaitOne();
                App.Current.Dispatcher.Invoke(new Action(()=>
                {
                    if (App.Current.MainWindow != null)
                    {
                        if (App.Current.MainWindow.WindowState == System.Windows.WindowState.Minimized)
                        {
                            App.Current.MainWindow.WindowState = System.Windows.WindowState.Normal;
                        }
                        App.Current.MainWindow.Activate();
                    }
                }));
                MonitorApp();
            });
        }

        public void ReMonitor()
        {
            EWH.Set();
        }
    }
}
