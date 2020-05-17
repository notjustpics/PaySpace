using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My.WebApp.Core.Models.DbModel;

namespace My.WebApp.Core.Repository.Sql
{
    public class SqlRepository : ISqlRepository
    {
        private readonly TaxDbContext _taxDbContext;

        public SqlRepository()
        {
            _taxDbContext = new TaxDbContext();
        }

        public LupCalculationType GetCalculationType(int id)
        {
            return _taxDbContext.LupCalculationType.Where(x => x.TaxTypeId == id).SingleOrDefault();
        }

        public LupPostalCode GetPostalCode(string postalCode)
        {
            return _taxDbContext.LupPostalCode.SingleOrDefault(x => x.PostalCode == postalCode);
        }

        public IReadOnlyCollection<LupPostalCode> GetPostalCodes()
        {
            return _taxDbContext.LupPostalCode.ToList();
        }

        public IReadOnlyCollection<LupRate> GetRates()
        {
            return _taxDbContext.LupRate.ToList();
        }

        public IReadOnlyCollection<TaxCalculation> GetTaxCalculations()
        {
            return _taxDbContext.TaxCalculation.ToList();
        }

        public bool Save(TaxCalculation taxCalculation)
        {
            _taxDbContext.TaxCalculation.Add(taxCalculation);
            var result =_taxDbContext.SaveChanges();

            if (result > double.Epsilon)
                return true;

            return false;
        }
    }
}
