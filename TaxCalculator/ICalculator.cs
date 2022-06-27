using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator
{
    public interface ICalculator
    {
        decimal Calculate(decimal earnings, bool taxExempt = false);
    }
}
