namespace Halle.Application.Dtos
{
    public record StockRebalancingDto
    {
        public string Ticker { get; init; } = null!;
        public int Qtd { get; init; }
        public double CurrentQuote { get; init; }
        public double CurrentValue { get; init; }
        public double CurrentPercentage { get; init; }
        public double Goal { get; init; }
        public double GoalDifference { get; init; }
    }
}
