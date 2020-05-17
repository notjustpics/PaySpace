using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rabbit.Consumer.Mongo.Models
{
    public class TaxCalculation
    {
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public decimal TaxCalculated { get; set; }
        public decimal AnnualIncome { get; set; }
        public string CalculationType { get; set; }
    }
}
