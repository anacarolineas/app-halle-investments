using Halle.Domain.Entities.Stock;

namespace Halle.Domain.Interfaces;

public interface IRentabilityRebalancingService
{
    IAsyncEnumerable<StockRebalancing> CalculateRentabilityRebalancing();
}