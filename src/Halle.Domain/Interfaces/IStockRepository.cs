using Halle.Domain.Entities.Stock;

namespace Halle.Domain.Interfaces
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetStocksByType();
    }
}
