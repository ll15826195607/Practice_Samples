using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PipeServerDemo
{
    /// <summary>
    /// 一个管道服务器实例，只能连接一个管道客服端; 可以有多个同名的管道服务实例。哪怕管道客户端关闭连接后，其它管道客户端也是无法连接到这个管道服务实例。
    /// </summary>
    internal sealed class PipeServer
    {
        private readonly NamedPipeServerStream m_Pipe = new NamedPipeServerStream("ECHO", 
            PipeDirection.InOut, -1, 
            PipeTransmissionMode.Message, 
            PipeOptions.Asynchronous | PipeOptions.WriteThrough);
        public PipeServer()
        {
            m_Pipe.BeginWaitForConnection(ClientConnected, null);
        }

        private void ClientConnected(IAsyncResult result)
        {
            new PipeServer();
            m_Pipe.EndWaitForConnection(result);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Byte[] data = new Byte[1000];
            m_Pipe.BeginRead(data, 0, data.Length, GetRequest, data);
        }

        private void GetRequest(IAsyncResult result)
        {
            Int32 br = m_Pipe.EndRead(result);
            if (br == 0)
            {
                Console.WriteLine(String.Format("管道已关闭:{0}", m_Pipe.GetImpersonationUserName()));
                m_Pipe.Close();
            }
            else
            {
                Byte[] data = (Byte[])result.AsyncState;
                String str = Encoding.UTF8.GetString(data, 0, br).ToUpper();
                Console.WriteLine(String.Format("接收到客户端数据:{0}", str));
                data = Encoding.UTF8.GetBytes(str);
                m_Pipe.BeginWrite(data, 0, data.Length, WriteDone, null);
                m_Pipe.BeginRead(data, 0, data.Length, GetRequest, data);
            }
        }

        private void WriteDone(IAsyncResult result)
        {
            m_Pipe.EndWrite(result);
            //m_Pipe.Close();
        }
    }
}
