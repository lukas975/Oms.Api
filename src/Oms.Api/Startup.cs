using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Oms.Api.Extensions;
using Oms.Domain.Extensions;
using Oms.Domain.Repositories;
using Oms.Infrastructure;
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
            //services
            //    .AddEntityFrameworkSqlServer()
            //    .AddOmsContext(Configuration.GetSection("DataSource:ConnectionString").Value)
            //    .AddMappers()
            //    .AddServices()
            //    .AddControllers()
            //    .AddValidation();
            services
                .AddOmsContext(Configuration.GetSection("DataSource:ConnectionString").Value)
                .AddScoped<ICmRepository, CmRepository>()
                //.AddScoped<IOrderProductRepository, OrderRepository>()
                //.AddScoped<IGenreRepository, GenreRepository>()
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
