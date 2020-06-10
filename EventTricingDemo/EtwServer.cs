using InterprocessCommunicaitonContract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTricingDemo
{
    public class EtwServer : EventListener, IIpcServer
    {
        public event EventHandler<DataReceivedEventArgs> ReceivedEvent;

        public void Start()
        {
            this.EnableEvents(EtwClient.Instance, EventLevel.LogAlways);
        }

        public void Stop()
        {
            this.DisableEvents(EtwClient.Instance);
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            if (eventData.EventName == typeof(IIpcClient).Name)
            {
                var data = eventData.Payload[0];
                this.OnReceived(new DataReceivedEventArgs(data.ToString()));
            }
        }

        private void OnReceived(DataReceivedEventArgs data)
        {
            var handler = this.ReceivedEvent;
            if (handler != null)
            {
                handler(handler, data);
            }
        }
    }
}
