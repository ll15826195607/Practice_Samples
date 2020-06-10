using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDemo
{
    public class WechatMsgSender : IMsgSender
    {
        private List<String> wechatIds;
        public WechatMsgSender(List<String> wechatIds)
        {
            this.wechatIds = wechatIds;
        }
        public void Send(String message)
        {

        }
    }
}
