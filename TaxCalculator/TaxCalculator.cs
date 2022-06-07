using System;
using System.Collections.Generic;
using System.Linq;

namespace TaxCalculator
{
    public class Calculator
    {
        private List<TaxBracket> _taxBracket { get; set; }

        public Calculator()
        {
            _taxBracket = new List<TaxBracket>();
            _taxBracket.Add(new TaxBracket { TaxRate = 0.33M, LowerBracket = 0, UpperBracket = 23999 });
            _taxBracket.Add(new TaxBracket { TaxRate = 0.2M, LowerBracket = 24000, UpperBracket = 47999 });
            _taxBracket.Add(new TaxBracket { TaxRate = 0.175M, LowerBracket = 48000, UpperBracket = 79999 });
            _taxBracket.Add(new TaxBracket { TaxRate = 0.48M, LowerBracket = 80000 });
        }

        public decimal Calculate(decimal input, bool taxExempt = false)
        {
            var taxAmount = 0.00M;
            var remainToCalculate = input;
            var count = 0;
            _taxBracket[_taxBracket.Count - 1].UpperBracket = input;

            do
            {
                // input = 150,000
                // should go through 4 tax brackets
                // first loop - taxAmount = 23999 * 0.33
                // 
                // break
                var test = _taxBracket[count].UpperBracket < input 
                    ? _taxBracket[count].UpperBracket - _taxBracket[count].LowerBracket
                    : input - _taxBracket[count].LowerBracket;

                taxAmount += test * _taxBracket[count].TaxRate;
                count++;
            }
            while (input > _taxBracket[count].LowerBracket && count <= _taxBracket.Count);

            return taxAmount;
        }
    }
}