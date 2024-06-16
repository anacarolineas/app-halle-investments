using Halle.Domain.Entities.YahooFinance;
using Halle.Domain.Interfaces;
using YahooFinanceApi;

namespace Halle.Infrastructure.YahooFinance
{
    public sealed class YahooFinanceRepository : IYahooFinanceRepository
    {
        public async Task<IEnumerable<StockQuote>> GetStocksQuotes(string[] symbols)
        {
            var quotes = await Yahoo.Symbols(symbols)
                .QueryAsync();

            return quotes.Values.Select(x => new StockQuote
            {
                Symbol = x.Symbol,
                RegularMarketPrice = x.RegularMarketPrice
            });           
        }
    }
}
