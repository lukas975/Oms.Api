﻿using System.Collections.Generic;

namespace Oms.Domain.Responses
{
    public class OrderProductResponse
    {
        public string Gtin { get; set; }
        public long Quantity { get; set; }
        public string SerialNumberType { get; set; }
        public List<string> SerialNumbers { get; set; }
        public string TemplateId { get; set; }
    }
}
