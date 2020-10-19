using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Oms.Domain.Entities;
using System.Collections.Generic;

namespace Oms.Infrastructure.SchemaDefinitions
{
    public class CmEntitySchemaDefinition : IEntityTypeConfiguration<Cm>
    {
        public void Configure(EntityTypeBuilder<Cm> builder)
        {
            builder.ToTable("Cms", OmsContext.DEFAULT_SCHEMA);

            builder.HasKey(k => k.CmsId);

            builder.Property(p => p.Products)
                .HasConversion(
                    p => JsonConvert.SerializeObject(p),
                    p => JsonConvert.DeserializeObject<List<OrderProduct>>(p))
                .IsRequired();

            builder
                .HasOne(e => e.OrderDetails)
                .WithMany(c => c.Cms)
                .HasForeignKey(k => k.FactoryId);
        }

    }
}
