using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Web.App.RabbitBroker.Connection.Settings
{
    public interface IRabbitConnection
    {
        IConnection Connect();
    }
}
