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
        private Socket listenSocket;
        private readonly List<SocketWrapper> proxSockets = new List<SocketWrapper>();
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
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
                            try
                            {
                                this.listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                                IPEndPoint iep = new IPEndPoint(IPAddress.Parse(tbIp.Text), Int16.Parse(tbPort.Text));
                                this.listenSocket.Bind(iep);
                                this.listenSocket.Listen(10);
                                this.listenSocket.BeginAccept(ConnectAccept, this.listenSocket);
                                this.btnStartService.IsEnabled = false;
                                this.tbPort.IsEnabled = false;
                                this.btnSend.IsEnabled = true;
                            }
                            catch (Exception ex)
                            {
                                AddMessage(ex.Message);
                            }
                            
                        }
                        break;
                    case "btnStopService":
                        {
                            if (this.proxSockets != null && this.proxSockets.Count > 0)
                            {
                                foreach (var item in this.proxSockets)
                                {
                                    if (item.workSocket != null)
                                    {
                                        item.workSocket.Close();
                                    }
                                }
                            }
                            if (this.listenSocket != null)
                            {
                                this.listenSocket.Close();
                            }
                            this.btnStartService.IsEnabled = true;
                            this.tbPort.IsEnabled = true;
                            this.btnSend.IsEnabled = false;
                        }
                        break;
                    case "btnSend":
                        {
                            String mess = this.tbSend.Text;
                            if (String.IsNullOrEmpty(mess))
                            {
                                AddMessage("发送消息不能为空");
                                return;
                            }
                            this.tbSend.Clear();
                            foreach (var prox in proxSockets)
                            {
                                if (prox.workSocket != null && prox.workSocket.Connected)
                                {
                                    byte[] data = Encoding.Default.GetBytes(mess);
                                    prox.workSocket.Send(data, 0, data.Length, SocketFlags.None);
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
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            try
            {
                Socket server = ar.AsyncState as Socket;
                Socket client = server.EndAccept(ar);
                SocketWrapper sw = new SocketWrapper()
                {
                    workSocket = client
                };
                AddMessage(String.Format("{0}客户端已连接", client.RemoteEndPoint.ToString()));
                proxSockets.Add(sw);
                client.BeginReceive(new byte[0], 0, 0, SocketFlags.None, messageCallback, sw);
                server.BeginAccept(ConnectAccept, server);
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
            }

        }

        private void messageCallback(IAsyncResult ar)
        {
            var sw = ar.AsyncState as SocketWrapper;

            try
            {
                sw.workSocket.EndReceive(ar);
                
                int bytesReceived = sw.workSocket.Receive(sw.buffer);
                //if (bytesReceived < sw.buffer.Length)
                //{ 
                //    Array.Resize<byte>(ref sw.buffer, bytesReceived);
                //}

                if (bytesReceived == 0)
                {
                    AddMessage(String.Format("{0}客户端退出", sw.workSocket.RemoteEndPoint.ToString()));
                    proxSockets.Remove(sw);
                }
                else
                {
                    AddMessage(string.Format("接收到客户端：{0}的消息是{1}", sw.workSocket.RemoteEndPoint.ToString(), Encoding.Default.GetString(sw.buffer, 0, bytesReceived)));
                    sw.workSocket.BeginReceive(new byte[0], 0, 0, SocketFlags.None, messageCallback, sw);
                }
            }
            catch (Exception ex)
            {
                sw.workSocket.Close();
                sw.workSocket.Dispose();
                Console.WriteLine(ex.Message);
            }
        }

        private void AddMessage(String info)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                this.lbInfo.Items.Insert(0, info);
            }));
        }
    }
}
