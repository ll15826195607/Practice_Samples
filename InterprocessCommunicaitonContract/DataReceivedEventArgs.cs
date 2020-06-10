using System;
using System.Collections.Generic;
using System.Text;

namespace InterprocessCommunicaitonContract
{
    public sealed class DataReceivedEventArgs : EventArgs
    {
        public String Data { get; private set; }
        public DataReceivedEventArgs(String data)
        {
            this.Data = data;
        }
    }
}
