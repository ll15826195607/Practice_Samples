﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDemo
{
    public class SevereNotificationer : Notificationer
    {
        public SevereNotificationer(IMsgSender msgSender):base(msgSender)
        {

        }
        public override void Notify(string message)
        {
            msgSender.Send(message);
        }
    }
}
