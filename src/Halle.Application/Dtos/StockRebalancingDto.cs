using Halle.Domain.Enumerables;

namespace Halle.Application.Dtos
{
    public record StockRebalancingDto
    {
        public string Ticker { get; init; } = null!;
        public int Qtd { get; init; }
        public decimal CurrentQuote { get; init; }
        public decimal CurrentValue { get; init; }
        public decimal CurrentPercentage { get; init; }
        public decimal Goal { get; init; }
        public decimal GoalDifference { get; init; }
        public decimal TotalPortfolioValue { get; init; }
        public StrategyType Strategy { get; init; }
    }
}
