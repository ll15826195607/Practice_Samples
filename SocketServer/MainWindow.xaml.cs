using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SocketServer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<Socket> proxSockets = new List<Socket>();
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.lbInfo.Items.Insert(0, Thread.CurrentThread.ManagedThreadId);
            this.tbIp.Text = GetLocalIPAddress();
        }

        private String GetLocalIPAddress()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                if (endPoint != null)
                {
                    return endPoint.Address.ToString();
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                switch (btn.Name)
                {
                    case "btnStartService":
                        {
                            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(tbIp.Text), Int16.Parse(tbPort.Text));
                            server.Bind(iep);
                            server.Listen(10);
                            server.BeginAccept(ConnectAccept, server);
                            btn.IsEnabled = false;
                        }
                        break;
                    case "btnSend":
                        {
                            foreach (var prox in proxSockets)
                            {
                                if (prox.Connected)
                                {
                                    byte[] data = Encoding.Default.GetBytes(tbSend.Text);
                                    prox.Send(data, 0, data.Length, SocketFlags.None);
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void ConnectAccept(IAsyncResult ar)
        {
            Socket server = ar.AsyncState as Socket;

            Socket client =  server.EndAccept(ar);
            if (client != null && proxSockets.Contains(client) ==false)
            {
                proxSockets.Add(client);
            }
            client.BeginReceive(new byte[] { 0 }, 0, 0, SocketFlags.None, messageCallback, client);
            server.BeginAccept(ConnectAccept, server);

            Int32 tid = Thread.CurrentThread.ManagedThreadId;
            this.Dispatcher.Invoke(new Action(() =>
            {
                this.lbInfo.Items.Insert(0, tid);
            }));
        }

        private void messageCallback(IAsyncResult ar)
        {
            Socket client = ar.AsyncState as Socket;

            try
            {
                client.EndReceive(ar);

                // Read the incomming message 
                byte[] messageBuffer = new byte[1024];
                int bytesReceived = client.Receive(messageBuffer);


                // Start to receive messages again
                client.BeginReceive(new byte[] { 0 }, 0, 0, SocketFlags.None, messageCallback, client);

            }
            catch (Exception ex)
            {
                client.Close();
                client.Dispose();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
