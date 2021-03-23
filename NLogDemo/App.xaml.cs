using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NLogDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        protected override void OnStartup(StartupEventArgs e)
        {
            logger.Info("APP 已开始");
            App.Current.Exit += Current_Exit;
            base.OnStartup(e);
        }

        private void Current_Exit(object sender, ExitEventArgs e)
        {
            logger.Info("APP 已结束");
        }
    }
}
