using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SocketClient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SocketWrapper clientSw = new SocketWrapper();
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
                    case "btnConnection":
                        {
                            try
                            {
                                this.clientSw.workSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                                IPEndPoint iep = new IPEndPoint(IPAddress.Parse(tbIp.Text), Int16.Parse(tbPort.Text));
                                this.clientSw.workSocket.BeginConnect(iep, ConnectionCallback,this.clientSw);
                            }
                            catch (Exception ex)
                            {
                                AddMessage(ex.Message);
                            }

                        }
                        break;
                    case "btnDisconnection":
                        {
                            if (this.clientSw.workSocket != null && this.clientSw.workSocket.Connected)
                            {
                                this.clientSw.workSocket.Close();
                            }
                            this.btnConnection.IsEnabled = true;
                            this.btnDisconnection.IsEnabled = false;
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
                            if (this.clientSw.workSocket != null && this.clientSw.workSocket.Connected)
                            {
                                byte[] data = Encoding.Default.GetBytes(mess);
                                this.clientSw.workSocket.Send(data, 0, data.Length, SocketFlags.None);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void ConnectionCallback(IAsyncResult ar)
        {
            try
            {
                var sw = ar.AsyncState as SocketWrapper;
                sw.workSocket.EndConnect(ar);
                AddMessage(String.Format("连接 {0} 成功",sw.workSocket.RemoteEndPoint.ToString()));
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    this.btnConnection.IsEnabled = false;
                    this.btnDisconnection.IsEnabled = true;
                    this.btnSend.IsEnabled = true;
                }));
                sw.workSocket.BeginReceive(new Byte[0], 0, 0, SocketFlags.None, messageCallback, sw);
            }
            catch (Exception ex)
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    this.btnConnection.IsEnabled = true;
                    this.btnDisconnection.IsEnabled = false;
                    this.btnSend.IsEnabled = false;
                }));
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
                    AddMessage(String.Format("{0} 被服务器断开", sw.workSocket.LocalEndPoint.ToString()));
                    sw.workSocket.Close();
                }
                else
                {
                    AddMessage(string.Format("接收到 {0} 的消息是: {1}", sw.workSocket.RemoteEndPoint.ToString(), Encoding.Default.GetString(sw.buffer, 0, bytesReceived)));
                    sw.workSocket.BeginReceive(new byte[0], 0, 0, SocketFlags.None, messageCallback, sw);
                }
            }
            catch (Exception ex)
            {
                sw.workSocket.Close();
                sw.workSocket.Dispose();
                AddMessage(ex.Message);
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
