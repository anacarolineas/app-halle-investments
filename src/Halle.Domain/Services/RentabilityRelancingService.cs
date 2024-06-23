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

        var totalPortfolioValue = CalculateTotalPortfolioValue(stocks, stocksDataCurrent);
        
        foreach (var stock in stocks)
        {
            var currentQuote = (decimal)stocksDataCurrent.First(x => x.Symbol == stock.Ticker).RegularMarketPrice;
            var currentValue = CalculateCurrentValueAsset(currentQuote, stock.Qtd);
            var currentPercentage = CalculateCurrentPercent(currentValue, totalPortfolioValue);
            
            yield return new StockRebalancing
            {
                Ticker = stock.Ticker,
                Qtd = stock.Qtd,
                CurrentValue = currentValue,
                CurrentQuote = currentQuote,
                CurrentPercentage = currentPercentage,
                Goal = stock.Goal,
                GoalDifference = CalculateAdjustmentDifferenceValue(totalPortfolioValue, currentValue, stock.Goal),
                TotalPortfolioValue = totalPortfolioValue
            };
        }
    }

    private decimal CalculateTotalPortfolioValue(Stock[] stocksCurrent, StockQuote[] stocksQuote) =>
        stocksCurrent.Select(x => x.Qtd * (decimal)stocksQuote
            .First(y => x.Ticker == y.Symbol).RegularMarketPrice)
            .Sum();

    private static decimal CalculateCurrentPercent(decimal currentValue, decimal totalPortfolioValue) =>
        (currentValue / totalPortfolioValue) * 100;

    private static decimal CalculateCurrentValueAsset(decimal marketPrice, int qtdCurrent) =>
        marketPrice * qtdCurrent;

    private static decimal CalculateAdjustmentDifferenceValue(decimal totalPortfolioValue, decimal currentValue, decimal desiredPercent)
    {
        var idealValue = totalPortfolioValue * (desiredPercent / 100);
        return idealValue - currentValue;
    }
}