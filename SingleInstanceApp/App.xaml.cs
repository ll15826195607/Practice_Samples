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
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                SingleInstanceAppMonitor.Instance.Monitor();
                LoginView login = new LoginView();
                var dr = login.ShowDialog();
                if (dr.HasValue && dr.Value)
                {
                    this.StartupUri = new Uri("pack://application:,,,/SingleInstanceApp;component/MainWindow.xaml", UriKind.RelativeOrAbsolute);
                    base.OnStartup(e);
                    Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                    return;
                }
                else
                {
                    this.Shutdown();
                }
            }
            else
            {
                SingleInstanceAppMonitor.Instance.ReMonitor();
                this.Shutdown();
            }
        }
    }
}
