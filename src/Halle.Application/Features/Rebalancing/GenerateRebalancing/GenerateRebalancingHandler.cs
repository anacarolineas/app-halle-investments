using Halle.Application.Dtos;
using Halle.Domain.Interfaces;
using MediatR;

namespace Halle.Application.Features.Rebalancing.GenerateRebalancing
{
    public sealed class GenerateRebalancingHandler : IRequestHandler<GenerateRebalancingRequest, IEnumerable<StockRebalancingDto>>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IYahooFinanceRepository _yahooFinanceRepository;

        public GenerateRebalancingHandler(
            IStockRepository stockRepository,
            IYahooFinanceRepository yahooFinanceRepository)
        {
            _stockRepository = stockRepository;
            _yahooFinanceRepository = yahooFinanceRepository;
        }

        public async Task<IEnumerable<StockRebalancingDto>> Handle(GenerateRebalancingRequest request, CancellationToken cancellationToken)
        {
            var stocks = (await _stockRepository.GetStocksByType())
                .ToArray();
            
            var tickers = stocks.Select(x => x.Ticker).ToArray();

            var stocksDataCurrent = (await _yahooFinanceRepository.GetStocksQuotes(tickers))
                .ToArray();

            var stocksRebalancing = new List<StockRebalancingDto>();
            double amount = 0;

            foreach (var stock in stocks)
            {
                var currentQuote = stocksDataCurrent.First(x => x.Symbol == stock.Ticker).RegularMarketPrice;
                var currentValue = currentQuote * stock.Qtd;

                var stockRebalancing = new StockRebalancingDto
                {
                    Ticker = stock.Ticker,
                    Qtd = stock.Qtd,
                    CurrentValue = currentValue,
                    CurrentQuote = currentQuote,
                    Goal = stock.Goal
                };

                stocksRebalancing.Add(stockRebalancing);

                amount += currentValue;
            }

            return stocksRebalancing.Select(x => new StockRebalancingDto
            {
                Ticker = x.Ticker,
                Qtd = x.Qtd,
                CurrentValue = x.CurrentValue,
                CurrentQuote = x.CurrentQuote,
                Goal = x.Goal,
                CurrentPercentage = (x.CurrentValue / amount) * 100
            });
        }
    }
}
