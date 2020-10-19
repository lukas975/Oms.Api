using Microsoft.EntityFrameworkCore;
using Oms.Domain.Entities;
using Oms.Infrastructure.Tests.Extensions;

namespace Oms.Infrastructure.Tests
{
    public class TestOmsContext : OmsContext
    {
        public TestOmsContext(DbContextOptions<OmsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed<Cm>("./Data/cm.json");
            modelBuilder.Seed<OrderProduct>("./Data/orderproduct.json");
            modelBuilder.Seed<OrderDetails>("./Data/orderdetails.json");
        }

    }
}
