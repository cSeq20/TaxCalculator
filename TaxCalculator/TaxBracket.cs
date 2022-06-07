using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator
{
    public record TaxBracket
    {
        public decimal TaxRate { get; set; }
        public decimal UpperBracket { get; set; }
        public decimal LowerBracket { get; set; }
    }
}
