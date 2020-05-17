using Microsoft.VisualStudio.TestTools.UnitTesting;
using My.WebApp.Core.Service.TaxCalculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace My.Tax.UnitTests
{
    [TestClass]
    public class FlatValueCalculatorUnitTests
    {
        private readonly ITaxCalculator _taxCalculator;

        public FlatValueCalculatorUnitTests()
        {
            _taxCalculator = new FlatValueTaxCalculator();
        }


        [TestMethod]
        public void TestFlatValueTaxRetuns10000()
        {
            var annualIncome = 210000.0;

            var result = _taxCalculator.CalcualtionTax(annualIncome);

            Assert.AreEqual(10000, result);
        }

        [TestMethod]
        public void TestFlatValueTaxMultipleFivePercentage()
        {
            var annualIncome = 21000.0;

            var result = _taxCalculator.CalcualtionTax(annualIncome);

            Assert.AreEqual(1050, result);
        }
    }
}
