using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Web.App.RabbitBroker.Connection.Settings
{
    public class Setting : ISetting
    {
        //This is just for dev, in prod this will be in app settings
        public string HostName { get; private set; } = "localhost";
        public string ExchangeName { get; private set; } = "tax-app-inbound";
        public string RoutingKey { get; private set; } = "tax.app.message";
        public string QueueName { get; private set; } = "tax-app-inbound-queue";
    }
}
