using Oms.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Oms.Domain.Requests.Cm
{
    public class AddCmRequest
    {
        public List<OrderProduct> Products { get; set; }
        public Guid? FactoryId { get; set; }
    }
}
