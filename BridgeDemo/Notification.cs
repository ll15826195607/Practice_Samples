using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDemo
{
    public class Notification
    {
        private List<String> emailAddresses;
        private List<String> telephones;
        private List<String> wechatIds;

        public void SetEmailAddresses(List<String> emailAddresses)
        {
            this.emailAddresses = emailAddresses;
        }

        public void SetTelephones(List<String> telephones)
        {
            this.telephones = telephones;
        }

        public void SetWechatIds(List<String> wechatIds)
        {
            this.wechatIds = wechatIds;
        }

        public void Notify(NotificationEmergencyLevel level, String message)
        {
            switch (level)
            {
                case NotificationEmergencyLevel.SEVERE:
                    break;
                case NotificationEmergencyLevel.URGENCY:
                    break;
                case NotificationEmergencyLevel.NORMAL:
                    break;
                case NotificationEmergencyLevel.TRIVIAL:
                    break;
                default:
                    break;
            }
        }
    }
}
