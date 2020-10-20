using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Oms.Infrastructure;
using System;

namespace Oms.Fixtures
{
    public class InMemoryApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .UseEnvironment("Testing")
                .ConfigureTestServices(services =>
                {
                    var options = new DbContextOptionsBuilder<OmsContext>()
                                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                    .Options;

                    services.AddScoped<OmsContext>(serviceProvider => new TestOmsContext(options));
                
                    var sp = services.BuildServiceProvider();
                    using var scope = sp.CreateScope();
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<OmsContext>();
                db.Database.EnsureCreated();
            });
        }

    }
}
