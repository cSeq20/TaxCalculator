using System;
using Xunit;
using TaxCalculator;

namespace TaxCalculatorTests
{
    public class TaxCalculatorTests
    {
        [Fact]
        public void Test_tax_is_zero_given_earnings_are_zero()
        {
            var taxCalculator = new ProgressiveCalculator();
            var taxAmount = taxCalculator.Calculate(0);
            Assert.Equal(0, taxAmount);
        }

        [Fact]
        public void Test_tax_is_zero_if_earner_is_tax_exempt()
        {
            var taxCalculator = new ProgressiveCalculator();
            var taxAmount = taxCalculator.Calculate(50000, true);
            Assert.Equal(0, taxAmount);
        }

        [Fact]
        public void Test_tax_calculation_if_earnings_input_is_decimal()
        {
            var taxCalculator = new ProgressiveCalculator();
            var taxAmountWithDecimal = taxCalculator.Calculate(50000.65M);
            
            var taxAmountWithoutDecimal = taxCalculator.Calculate(50000); 
            Assert.Equal(taxAmountWithDecimal, taxAmountWithoutDecimal);
        }

        [Fact]
        public void Test_tax_calculation_if_earnings_in_lowest_bracket()
        {
            var taxCalculator = new ProgressiveCalculator();
            var taxAmount = taxCalculator.Calculate(20000);
            Assert.Equal(6600, taxAmount);
        }

        [Fact]
        public void Test_tax_calculation_if_earnings_in_second_bracket()
        {
            var taxCalculator = new ProgressiveCalculator();
            var taxAmount = taxCalculator.Calculate(40000);
            Assert.Equal(11120, taxAmount);
        }

        [Fact]
        public void Test_tax_calculation_if_earnings_in_third_bracket()
        {
            var taxCalculator = new ProgressiveCalculator();
            var taxAmount = taxCalculator.Calculate(60000);
            Assert.Equal(14820, taxAmount);
        }

        [Fact]
        public void Test_tax_calculation_if_earnings_in_fourth_bracket()
        {
            var taxCalculator = new ProgressiveCalculator();
            var taxAmount = taxCalculator.Calculate(150000); //chris' salary
            Assert.Equal(51920, taxAmount);
        }
    }
}
