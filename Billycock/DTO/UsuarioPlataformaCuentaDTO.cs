using Billycock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.DTO
{
    public class UsuarioPlataformaCuentaDTO
    {
        public class Create_UPC
        {
            public int idUsuario { get; set; }
            public int idPlataforma { get; set; }
            public int idCuenta { get; set; }
            public int cantidad { get; set; }
        }
        public class Update_UPC
        {
            public string idUsuarioPlataformaCuenta { get; set; }
            public int idPlataforma { get; set; }
            public int cantidad { get; set; }
        }
    }
}
