using MongoDB.Driver.Core.Connections;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Consumer.Mongo
{
    class Program
    {
        private static RabbitMQ.Client.IConnectionFactory _connectionFactory;
        private static RabbitMQ.Client.IConnection _connection;
        private static IMongoRepository _mongoRepository;
        private static IMongoSetting _mongoSetting;

        //Set to false to not consume from rabbit and insert to mongo
        private readonly static bool doMongoInsert = true;

        static void Main(string[] args)
        {
            if (doMongoInsert)
            {               
                Console.WriteLine($"Listening for events from rabbit :)");

                _connectionFactory = new ConnectionFactory { HostName = "localhost" };
                _connection = _connectionFactory.CreateConnection();

                _mongoSetting = new MongoSetting();
                _mongoRepository = new MongoRepository(_mongoSetting);

                var sub = new Subscriber(_connection, _mongoRepository);
            }

            Console.WriteLine($"Mode to process set to : {doMongoInsert}");
            Console.Read();
        }
    }
}
