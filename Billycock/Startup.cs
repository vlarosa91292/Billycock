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
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace Billycock
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            Environment.SetEnvironmentVariable("Server", ".");
            Environment.SetEnvironmentVariable("UserId", "sa");
            Environment.SetEnvironmentVariable("Password", "Nayjuw+29");
            Environment.SetEnvironmentVariable("Database_B", "Billycock_Desarrollo");
            Environment.SetEnvironmentVariable("Database_H", "Hilario_Desarrollo");

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = Environment.GetEnvironmentVariable("Server");
            builder.InitialCatalog = Environment.GetEnvironmentVariable("Database_B");
            builder.UserID = Environment.GetEnvironmentVariable("UserId");
            builder.Password = Environment.GetEnvironmentVariable("Password");
            builder.ApplicationName = "Billycock";
            if (builder.UserID != "sa")
            {
                builder.MultipleActiveResultSets = true;
                builder.PersistSecurityInfo = false;
                builder.Encrypt = true;
                builder.TrustServerCertificate = false;
            }
            services.AddDbContext<BillycockServiceContext>(options => options.UseSqlServer(builder.ConnectionString,
                options => options.EnableRetryOnFailure()));
            builder.InitialCatalog = Environment.GetEnvironmentVariable("Database_H");
            services.AddDbContext<HilarioServiceContext>(options => options.UseSqlServer(builder.ConnectionString,
                options => options.EnableRetryOnFailure()));
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IBaseDatosConexion, BaseDatosConexion>();
            services.AddScoped<ICuentaRepository, CuentaRepository>();
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
