using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oms.Domain.Entities;

namespace Oms.Infrastructure.SchemaDefinitions
{
    public class OrderDetailsEntitySchemaDefinition : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.ToTable("OrderDatails", OmsContext.DEFAULT_SCHEMA);

            builder.HasKey(k => k.FactoryId);

            builder.Property(p => p.FactoryName);

            builder.Property(p => p.FactoryAddress);

            builder.Property(p => p.FactoryCountry)
                .IsRequired();

            builder.Property(p => p.ProductionLineId)
                .IsRequired();

            builder.Property(p => p.ProductCode)
                .IsRequired();

            builder.Property(p => p.ProductDescription)
                .IsRequired();

            builder.Property(p => p.PoNumber);

            builder.Property(p => p.ExpectedStartDate);
        }
    }
}
