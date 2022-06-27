namespace TaxCalculator
{
    public record ProgressiveTaxBracket
    {
        public decimal TaxRate { get; set; }
        public decimal UpperBracket { get; set; }
        public decimal LowerBracket { get; set; }
    }

    private decimal CalculateTaxInBracket(decimal earnings)
    {
        var bandAmount = earnings > UpperBracket ? UpperBracket - LowerBracket : earnings - LowerBracket;
        return bandAmount * TaxRate;
    }
}
