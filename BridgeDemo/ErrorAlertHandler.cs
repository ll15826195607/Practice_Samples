using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDemo
{
    public class ErrorAlertHandler : AlertHandler
    {
        public ErrorAlertHandler(AlertRule rule, Notification notification) : base(rule, notification)
        {

        }
        public override void Check(ApiStateInfo apiStateInfo)
        {
            if (apiStateInfo.errorCount > rule.GetMaxErrorCount(apiStateInfo.api))
            {
                notification.Notify(NotificationEmergencyLevel.SEVERE, String.Empty);
            }
        }
    }
}
