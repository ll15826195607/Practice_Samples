using System;

namespace InterprocessCommunicaitonContract
{
    public interface IIpcClient
    {
        void Send(String Data);
    }
}
