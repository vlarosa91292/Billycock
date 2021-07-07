using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Models
{
    public class UsuarioPlataformaCuenta
    {
        public int? cantidad { get; set; }
        [NotMapped]
        public Credencial credencial { get; set; }

        //Usuario
        public int idUsuario { get; set; }
        [NotMapped]
        public string descUsuario { get; set; }

        //PLATAFORMA
        public int idPlataforma { get; set; }
        [NotMapped]
        public string descPlataforma { get; set; }

        //CUENTA
        public int idCuenta { get; set; }
        [NotMapped]
        public string descCuenta { get; set; }

        public class Credencial
        {
            public string usuario { get; set; }
            public string clave { get; set; }
        }
    }
}
