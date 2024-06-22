using Halle.Domain.Entities.Stock;
using Halle.Domain.Entities.YahooFinance;
using Halle.Domain.Interfaces;

namespace Halle.Domain.Services;

public class RentabilityRelancingService : IRentabilityRebalancingService
{
    private readonly IStockRepository _stockRepository;
    private readonly IYahooFinanceRepository _yahooFinanceRepository;

    public RentabilityRelancingService(
        IStockRepository stockRepository, 
        IYahooFinanceRepository yahooFinanceRepository)
    {
        _stockRepository = stockRepository;
        _yahooFinanceRepository = yahooFinanceRepository;
    }
    
    public async IAsyncEnumerable<StockRebalancing> CalculateRentabilityRebalancing()
    {
        var stocks = (await _stockRepository.GetStocksByType())
            .ToArray();
        
        var tickers = stocks.Select(x => x.Ticker).ToArray();

        var stocksDataCurrent = (await _yahooFinanceRepository.GetStocksQuotes(tickers))
            .ToArray();

        var amount = CalculateAmount(stocks, stocksDataCurrent);
        
        foreach (var stock in stocks)
        {
            var currentQuote = stocksDataCurrent.First(x => x.Symbol == stock.Ticker).RegularMarketPrice;
            var currentValue = CalculateCurrentValueAsset(currentQuote, stock.Qtd);
            var currentPercentage = CalculateCurrentPercent(currentValue, amount);
            
            yield return new StockRebalancing
            {
                Ticker = stock.Ticker,
                Qtd = stock.Qtd,
                CurrentValue = currentValue,
                CurrentQuote = currentQuote,
                CurrentPercentage = currentPercentage,
                Goal = stock.Goal,
                GoalDifference = (currentPercentage - stock.Goal) * currentValue
            };
        }
    }

    private double CalculateAmount(Stock[] stocksCurrent, StockQuote[] stocksQuote) =>
        stocksCurrent.Select(x => x.Qtd * stocksQuote
            .First(y => x.Ticker == y.Symbol).RegularMarketPrice)
            .Sum();

    private static double CalculateCurrentPercent(double currentValue, double amount) =>
        (currentValue / amount) * 100;

    private static double CalculateCurrentValueAsset(double marketPrice, int qtdCurrent) =>
        marketPrice * qtdCurrent;
}