﻿using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeServerDemo
{
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

            Byte[] data = new Byte[1000];
            m_Pipe.BeginRead(data, 0, data.Length, GetRequest, data);
        }

        private void GetRequest(IAsyncResult result)
        {
            Int32 br = m_Pipe.EndRead(result);
            Byte[] data = (Byte[])result.AsyncState;
            data = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(data, 0, br).ToUpper().ToArray());
            m_Pipe.BeginWrite(data, 0, data.Length, WriteDone, null);
        }

        private void WriteDone(IAsyncResult result)
        {
            m_Pipe.EndWrite(result);
            m_Pipe.Close();
        }
    }
}
