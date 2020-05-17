using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.WebApp.Core.Service.TaxCalculator
{
    public class FlatRateTaxCalculator : ITaxCalculator
    {
        public double CalcualtionTax(double annualIncome)
        {
            return (annualIncome * 17.5) / 100;
        }
    }
}
