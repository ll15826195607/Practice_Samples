using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace CustomTaskScheduler
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = Thread.CurrentThread.ManagedThreadId.ToString();
            CommonTaskScheduler();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                switch (btn.Name)
                {
                    case "button1":
                        {
                            for (int i = 0; i < 100; i++)
                            {
                                Task task = Delay(10000);
                                task.ContinueWith(_ => 
                                { 
                                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                                    Console.WriteLine(String.Format("Done-非堵塞", i));
                                });
                            }
                        }
                        break;
                    case "button2":
                        {
                            ThreadPool.QueueUserWorkItem((state) =>
                            {
                                for (int i = 0; i < 1000; i++)
                                {
                                    Task task = Delay2(10000);
                                    task.ContinueWith(_ =>
                                    {
                                        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                                        Console.WriteLine(String.Format("Done-阻塞", i));
                                    });
                                }
                                Console.WriteLine("button2来到这里");
                            });
                            
                        }
                        break;
                    case "button3":
                        {
                            ThreadPool.QueueUserWorkItem((state) =>
                            {
                                for (int i = 0; i < 1000; i++)
                                {
                                    Task.Delay(10000).ContinueWith(_ =>
                                    {
                                        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                                        Console.WriteLine(String.Format("Done-非堵塞", i));
                                    });
                                }

                                Console.WriteLine("button3来到这里");
                            });
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private Task Delay(int milliseconds)
        {
            var tcs = new TaskCompletionSource<object>();
            new Timer(_ => tcs.SetResult(null)).Change(milliseconds, -1);
            return tcs.Task;
        }

        private Task Delay2(int milliseconds)       // Asynchronous non-blocking wrapper....
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(milliseconds);        // ... around a BLOCKING method!
            });
        }

        private List<Int32> PhasicGreenTime(List<Tuple<Byte, List<Byte>>> stageS, Byte phasicid)
        {
            List<Int32> phaseOpenTime = new List<Int32>();

            return phaseOpenTime;
        }

        private void CommonTaskScheduler()
        {
            Int32 delayTime = 1000;
            Task.Delay(delayTime).ContinueWith((t) =>
            {
                Task<Int32[]> parent = new Task<Int32[]>(() => 
                {
                    var results = new Int32[3]; 
                    new Task(() => results[0] = Sum(10000), TaskCreationOptions.AttachedToParent).Start();
                    new Task(() => results[1] = Sum(20000), TaskCreationOptions.AttachedToParent).Start();
                    new Task(() => results[2] = Sum(30000), TaskCreationOptions.AttachedToParent).Start();
                    return results;
                });
                // When the parent and its children have run to completion, display the results
                var cwt = parent.ContinueWith(parentTask => 
                 { 
                     Array.ForEach(parentTask.Result, Console.WriteLine);
                     Console.WriteLine("来到这里");
                     CommonTaskScheduler();
                 });
                // Start the parent Task so it can start its children
                parent.Start();
                
            });

        }

        private Int32 Sum(Int32 n)
        {
            Int32 sum = 0;
            for (; n > 0; n--)
            {
                checked { sum += n; }
            }
            return sum;
        }
    }
}
