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
        public readonly IConfiguration _configuration;
        public BaseDatosConexion(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public BD GetConnectionString(string Database)
        {
            BD bd = new BD()
            {
                Server = _configuration["Server"],
                UserId = _configuration["UserId"],
                Password = _configuration["Password"],
                Others = _configuration["Others"]
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
                bd.Database = _configuration["Database_B"];
            }
            else
            {
                bd.Database = _configuration["Database_H"];
            }
            return bd;
        }
    }
}
