using System;
using System.Collections.Generic;

namespace Oms.Domain.Entities
{
    public class OrderProduct
    {
        public Guid Gtin { get; set; }
        public long Quantity { get; set; }
        public string SerialNumberType { get; set; }
        public List<string> SerialNumbers { get; set; }
        public string TemplateId { get; set; }
    }
}
