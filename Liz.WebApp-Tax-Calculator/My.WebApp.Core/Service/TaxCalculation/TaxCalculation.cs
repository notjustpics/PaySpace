using My.WebApp.Core.Models.ViewModels;
using My.WebApp.Core.Repository.Sql;
using My.WebApp.Core.Service.TaxCalculation.Models;
using My.WebApp.Core.Service.TaxCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.WebApp.Core.Service.TaxCalculation
{
    public class TaxCalculation : ITaxCalculation
    {
        private ITaxCalculator _taxCalculator;
        private readonly ISqlRepository _sqlRepository;

        private const string _flatValue = "flatvalue";
        private const string _flatRate = "flatrate";
        private const string _progressive = "progressive";

        public TaxCalculation(ISqlRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;
        }

        public CalculationResponse CalculationIncomeTax(TaxViewModel taxViewModel)
        {
            var annualIncome = taxViewModel.AnnualIncome;

            var postalCode = _sqlRepository.GetPostalCode(taxViewModel.PostalCode);

            var taxType = _sqlRepository
                .GetCalculationType(postalCode.TaxTypeId)
                .TaxTypeName;

            taxType = taxType.Replace(" ", "").ToLower();

            switch (taxType)
            {
                case _flatValue:
                    {
                        _taxCalculator = new FlatValueTaxCalculator();
                        var tax = _taxCalculator.CalcualtionTax(annualIncome);
                        return new CalculationResponse { CalculatedTax = tax, CalculationType = taxType };
                    }
                case _flatRate:
                    {
                        _taxCalculator = new FlatRateTaxCalculator();
                        var tax = _taxCalculator.CalcualtionTax(annualIncome);
                        return new CalculationResponse { CalculatedTax = tax, CalculationType = taxType };
                    }
                case _progressive:
                    {
                        var rates = _sqlRepository.GetRates().ToList();
                        _taxCalculator = new ProgressiveTaxCalculator(rates);
                        var tax = _taxCalculator.CalcualtionTax(annualIncome);
                        return new CalculationResponse { CalculatedTax = tax, CalculationType = taxType };
                    }
                default:
                    return null;
            }
        }
    }
}
