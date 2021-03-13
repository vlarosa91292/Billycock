using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.DTO
{
    public class UsuarioPlataformaDTO
    {
        public int idUsuario { get; set; }
        public int idPlataforma { get; set; }
        public string descPlataforma { get; set; }
        public int idCuenta { get; set; }
        public Credencial credencial { get; set; }
        public int? cantidad { get; set; }

        public class Credencial
        {
            public string usuario { get; set; }
            public string clave { get; set; }
        }
    }
}
