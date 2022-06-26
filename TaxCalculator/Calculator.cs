using System;
using System.Collections.Generic;
using System.Linq;

namespace TaxCalculator
{
    public class Calculator
    {
        private  List<ProgressiveTaxBracket> taxBrackets;

        public Calculator()
        {
            InitializeProgressiveTaxBrackets();
        }

        public decimal CalculateProgressiveTax(decimal earnings, bool taxExempt = false)
        {
            var earningsRounded = Math.Floor(earnings);
            var taxAmount = 0.00M;

            if (!taxExempt)
            {
                foreach (var bracket in taxBrackets.Where(brk => brk.LowerBracket < earnings))
                {
                    taxAmount += bracket.CalculateTaxInBracket(earningsRounded);
                }
            }
            
            return taxAmount;
        }

        private void InitializeProgressiveTaxBrackets()
        {
            taxBrackets = new List<ProgressiveTaxBracket>();
            taxBrackets.Add(new ProgressiveTaxBracket { TaxRate = 0.33M, LowerBracket = 0, UpperBracket = 24000 });
            taxBrackets.Add(new ProgressiveTaxBracket { TaxRate = 0.175M, LowerBracket = 48000, UpperBracket = 80000 });
            taxBrackets.Add(new ProgressiveTaxBracket { TaxRate = 0.2M, LowerBracket = 24000, UpperBracket = 48000 });
            taxBrackets.Add(new ProgressiveTaxBracket { TaxRate = 0.48M, LowerBracket = 80000, UpperBracket = decimal.MaxValue });
            taxBrackets = taxBrackets.OrderBy(bracket => bracket.LowerBracket).ToList();
        }
    }
}