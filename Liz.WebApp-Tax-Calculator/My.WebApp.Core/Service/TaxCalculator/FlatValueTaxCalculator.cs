using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.WebApp.Core.Service.TaxCalculator
{
    public class FlatValueTaxCalculator : ITaxCalculator
    {
        public double CalcualtionTax(double annualIncome)
        {
            //const double flatRate = 10000.0;
            const double flatRate = 10000;

            if (annualIncome < 200000)
            {
                return (annualIncome * 0.05);
            }

            return flatRate;
        }
    }
}
