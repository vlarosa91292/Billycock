using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Models
{
    public class Plataforma
    {
        [Key]
        public int idPlataforma { get; set; }
        public string descripcion { get; set; }
        public int? numeroMaximoUsuarios { get; set; }
        public double precio { get; set; }
        public int? idEstado { get; set; }
        [NotMapped]
        public string descEstado { get; set; }

        public List<UsuarioPlataforma> usuarioPlataformas { get; set; }
        public List<PlataformaCuenta> plataformaCuentas { get; set; }
    }
}
