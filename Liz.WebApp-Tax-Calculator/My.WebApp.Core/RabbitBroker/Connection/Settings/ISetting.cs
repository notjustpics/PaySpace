using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Web.App.RabbitBroker.Connection.Settings
{
    public interface ISetting
    {
        string HostName { get; }
        string ExchangeName { get; }
        string RoutingKey { get; }
        string QueueName { get; }
    }
}
