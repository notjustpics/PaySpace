using My.WebApp.Core.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Web.App.RabbitBroker.Publisher
{
    public interface IPublisher
    {
        bool PublishMessage(TaxCalculation taxCalculation);
    }
}
