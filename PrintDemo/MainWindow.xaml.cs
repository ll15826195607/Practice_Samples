using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace PrintDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private delegate void DoPrintMethod(PrintDialog pdlg, DocumentPaginator paginator);
        private void DoPrint(PrintDialog pdlg, DocumentPaginator paginator)
        {
            pdlg.PrintDocument(paginator, "Order Document");
        }
        private void Button_Cick(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                switch (btn.Name)
                {
                    case "btnDirectPrint":
                        {
                            PrintDialog pdlg = new PrintDialog();
                            if (pdlg.ShowDialog() == true)
                            {
                                Order order = new Order()
                                {
                                    Company = "攸亮科技有限公司",
                                    OrderDetails = new List<string>()
                                {
                                    "我是谁?",
                                    "我来自哪里?"
                                },
                                    OrderTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                    Title = "订单"
                                };
                                try
                                {
                                    FlowDocument doc = PrintPreviewWindow.LoadDocumentAndRender("OrderDocument.xaml", order, new OrderDocumentRenderer());
                                    var Dispatcher = Application.Current.Dispatcher.BeginInvoke(new DoPrintMethod(DoPrint), DispatcherPriority.ApplicationIdle, pdlg, ((IDocumentPaginatorSource)doc).DocumentPaginator);
                                    Dispatcher.Completed += Dispatcher_Completed;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                        }
                        break;
                    case "btnPreviewPrint":
                        {
                            Order order = new Order()
                            {
                                Company = "攸亮科技有限公司", 
                                OrderDetails = new List<string>()
                                {
                                    "我是谁?",
                                    "我来自哪里?"
                                }, 
                                OrderTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 
                                Title = "订单"
                            };
                            var win = new PrintPreviewWindow("OrderDocument.xaml", order, new OrderDocumentRenderer());
                            win.Owner = this;
                            win.ShowInTaskbar = false;
                            win.ShowDialog();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void Dispatcher_Completed(object sender, EventArgs e)
        {
            Console.WriteLine("打印结束");
        }
    }
}
