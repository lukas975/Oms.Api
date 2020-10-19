using Oms.Domain.Entities;
using Oms.Domain.Responses;

namespace Oms.Domain.Mappers
{
    public class OrderDetailsMapper : IOrderDetailsMapper
    {
        public OrderDetailsResponse Map(OrderDetails orderDetails)
        {
            if (orderDetails == null)
                return null;

            return new OrderDetailsResponse
            {
                FactoryId = orderDetails.FactoryId,
                FactoryName = orderDetails.FactoryName,
                FactoryAddress = orderDetails.FactoryAddress,
                FactoryCountry = orderDetails.FactoryCountry,
                ProductionLineId = orderDetails.ProductionLineId,
                ProductCode = orderDetails.ProductCode,
                ProductDescription = orderDetails.ProductDescription,
                PoNumber = orderDetails.PoNumber,
                ExpectedStartDate = orderDetails.ExpectedStartDate
            };

        }
    }
}
