using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Repositories.Interfaces
{
    public interface IBaseDatosConexion
    {
        public string GetConnectionString(string Database);
    }
}
