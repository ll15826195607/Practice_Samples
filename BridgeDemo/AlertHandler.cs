using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDemo
{
    public abstract class AlertHandler
    {
        protected Notification notification;
        protected AlertRule rule;
        public AlertHandler(AlertRule rule, Notification notification)
        {
            this.rule = rule;
            this.notification = notification;
        }

        public abstract void Check(ApiStateInfo apiStateInfo);
    }
}
