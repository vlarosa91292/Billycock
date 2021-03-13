using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Billycock.Models
{
    public class Cuenta
    {
        [Key]
        public int idCuenta { get; set; }
        public string nombre { get; set; }
        public string diminutivo { get; set; }
        public int netflix { get; set; }
        public int amazon { get; set; }
        public int disney { get; set; }
        public int hbo { get; set; }
        public int youtube { get; set; }
        public int spotify { get; set; }
        public string descripcion { get; set; }
        public string password { get; set; }
        public int? idEstado { get; set; }
    }
}
