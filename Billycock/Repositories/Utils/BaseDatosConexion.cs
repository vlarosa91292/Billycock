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
        public string GetConnectionString(string Database)
        {
            if(Database == "B") return _configuration.GetSection("BillycockDb").Value;
            else return _configuration.GetSection("HilarioDb").Value;
        }
    }
}
