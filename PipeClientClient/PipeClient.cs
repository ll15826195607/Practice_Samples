using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeClientDemo
{
    internal sealed class PipeClient
    {
        private readonly NamedPipeClientStream m_Pipe;
        public PipeClient(String serverName, String message)
        {
            m_Pipe = new NamedPipeClientStream(serverName, "ECHO", PipeDirection.InOut, PipeOptions.Asynchronous | PipeOptions.WriteThrough);
            m_Pipe.Connect();
            m_Pipe.ReadMode = PipeTransmissionMode.Message;
            Byte[] output = Encoding.UTF8.GetBytes(message);
            m_Pipe.BeginWrite(output, 0, output.Length, WriteDone, null);
        }

        private void WriteDone(IAsyncResult result)
        {
            m_Pipe.EndWrite(result);
            Byte[] data = new Byte[1000];
            m_Pipe.BeginRead(data, 0, data.Length, GetResponse, data);
        }

        private void GetResponse(IAsyncResult result)
        {
            Int32 br = m_Pipe.EndRead(result);
            if (br == 0)
            {
                Console.WriteLine(String.Format("管道已关闭：{0}",m_Pipe));
                m_Pipe.Close();
            }
            else
            {
                Byte[] data = (Byte[])result.AsyncState;
                Console.WriteLine("Server Response: " + Encoding.UTF8.GetString(data, 0, br));
                m_Pipe.BeginRead(data, 0, data.Length, GetResponse, data);
            }
        }
    }
}
