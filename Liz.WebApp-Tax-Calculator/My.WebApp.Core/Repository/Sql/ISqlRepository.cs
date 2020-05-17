using My.WebApp.Core.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.WebApp.Core.Repository.Sql
{
    public interface ISqlRepository
    {
        IReadOnlyCollection<LupPostalCode> GetPostalCodes();
        IReadOnlyCollection<LupRate> GetRates();
        IReadOnlyCollection<TaxCalculation> GetTaxCalculations();

        LupCalculationType GetCalculationType(int id);
        LupPostalCode GetPostalCode(string postalCode);
        bool Save(TaxCalculation taxCalculation);
    }
}
