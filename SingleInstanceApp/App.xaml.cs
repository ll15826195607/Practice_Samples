using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows;

namespace SingleInstanceApp
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private static Mutex mutex = new Mutex(true, "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}");
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (mutex.WaitOne(TimeSpan.Zero,true))
            {
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("已有相同程序正在运行!", "提示");
                NativeMethods.PostMessage((IntPtr)NativeMethods.HWND_BROADCAST,NativeMethods.WM_SHOWME,IntPtr.Zero,IntPtr.Zero);
                this.Shutdown();
                return;
            }
        }
    }
}
