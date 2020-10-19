using Oms.Domain.Entities;
using Oms.Domain.Responses;

namespace Oms.Domain.Mappers
{
    public class OrderProductMapper : IOrderProductMapper
    {
        public OrderProductResponse Map(OrderProduct orderProduct)
        {
            if (orderProduct == null)
                return null;

            return new OrderProductResponse 
            {
                Gtin = orderProduct.Gtin,
                Quantity = orderProduct.Quantity,
                SerialNumberType = orderProduct.SerialNumberType,
                SerialNumbers = orderProduct.SerialNumbers,
                TemplateId = orderProduct.TemplateId
            };
        }
    }
}
