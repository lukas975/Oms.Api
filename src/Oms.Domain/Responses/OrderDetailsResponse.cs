using System;

namespace Oms.Domain.Responses
{
    public class OrderDetailsResponse
    {
        public Guid FactoryId { get; set; }
        public string FactoryName { get; set; }
        public string FactoryAddress { get; set; }
        public string FactoryCountry { get; set; }
        public string ProductionLineId { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public string PoNumber { get; set; }
        public string ExpectedStartDate { get; set; }
    }
}
