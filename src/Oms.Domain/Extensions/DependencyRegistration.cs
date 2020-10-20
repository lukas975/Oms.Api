using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Oms.Domain.Mappers;
using Oms.Domain.Services;
using System.Reflection;

namespace Oms.Domain.Extensions
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services
            .AddSingleton<ICmMapper, CmMapper>()
            .AddSingleton<IOrderProductMapper, OrderProductMapper>()
            .AddSingleton<IOrderDetailsMapper, OrderDetailsMapper>();
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddScoped<ICmService, CmService>()
                .AddScoped<IUserService, UserService>();
            return services;
        }
        public static IMvcBuilder AddValidation(this IMvcBuilder builder)
        {
            builder
                .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
            return builder;
        }
    }
}
