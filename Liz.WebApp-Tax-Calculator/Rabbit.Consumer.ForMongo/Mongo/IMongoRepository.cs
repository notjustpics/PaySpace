using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Consumer.Mongo
{
    public interface IMongoRepository
    {
        Task<bool> SaveAsync(object message);
    }
}
