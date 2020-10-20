using System.Collections.Generic;

namespace Oms.Domain.Responses
{
    public class CmResponse
    {
        public string CmsId { get; set; }
        public List<OrderProductResponse> Products { get; set; }
        public string FactoryId { get; set; }
        public OrderDetailsResponse OrderDetails { get; set; }
    }
}
