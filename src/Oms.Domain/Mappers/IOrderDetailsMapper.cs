using Oms.Domain.Entities;
using Oms.Domain.Responses;

namespace Oms.Domain.Mappers
{
    public interface IOrderDetailsMapper
    {
        OrderDetailsResponse Map(OrderDetails orderDetails);
    }
}
