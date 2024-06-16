using Halle.Domain.Interfaces;
using System.Text.Json;
using StockDomain = Halle.Domain.Entities.Stock;

namespace Halle.Infrastructure.Stock
{
    public sealed class StockRepository : IStockRepository
    {
        private const string PathDb = @"..\Halle.Infrastructure\db.json";

        public async Task<IEnumerable<StockDomain.Stock>> GetStocksByType()
        {
            string file = await File.ReadAllTextAsync(PathDb);
            return JsonSerializer.Deserialize<StockDomain.Stock[]>(file) ?? Enumerable.Empty<StockDomain.Stock>();
        }
    }
}
