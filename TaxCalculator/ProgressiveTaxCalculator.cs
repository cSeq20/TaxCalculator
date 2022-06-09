using System;
using System.Collections.Generic;
using System.Linq;

namespace TaxCalculator
{
    public class ProgressiveTaxCalculator
    {
        private List<TaxBracket> _taxBracket { get; set; }

        public ProgressiveTaxCalculator()
        {
            _taxBracket = new List<TaxBracket>();
            _taxBracket.Add(new TaxBracket { TaxRate = 0.33M, LowerBracket = 0, UpperBracket = 24000 });
            _taxBracket.Add(new TaxBracket { TaxRate = 0.175M, LowerBracket = 48000, UpperBracket = 80000 });
            _taxBracket.Add(new TaxBracket { TaxRate = 0.2M, LowerBracket = 24000, UpperBracket = 48000 });
            _taxBracket.Add(new TaxBracket { TaxRate = 0.48M, LowerBracket = 80000 });
            _taxBracket = _taxBracket.OrderBy(bracket => bracket.LowerBracket).ToList();
        }

        public decimal Calculate(decimal earnings, int numberOfBrackets)
        {
            var earningsRounded = Math.Floor(earnings);
            var taxAmount = 0.00M;
            _taxBracket[_taxBracket.Count - 1].UpperBracket = earnings;

            for (int i = 0; i <= numberOfBrackets; i++)
            {
                var bandAmount = earningsRounded > _taxBracket[i].UpperBracket ? _taxBracket[i].UpperBracket - _taxBracket[i].LowerBracket : earningsRounded - _taxBracket[i].LowerBracket;
                taxAmount += bandAmount * _taxBracket[i].TaxRate;
            }

            return taxAmount;
        }

        public int NumberOfBracketsBasedOnEarnings(decimal earnings, bool taxExempt = false)
        {
            var earningsRounded = Math.Floor(earnings);

            return earningsRounded <= 0 || taxExempt ? -1
                : earningsRounded > _taxBracket.Max(x => x.LowerBracket) ? _taxBracket.Count - 1
                : _taxBracket.FindIndex(x => x.LowerBracket <= earningsRounded && x.UpperBracket >= earningsRounded);
        }
    }
}