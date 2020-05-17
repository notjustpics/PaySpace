using My.WebApp.Core.Models.DbModel;
using My.WebApp.Core.Repository.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.WebApp.Core.Service.TaxCalculator
{
    public class ProgressiveTaxCalculator : ITaxCalculator
    {
        private List<LupRate> _rate;

        public ProgressiveTaxCalculator(List<LupRate> rate)
        {
            _rate = rate;
        }
        public double CalcualtionTax(double annualIncome)
        {
            var percentage = _rate.Find(x => x.FromRate <= (decimal)annualIncome
            && x.ToRate >= (decimal)annualIncome)
            .Rate;

            var tax = ((decimal)annualIncome * percentage) / 100;

            return (double)tax;
        }
    }
}
