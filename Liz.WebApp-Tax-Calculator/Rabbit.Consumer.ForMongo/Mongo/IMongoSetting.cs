﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Consumer.Mongo
{
    public interface IMongoSetting
    {
        string ConnectionString { get; }
        string CollectionName { get; }
        string Database { get; }
    }
}
