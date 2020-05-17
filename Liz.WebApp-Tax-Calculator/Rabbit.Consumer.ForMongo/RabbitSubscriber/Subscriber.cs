using Newtonsoft.Json;
using Rabbit.Consumer.Mongo.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Rabbit.Consumer.Mongo
{
    public class Subscriber
    {
        EventingBasicConsumer _eventBasicConsumer;
        private readonly IMongoRepository _mongoRepository;

        public Subscriber(IConnection connection, IMongoRepository mongoRepository)
        {
            _mongoRepository = mongoRepository;

            var model = connection.CreateModel();
            model.BasicQos(0, 1, false);
            _eventBasicConsumer = new EventingBasicConsumer(model);
            _eventBasicConsumer.Received += EventBasicConsumer_ReceivedAsync;
            model.BasicConsume("tax-app-inbound-queue", true, _eventBasicConsumer);
        }

        private async void EventBasicConsumer_ReceivedAsync(object sender, BasicDeliverEventArgs e)
        {
            var eventModel = Encoding.UTF8.GetString(e.Body);
            var model = JsonConvert.DeserializeObject<TaxCalculation>(eventModel);

            await _mongoRepository.SaveAsync(model).ContinueWith(x =>
            {
                Console.WriteLine($"Data inserted into table: {JsonConvert.SerializeObject(model)}");
            });
        }
    }
}
