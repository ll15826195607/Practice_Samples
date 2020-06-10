using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDemo
{
    public class TelephoneMsgSender : IMsgSender
    {
        private List<String> telephones;
        public TelephoneMsgSender(List<String> telephones)
        {
            this.telephones = telephones;
        }
        public void Send(String message)
        {
            
        }
    }
}
