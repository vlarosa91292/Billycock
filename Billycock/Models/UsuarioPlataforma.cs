using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Models
{
    public class UsuarioPlataforma
    {
        public int idUsuario { get; set; }
        public int idPlataforma { get; set; }
        public int idCuenta { get; set; }
        public int? cantidad { get; set; }
    }
}
