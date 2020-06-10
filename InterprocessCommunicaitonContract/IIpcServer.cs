using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace InterprocessCommunicaitonContract
{
    public interface IIpcServer : IDisposable
    {
        void Start();
        void Stop();
        event EventHandler<DataReceivedEventArgs> ReceivedEvent;
    }
}
