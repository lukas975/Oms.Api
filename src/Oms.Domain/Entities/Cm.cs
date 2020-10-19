using System;
using System.Collections.Generic;

namespace Oms.Domain.Entities
{
    public class Cm
    {
        public Guid CmsId { get; set; }
        public List<OrderProduct> Products { get; set; }
        public Guid? FactoryId { get; set; }
        public OrderDetails OrderDetails { get; set; }
    }
}
