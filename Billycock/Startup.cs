using Billycock.Data;
using Billycock.Repositories.Interfaces;
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
using Billycock.Utils;
using Billycock.Repositories.Repositories;

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

            SqlConnectionStringBuilder builder_B = new SqlConnectionStringBuilder();
            SqlConnectionStringBuilder builder_H = new SqlConnectionStringBuilder();
            if (Environment.GetEnvironmentVariable("Server") == "SERVER" || Environment.GetEnvironmentVariable("Server") == null)
            {
                //PRODUCCION
                /*Environment.SetEnvironmentVariable("Server", "tcp:billycock-server.database.windows.net,1433");
                Environment.SetEnvironmentVariable("UserId", "vlarosa");
                Environment.SetEnvironmentVariable("Password", "Nayjuw+29");
                Environment.SetEnvironmentVariable("Database_B", "Billycock_Produccion");
                Environment.SetEnvironmentVariable("Database_H", "Hilario_Produccion");*/

                //DESARROLLO
                //Environment.SetEnvironmentVariable("Server", "."); 
                Environment.SetEnvironmentVariable("Server", ".");
                Environment.SetEnvironmentVariable("UserId", "sa");
                Environment.SetEnvironmentVariable("Password", "Nayjuw+29");
                Environment.SetEnvironmentVariable("Database_B", "Billycock_Desarrollo");
                Environment.SetEnvironmentVariable("Database_H", "Hilario_Desarrollo");
            }
            builder_B = new SqlConnectionStringBuilder()
            {
                DataSource = Environment.GetEnvironmentVariable("Server"),
                InitialCatalog = Environment.GetEnvironmentVariable("Database_B"),
                UserID = Environment.GetEnvironmentVariable("UserId"),
                Password = Environment.GetEnvironmentVariable("Password"),
                ApplicationName = "Billycock"
            };
            builder_H = new SqlConnectionStringBuilder()
            {
                DataSource = Environment.GetEnvironmentVariable("Server"),
                InitialCatalog = Environment.GetEnvironmentVariable("Database_H"),
                UserID = Environment.GetEnvironmentVariable("UserId"),
                Password = Environment.GetEnvironmentVariable("Password"),
                ApplicationName = "Billycock"
            };
            if(builder_B.DataSource == "Server" && builder_B.DataSource == "Server")
            {
                builder_B.MultipleActiveResultSets = true;
                builder_B.PersistSecurityInfo = false;

                builder_H.MultipleActiveResultSets = true;
                builder_H.PersistSecurityInfo = false;
            }
            if (builder_B.UserID != "sa" && builder_H.UserID != "sa")
            {
                builder_B.MultipleActiveResultSets = true;
                builder_B.PersistSecurityInfo = false;
                builder_B.Encrypt = true;
                builder_B.TrustServerCertificate = false;

                builder_H.MultipleActiveResultSets = true;
                builder_H.PersistSecurityInfo = false;
                builder_H.Encrypt = true;
                builder_H.TrustServerCertificate = false;
            }

            services.AddDbContext<BillycockServiceContext>(options => options.UseSqlServer(builder_B.ConnectionString,
                options => options.EnableRetryOnFailure()));
            services.AddDbContext<HilarioServiceContext>(options => options.UseSqlServer(builder_H.ConnectionString,
                options => options.EnableRetryOnFailure()));

            services.AddScoped<ICuentaRepository, CuentaRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IPlataformaCuentaRepository, PlataformaCuentaRepository>();
            services.AddScoped<IPlataformaRepository, PlataformaRepository>();
            services.AddScoped<IUsuarioPlataformaCuentaRepository, UsuarioPlataformaCuentaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped(typeof(ICommonRepository<>), typeof(CommonRepository<>));

            services.AddCors(options => options.AddPolicy("AllowWebApp",
                            builder => builder
                            .AllowAnyMethod()
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .SetPreflightMaxAge(TimeSpan.FromSeconds(2520))));

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

            app.UseCors("AllowWebApp");

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
