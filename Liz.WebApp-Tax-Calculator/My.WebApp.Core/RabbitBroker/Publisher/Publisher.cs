using My.Web.App.RabbitBroker.Connection.Settings;
using My.WebApp.Core.Models.DbModel;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Web.App.RabbitBroker.Publisher
{
    public class Publisher : IPublisher
    {
        private IRabbitConnection _rabbitConnection;
        private readonly ISetting _setting;

        public Publisher(IRabbitConnection rabbitConnection, ISetting setting)
        {
            _rabbitConnection = rabbitConnection;
            _setting = setting;
        }

        public bool PublishMessage(TaxCalculation taxCalculation)
        {
            try
            {
                using (var channel = _rabbitConnection.Connect().CreateModel())
                {
                    var message = Newtonsoft.Json.JsonConvert.SerializeObject(taxCalculation);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: _setting.ExchangeName,
                                         routingKey: _setting.RoutingKey,
                                         basicProperties: null,
                                         body: body);
                }
            }
            catch (Exception)
            { return false; }

            return true;
        }
    }
}
