using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDemo
{
    public abstract class Notificationer
    {
        protected IMsgSender msgSender;
        public Notificationer(IMsgSender msgSender)
        {
            this.msgSender = msgSender;
        }

        public abstract void Notify(String message);
    }
}
