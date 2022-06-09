using System;
using Xunit;
using TaxCalculator;

namespace TaxCalculatorTests
{
    public class TaxCalculatorTests
    {
        [Fact]
        public void Test_Number_Of_Brackets_Is_Negative_Based_On_Zero_Earnings()
        {
            var taxCalculator = new Calculator();
            var numberOfBrackets = taxCalculator.NumberOfBracketsBasedOnEarnings(0);
            Assert.Equal(-1, numberOfBrackets);
        }

        [Fact]
        public void Test_Number_Of_Brackets_Is_Negative_When_Tax_Exempt()
        {
            var taxCalculator = new Calculator();
            var numberOfBrackets = taxCalculator.NumberOfBracketsBasedOnEarnings(50000, true);
            Assert.Equal(-1, numberOfBrackets);
        }

        [Fact]
        public void Test_Earnings_Is_Within_First_Bracket()
        {
            var taxCalculator = new Calculator();
            var numberOfBrackets = taxCalculator.NumberOfBracketsBasedOnEarnings(20000);
            Assert.Equal(0, numberOfBrackets);
        }

        [Fact]
        public void Test_Earnings_Is_Within_Second_Bracket()
        {
            var taxCalculator = new Calculator();
            var numberOfBrackets = taxCalculator.NumberOfBracketsBasedOnEarnings(40000);
            Assert.Equal(1, numberOfBrackets);
        }

        [Fact]
        public void Test_Earnings_Is_Within_Third_Bracket()
        {
            var taxCalculator = new Calculator();
            var numberOfBrackets = taxCalculator.NumberOfBracketsBasedOnEarnings(60000);
            Assert.Equal(2, numberOfBrackets);
        }

        [Fact]
        public void Test_Earnings_Is_Within_Fourth_Bracket()
        {
            var taxCalculator = new Calculator();
            var numberOfBrackets = taxCalculator.NumberOfBracketsBasedOnEarnings(150000);
            Assert.Equal(3, numberOfBrackets);
        }

        [Fact]
        public void Test_tax_is_zero_given_earnings_are_zero()
        {
            var taxCalculator = new Calculator();
            var numberOfBrackets = taxCalculator.NumberOfBracketsBasedOnEarnings(0);
            var taxAmount = taxCalculator.Calculate(0, numberOfBrackets);
            Assert.Equal(0, taxAmount);
        }

        [Fact]
        public void Test_tax_is_zero_if_earner_is_tax_exempt()
        {
            var taxCalculator = new Calculator();
            var numberOfBrackets = taxCalculator.NumberOfBracketsBasedOnEarnings(50000, true);
            var taxAmount = taxCalculator.Calculate(50000, numberOfBrackets);
            Assert.Equal(0, taxAmount);
        }

        [Fact]
        public void Test_tax_calculation_if_earnings_input_is_decimal()
        {
            var taxCalculator = new Calculator();
            var numberOfBracketsWithDecimal = taxCalculator.NumberOfBracketsBasedOnEarnings(0);
            var taxAmountWithDecimal = taxCalculator.Calculate(50000.65M, numberOfBracketsWithDecimal);

            var numberOfBracketsWithoutDecimal = taxCalculator.NumberOfBracketsBasedOnEarnings(0);
            var taxAmountWithoutDecimal = taxCalculator.Calculate(50000, numberOfBracketsWithoutDecimal); 
            Assert.Equal(taxAmountWithDecimal, taxAmountWithoutDecimal);
        }

        [Fact]
        public void Test_tax_calculation_if_earnings_in_lowest_bracket()
        {
            var taxCalculator = new Calculator();
            var numberOfBrackets = taxCalculator.NumberOfBracketsBasedOnEarnings(20000);
            var taxAmount = taxCalculator.Calculate(20000, numberOfBrackets);
            Assert.Equal(6600, taxAmount);
        }

        [Fact]
        public void Test_tax_calculation_if_earnings_in_second_bracket()
        {
            var taxCalculator = new Calculator();
            var numberOfBrackets = taxCalculator.NumberOfBracketsBasedOnEarnings(40000);
            var taxAmount = taxCalculator.Calculate(40000, numberOfBrackets);
            Assert.Equal(11120, taxAmount);
        }

        [Fact]
        public void Test_tax_calculation_if_earnings_in_third_bracket()
        {
            var taxCalculator = new Calculator();
            var numberOfBrackets = taxCalculator.NumberOfBracketsBasedOnEarnings(60000);
            var taxAmount = taxCalculator.Calculate(60000, numberOfBrackets);
            Assert.Equal(14820, taxAmount);
        }

        [Fact]
        public void Test_tax_calculation_if_earnings_in_fourth_bracket()
        {
            var taxCalculator = new Calculator();
            var numberOfBrackets = taxCalculator.NumberOfBracketsBasedOnEarnings(150000);
            var taxAmount = taxCalculator.Calculate(150000, numberOfBrackets); //chris' salary
            Assert.Equal(51920, taxAmount);
        }
    }
}
