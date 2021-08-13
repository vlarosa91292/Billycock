using Billycock.Data;
using Billycock.Repositories.Interfaces;
using Billycock.Repositories.Repositories;
using Billycock.Repositories.Utils;
using Billycock.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Billycock
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped(_ => new BillycockServiceContext(Configuration));
            services.AddScoped(_ => new HilarioServiceContext(Configuration));
            services.AddScoped<IBaseDatosConexion, BaseDatosConexion>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICuentaRepository, CuentaRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped(typeof(ICommonRepository<>), typeof(CommonRepository<>));
            services.AddScoped<IPlataformaRepository, PlataformaRepository>();
            services.AddScoped<IPlataformaCuentaRepository, PlataformaCuentaRepository>();
            services.AddScoped<IUsuarioPlataformaCuentaRepository, UsuarioPlataformaCuentaRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Billycock", Version = "v1", });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Billycock");
            });
        }
    }
}
