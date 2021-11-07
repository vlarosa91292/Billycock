using Billycock.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Billycock.DTO
{
    public class UsuarioDTO
    {
        public class Create_U
        {
            public string descripcion { get; set; }
            public int idEstado = 1;
            public string pin { get; set; }
            public string contacto { get; set; }
            public List<UsuarioPlataformaCuenta> usuarioPlataformaCuentas { get; set; }
        }
        public class Read_U : Usuario
        {
            public string descEstado { get; set; }
        }
        public class Update_U
        {
            public int idUsuario { get; set; }
            public string descripcion { get; set; }
            public int idEstado { get; set; }
            public string pin { get; set; }
            public string contacto { get; set; }
            public List<UsuarioPlataformaCuenta> usuarioPlataformaCuentas { get; set; }
        }
    }
}
