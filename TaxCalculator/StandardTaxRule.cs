namespace TaxCalculator
{
    public record StandardTaxRule : ITaxRule
    {
        public decimal TaxRate { get; set; }
        public decimal UpperBracket { get; set; }
        public decimal LowerBracket { get; set; }

        public decimal CalculateTax(decimal earnings)
        {
            if (earnings < LowerBracket) return 0;

            var bandAmount = earnings > UpperBracket ? UpperBracket - LowerBracket : earnings - LowerBracket;
            return bandAmount * TaxRate;
        }
    }    
}
