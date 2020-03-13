using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.Data;
using Infra.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Services;
using Shared;

namespace Formularios
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
            services.AddControllers();
            services.AddHealthChecks()
              .AddCheck("self", () => HealthCheckResult.Healthy());

            services.AddMvc()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            services.AddDbContext<FormularioDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("FormularioConnection")));


            services.AddTransient<IModeloService, ModeloService>();
            services.AddTransient<IAtributoService, AtributoService>();
            services.AddTransient<IModeloAtributoService, ModeloAtributoService>();
            services.AddTransient<ITipoAtributoService, TipoAtributoService>();

            services.AddTransient<IModeloRepository, ModeloRepository>();
            services.AddTransient<IAtributoRepository, AtributoRepository>();
            services.AddTransient<IModeloAtributoRepository, ModeloAtributoRepository>();
            services.AddTransient<ITipoAtributoRepository, TipoAtributoRepository>();

            services.AddTransient<IDocumentDBRepository, DocumentDBRepository>();
            services.AddScoped<IContext, FormularioDbContext>(); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHealthChecks("/health", new HealthCheckOptions { Predicate = check => check.Tags.Contains("ready") });
            app.UseHealthChecks("/ready", new HealthCheckOptions
            {
                Predicate = r => r.Tags.Contains("ready")
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
