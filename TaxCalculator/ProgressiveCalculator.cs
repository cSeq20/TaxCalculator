using System;
using System.Collections.Generic;
using System.Linq;

namespace TaxCalculator
{
    public class ProgressiveCalculator : ICalculator
    {
        private  List<ITaxRule> taxRules;

        public ProgressiveCalculator()
        {
            InitializeProgressivetaxRules();
        }

        public decimal Calculate(decimal earnings, bool taxExempt = false)
        {
            if (taxExempt) return 0;

            var earningsRounded = Math.Floor(earnings);
            return taxRules.Sum(rule => rule.CalculateTax(earningsRounded));
        }

        private void InitializeProgressivetaxRules()
        {
            taxRules = new List<ITaxRule>();
            taxRules.Add(new ParentTaxRule { TaxRate = 0.33M, LowerBracket = 0, UpperBracket = 24000, HasKids = false });
            taxRules.Add(new ParentTaxRule { TaxRate = 0.175M, LowerBracket = 48000, UpperBracket = 80000, HasKids = false });
            taxRules.Add(new ParentTaxRule { TaxRate = 0.2M, LowerBracket = 24000, UpperBracket = 48000, HasKids = false });
            taxRules.Add(new ParentTaxRule { TaxRate = 0.48M, LowerBracket = 80000, UpperBracket = decimal.MaxValue, HasKids = true });
        }
    }
}