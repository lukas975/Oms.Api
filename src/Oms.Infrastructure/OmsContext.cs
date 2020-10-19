using Microsoft.EntityFrameworkCore;
using Oms.Domain.Entities;
using Oms.Domain.Repositories;
using Oms.Infrastructure.SchemaDefinitions;
using System.Threading;
using System.Threading.Tasks;

namespace Oms.Infrastructure
{
    public class OmsContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "oms";
        public DbSet<Cm> Cms { get; set; }

        public OmsContext(DbContextOptions<OmsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CmEntitySchemaDefinition());
            modelBuilder.ApplyConfiguration(new OrderProductEntitySchemaDefinition());
            modelBuilder.ApplyConfiguration(new OrderDetailsEntitySchemaDefinition());

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
