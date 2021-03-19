using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace SocketServer
{
    public class SocketWrapper
    {
        public SocketWrapper()
        {
            sb = new StringBuilder();
        }
        public Socket workSocket { get; set; }
        public const Int32 BUFFER_SIZE = 1024;
        public Byte[] buffer = new Byte[BUFFER_SIZE];

        //接下来自由发挥
        public StringBuilder sb { get; set; }
    }
}
