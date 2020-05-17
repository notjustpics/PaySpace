using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Consumer.Mongo
{
    public class MongoSetting : IMongoSetting
    {
        public string ConnectionString { get; private set; }
        public string CollectionName { get; private set; } 
        public string Database { get; private set; } 

        public MongoSetting()
        {
            ConnectionString = "mongodb://localhost:27017/";
            CollectionName = "storetaxcalculation";
            Database = "taxapp";
        }
    }
}
