using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Oms.Api.Extensions;
using Oms.Domain.Extensions;
using Oms.Domain.Repositories;
using Oms.Infrastructure.Extensions;
using Oms.Infrastructure.Repositories;

namespace Oms.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddOmsContext(Configuration.GetSection("DataSource:ConnectionString").Value)
                .AddScoped<ICmRepository, CmRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddTokenAuthentication(Configuration)
                .AddMappers()
                .AddServices()
                .AddControllers()
                .AddValidation()
                .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
