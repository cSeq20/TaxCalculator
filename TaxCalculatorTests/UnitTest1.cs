using System;
using Xunit;
using TaxCalculator;

namespace TaxCalculatorTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_tax_is_zero_given_earnings_are_zero()
        {
            //tax should be zero
            var taxCalculator = new Calculator();
            var taxAmount = taxCalculator.Calculate(0, false);
            Assert.Equal(0, taxAmount);
        }

        [Fact]
        public void Test_tax_returns_error_if_earnings_input_is_null()
        {
            var taxCalculator = new Calculator();
            //var taxAmount = taxCalculator.Calculate(null, false);
            //Assert.Equal(taxAmount, "ArgumentNullException");
        }

        [Fact]
        public void Test_tax_is_zero_if_earner_is_tax_exempt()
        {
            var taxCalculator = new Calculator();
            var taxAmount = taxCalculator.Calculate(50000, true);
            Assert.Equal(0, taxAmount);
        }

        [Fact]
        public void Test_tax_calculation_if_earnings_input_is_decimal()
        {
            var taxCalculator = new Calculator();
            var taxAmountWithDecimal = taxCalculator.Calculate(50000.65M);
            var taxAmountWithoutDecimal = taxCalculator.Calculate(50000); 
            Assert.Equal(taxAmountWithDecimal, taxAmountWithoutDecimal);
        }

        [Fact]
        public void Test_tax_calculation_if_earnings_in_lowest_bracket()
        {
            var taxCalculator = new Calculator();
            var taxAmount = taxCalculator.Calculate(20000, false);
            Assert.Equal(6600, taxAmount);
        }

        [Fact]
        public void Test_tax_calculation_if_earnings_in_second_bracket()
        {
            var taxCalculator = new Calculator();
            var taxAmount = taxCalculator.Calculate(40000, false);
            Assert.Equal(11119.87M, taxAmount);
        }

        [Fact]
        public void Test_tax_calculation_if_earnings_in_third_bracket()
        {
            var taxCalculator = new Calculator();
            var taxAmount = taxCalculator.Calculate(60000, false);
            Assert.Equal(14819.85M, taxAmount);
        }

        [Fact]
        public void Test_tax_calculation_if_earnings_in_fourth_bracket()
        {
            var taxCalculator = new Calculator();
            var taxAmount = taxCalculator.Calculate(150000, false); //chris' salary
            Assert.Equal(51920.15M, taxAmount);
        }

        //[Fact]
        //public void Test1()
        //{

            // earning upto 24000
            // earning from 24000 to 48000
            // earning from 48000 to 80000
            // earning from 80000

            // negative or 0 input
            // null imput
            // not a int

            // tests pull in the constants
            // cents - decimal

            // have error handling

            // tax exempt?

            // foreach so we don't have to add more code if tax brackets are added

            // 
        //}
    }
}
