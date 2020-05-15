using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace KeyboardMouseIdleTimeDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer KeyboardMouseIdleTimer = new DispatcherTimer();
        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO lii);
        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            /// <summary>
            /// 结构体容量
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public UInt32 cbSize;
            /// <summary>
            /// 收到最后一个输入事件时的滴答计数
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dwTime;
        }
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            KeyboardMouseIdleTimer.Tick += KeyboardMouseIdleTimer_Tick;
            KeyboardMouseIdleTimer.Interval = TimeSpan.FromMilliseconds(1000);
            KeyboardMouseIdleTimer.Start();
        }

        private void KeyboardMouseIdleTimer_Tick(object sender, EventArgs e)
        {
            this.tb.Text = (GetKeyboardMouseIdleTime() / 1000).ToString();
        }

        private Int64 GetKeyboardMouseIdleTime()
        {
            LASTINPUTINFO info = new LASTINPUTINFO();
            info.cbSize = (UInt32)Marshal.SizeOf(info);
            Boolean result = GetLastInputInfo(ref info);
            if (result == true)
            {
                Console.WriteLine(Environment.TickCount + " : " + info.dwTime);

                return Environment.TickCount - info.dwTime;
            }
            else
            {
                return 0;
            }
        }
    }
}
