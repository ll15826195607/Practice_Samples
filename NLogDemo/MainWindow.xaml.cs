using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestRule;

namespace NLogDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Printer printer = new Printer();
                printer.Print();
            });
            await Task.Run(() =>
            {
                try
                {
                    throw new NullReferenceException();
                }
                catch (Exception ex)
                {
                    logger.Error(String.IsNullOrEmpty(ex.StackTrace) ? ex.Message : ex.StackTrace);
                }
                finally
                {
                    StackTrace st = new StackTrace();
                    var sf = st.GetFrame(0);
                    logger.Info(sf.GetMethod().Name);
                }
            });

            await Task.Run(() =>
            {
                try
                {
                    throw new ArgumentOutOfRangeException();
                }
                catch (Exception ex)
                {
                    logger.Error(String.IsNullOrEmpty(ex.StackTrace) ? ex.Message : ex.StackTrace);
                }
                finally
                {
                    StackTrace st = new StackTrace();
                    var sf = st.GetFrame(0);
                    logger.Info(sf.GetMethod().Name);
                }
            });
        }
    }
}
