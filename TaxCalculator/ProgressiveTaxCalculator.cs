using System;
using System.Collections.Generic;
using System.Linq;

namespace TaxCalculator
{
    public class ProgressiveTaxCalculator
    {
        private readonly List<TaxBracket> taxBracket;

        public ProgressiveTaxCalculator()
        {
            taxBracket = new List<TaxBracket>();
            taxBracket.Add(new TaxBracket { TaxRate = 0.33M, LowerBracket = 0, UpperBracket = 24000 });
            taxBracket.Add(new TaxBracket { TaxRate = 0.175M, LowerBracket = 48000, UpperBracket = 80000 });
            taxBracket.Add(new TaxBracket { TaxRate = 0.2M, LowerBracket = 24000, UpperBracket = 48000 });
            taxBracket.Add(new TaxBracket { TaxRate = 0.48M, LowerBracket = 80000, UpperBracket = decimal.MaxValue });
            taxBracket = taxBracket.OrderBy(bracket => bracket.LowerBracket).ToList();
        }

        public decimal Calculate(decimal earnings, bool taxExempt = false)
        {
            var earningsRounded = Math.Floor(earnings);
            var taxAmount = 0.00M;
            if (taxExempt) return taxAmount;

            foreach (var bracket in taxBracket.Where(brk => brk.LowerBracket < earnings))
            {
                taxAmount += CalculateTaxForBracket(bracket, earningsRounded);
            }

            return taxAmount;
        }

        private decimal CalculateTaxForBracket(TaxBracket bracket, decimal earnings)
        {
            var bandAmount = earnings > bracket.UpperBracket ? bracket.UpperBracket - bracket.LowerBracket : earnings - bracket.LowerBracket;
            return bandAmount * bracket.TaxRate;
        }
    }
}