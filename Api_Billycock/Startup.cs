using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Billycock.Repositories.Repositories;
using Billycock.Repositories.Interfaces;
using Billycock.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Billycock.Utils;

namespace Api_Billycock
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
            services.AddDbContext<BillycockServiceContext>(options => options.UseSqlServer(Configuration["Connection:BillycockServiceConnection"]));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICuentaRepository, CuentaRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped(typeof(ICommonRepository<>), typeof(CommonRepository<>));
            services.AddScoped(typeof(IHistoryRepository<>), typeof(HistoryRepository<>));
            services.AddScoped<IPlataformaRepository, PlataformaRepository>();
            services.AddScoped<IPlataformaCuentaRepository, PlataformaCuentaRepository>();
            services.AddScoped<IUsuarioPlataformaRepository, UsuarioPlataformaRepository>();
            services.AddCors(opciones =>
            {
                opciones.AddPolicy("AllowMyOrigin",
                constructor => constructor.AllowAnyOrigin().AllowAnyHeader());
            });
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

            app.UseAuthorization();

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
