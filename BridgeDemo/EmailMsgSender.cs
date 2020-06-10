using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDemo
{
    public class EmailMsgSender : IMsgSender
    {
        private List<String> emailAddresses;
        public EmailMsgSender(List<String> emailAddresses)
        {
            this.emailAddresses = emailAddresses;
        }
        public void Send(String message)
        {

        }
    }
}
