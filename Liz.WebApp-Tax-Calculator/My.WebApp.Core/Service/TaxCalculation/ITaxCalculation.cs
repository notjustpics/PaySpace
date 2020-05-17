using My.WebApp.Core.Models.ViewModels;
using My.WebApp.Core.Service.TaxCalculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.WebApp.Core.Service.TaxCalculation
{
    public interface ITaxCalculation
    {
        CalculationResponse CalculationIncomeTax(TaxViewModel taxViewModel);
    }
}
