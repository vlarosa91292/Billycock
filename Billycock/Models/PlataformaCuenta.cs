using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Models
{
    public class PlataformaCuenta
    {
        [Key]
        public int idPlataforma { get; set; }
        public int idCuenta { get; set; }
        public int? usuariosdisponibles { get; set; }
        public string fechaPago { get; set; }
    }
}
