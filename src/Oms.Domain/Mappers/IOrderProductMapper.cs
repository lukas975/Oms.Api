using Oms.Domain.Entities;
using Oms.Domain.Responses;

namespace Oms.Domain.Mappers
{
    public interface IOrderProductMapper
    {
        OrderProductResponse Map(OrderProduct orderProduct);
    }
}
