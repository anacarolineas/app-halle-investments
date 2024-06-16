using Halle.Domain.Entities.YahooFinance;

namespace Halle.Domain.Interfaces
{
    public interface IYahooFinanceRepository
    {
        Task<IEnumerable<StockQuote>> GetStocksQuotes(string[] symbols);
    }
}
