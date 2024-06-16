using Halle.Application.Dtos;
using MediatR;

namespace Halle.Application.Features.Rebalancing.GenerateRebalancing
{
    public record GenerateRebalancingRequest : IRequest<IEnumerable<StockRebalancingDto>>
    {
    }
}
