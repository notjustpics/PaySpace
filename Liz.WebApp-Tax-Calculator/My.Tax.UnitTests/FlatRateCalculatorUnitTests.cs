using Microsoft.VisualStudio.TestTools.UnitTesting;
using My.WebApp.Core.Service.TaxCalculator;

namespace My.Tax.UnitTests
{
    [TestClass]
    public class FlatRateCalculatorUnitTests
    {
        private readonly ITaxCalculator _taxCalculator;

        public FlatRateCalculatorUnitTests()
        {
            _taxCalculator = new FlatRateTaxCalculator();
        }

        [TestMethod]
        public void TestFlatRateTax()
        {
            var annualIncome = 100000.0;

            var result = _taxCalculator.CalcualtionTax(annualIncome);

            Assert.AreEqual(17500, result);
        }
    }
}
