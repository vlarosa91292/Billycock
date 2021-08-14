using Billycock.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Repositories.Utils
{
    public class BaseDatosConexion : IBaseDatosConexion
    {
        public BD GetConnectionString(string Database)
        {
            BD bd = new BD()
            {
                Server = Environment.GetEnvironmentVariable("Server"),
                UserId = Environment.GetEnvironmentVariable("UserId"),
                Password = Environment.GetEnvironmentVariable("Password"),
                Others = Environment.GetEnvironmentVariable("Others")
            };
            if (bd.UserId != "sa")
            {
                bd.MultipleActiveResultSets = true;
                bd.PersistSecurityInfo = false;
                bd.Encrypt = true;
                bd.TrustServerCertificate = false;
            }
            if (Database == "B")
            {
                bd.Database = Environment.GetEnvironmentVariable("Database_B");
            }
            else
            {
                bd.Database = Environment.GetEnvironmentVariable("Database_H");
            }
            return bd;
        }
    }
}
