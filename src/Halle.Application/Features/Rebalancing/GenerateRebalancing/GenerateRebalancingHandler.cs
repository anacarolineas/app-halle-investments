using Halle.Application.Dtos;
using Halle.Domain.Enumerables;
using Halle.Domain.Interfaces;
using MediatR;

namespace Halle.Application.Features.Rebalancing.GenerateRebalancing
{
    public sealed class GenerateRebalancingHandler : IRequestHandler<GenerateRebalancingRequest, IEnumerable<StockRebalancingDto>>
    {
        private readonly IRentabilityRebalancingService _rentabilityRebalancing;

        public GenerateRebalancingHandler(IRentabilityRebalancingService rentabilityRebalancing) => 
            _rentabilityRebalancing = rentabilityRebalancing;

        public async Task<IEnumerable<StockRebalancingDto>> Handle(GenerateRebalancingRequest request, CancellationToken cancellationToken)
        {
            var stocksRebalancing = _rentabilityRebalancing.CalculateRentabilityRebalancing();

            var stocksRebalancingMap = new List<StockRebalancingDto>();
            
            await foreach (var stock in stocksRebalancing.WithCancellation(cancellationToken))
            {
                stocksRebalancingMap.Add(new StockRebalancingDto
                {
                    Ticker = stock.Ticker,
                    Qtd = stock.Qtd,
                    CurrentValue = stock.CurrentValue,
                    CurrentQuote = stock.CurrentQuote,
                    CurrentPercentage = stock.CurrentPercentage,
                    Goal = stock.Goal,
                    GoalDifference = stock.GoalDifference,
                    TotalPortfolioValue = stock.TotalPortfolioValue,
                    Strategy = stock.GoalDifference < 0 ? StrategyType.Hold : StrategyType.Buy
                });
            }
            
            return stocksRebalancingMap.OrderBy(x => x.Ticker);
        }
    }
}
