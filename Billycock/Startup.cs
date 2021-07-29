using Billycock.Data;
using Billycock.Repositories.Interfaces;
using Billycock.Repositories.Repositories;
using Billycock.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Billycock
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
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICuentaRepository, CuentaRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped(typeof(ICommonRepository<>), typeof(CommonRepository<>));
            services.AddScoped<IPlataformaRepository, PlataformaRepository>();
            services.AddScoped<IPlataformaCuentaRepository, PlataformaCuentaRepository>();
            services.AddScoped<IUsuarioPlataformaCuentaRepository, UsuarioPlataformaCuentaRepository>();
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
        }
    }
}
