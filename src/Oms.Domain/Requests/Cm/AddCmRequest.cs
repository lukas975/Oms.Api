using Oms.Domain.Entities;
using System.Collections.Generic;

namespace Oms.Domain.Requests.Cm
{
    public class AddCmRequest
    {
        public string CmsId { get; set; }
        public List<OrderProduct> Products { get; set; }
        public string FactoryId { get; set; }
    }
}
