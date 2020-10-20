using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Oms.Domain.Entities;
using System.Collections.Generic;

namespace Oms.Infrastructure.SchemaDefinitions
{
    public class OrderProductEntitySchemaDefinition : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("OrderProduct", OmsContext.DEFAULT_SCHEMA);

            builder.HasKey(k => k.Gtin);

            builder.Property(p => p.Gtin)
                .HasMaxLength(14)
                .IsFixedLength();

            builder.Property(p => p.Quantity)
                .IsRequired();

            builder.Property(p => p.SerialNumberType)
                .IsRequired();

            builder.Property(p => p.SerialNumbers)
                .HasConversion(
                    p => JsonConvert.SerializeObject(p),
                    p => JsonConvert.DeserializeObject<List<string>>(p))
                .IsRequired();

            builder.Property(p => p.TemplateId)
                .IsRequired();
        }
    }
}
