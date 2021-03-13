using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Models
{
    public class Plataforma
    {
        [Key]
        public int idPlataforma { get; set; }
        public string descripcion { get; set; }
        public int? idEstado { get; set; }
        public int? numeroMaximoUsuarios { get; set; }
        public double precio { get; set; }
    }
}
