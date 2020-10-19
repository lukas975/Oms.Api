using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Oms.Infrastructure;

namespace Oms.Api.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddOmsContext(this IServiceCollection services, string connectionString)
        {
            return services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<OmsContext>(contextOptions =>
                {
                    contextOptions.UseSqlServer(connectionString,
                        serverOptions => {
                            serverOptions.MigrationsAssembly(typeof(Startup).Assembly.FullName);
                        });
                });
        }

    }
}
