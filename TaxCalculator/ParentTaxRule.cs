namespace TaxCalculator
{
    public record ParentTaxRule : ITaxRule
    {
        public decimal TaxRate { get; set; }
        public decimal UpperBracket { get; set; }
        public decimal LowerBracket { get; set; }
        public bool HasKids { get; set; }

        public decimal CalculateTax(decimal earnings)
        {
            if (earnings < LowerBracket) return 0;

            var bandAmount = earnings > UpperBracket ? UpperBracket - LowerBracket : earnings - LowerBracket;
            var taxAmount = bandAmount * TaxRate;
            return HasKids && taxAmount < 1000 ? 0 
                : HasKids ? taxAmount - 1000
                : taxAmount;
        }
    }
}