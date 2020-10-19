using Microsoft.EntityFrameworkCore;
using Oms.Domain.Mappers;
using Oms.Infrastructure;
using System;

namespace Oms.Fixtures
{
    public class OmsContextFactory
    {
        public readonly TestOmsContext ContextInstance;
        public readonly IOrderDetailsMapper OrderDetailsMapper;
        public readonly IOrderProductMapper OrderProductMapper;
        public readonly ICmMapper CmMapper;

        public OmsContextFactory()
        {
            var contextOptions = new DbContextOptionsBuilder<OmsContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            EnsureCreation(contextOptions);

            ContextInstance = new TestOmsContext(contextOptions);

            OrderDetailsMapper = new OrderDetailsMapper();

            OrderProductMapper = new OrderProductMapper();

            CmMapper = new CmMapper(OrderProductMapper, OrderDetailsMapper);
        }

        private void EnsureCreation(DbContextOptions<OmsContext> contextOptions)
        {
            using var context = new TestOmsContext(contextOptions);

            context.Database.EnsureCreated();
        }
    }
}
