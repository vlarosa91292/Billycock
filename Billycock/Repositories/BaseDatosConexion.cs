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
            return new BD
            {
                Server = _configuration["Server"],
                Database = Database == "H" ? _configuration["H_Database"]:_configuration["B_Database"],
                UserId = _configuration["UserId"],
                Password = _configuration["Password"],
                Others = _configuration["Others"]
            };
        }
    }
}
