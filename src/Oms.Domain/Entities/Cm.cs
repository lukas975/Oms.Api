using System;
using System.Collections.Generic;

namespace Oms.Domain.Entities
{
    public class Cm
    {
        public string CmsId { get; set; }
        public List<OrderProduct> Products { get; set; }
        public string FactoryId { get; set; }
        public OrderDetails OrderDetails { get; set; }
    }
}
