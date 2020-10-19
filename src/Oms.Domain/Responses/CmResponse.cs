using System;
using System.Collections.Generic;

namespace Oms.Domain.Responses
{
    public class CmResponse
    {
        public Guid CmsId { get; set; }
        public List<OrderProductResponse> Products { get; set; }
        public Guid? FactoryId { get; set; }
        public OrderDetailsResponse OrderDetails { get; set; }
    }
}
