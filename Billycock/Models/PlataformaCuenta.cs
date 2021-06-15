using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Models
{
    public class PlataformaCuenta
    {
        [NotMapped]
        public string idPlataformaCuenta { get; set; }
        public int? usuariosdisponibles { get; set; }
        public string fechaPago { get; set; }

        //PLATAFORMA
        public int idPlataforma { get; set; }
        [NotMapped]
        public string descPlataforma { get;set;}

        //CUENTA
        public int idCuenta { get; set; }
        [NotMapped]
        public string descCuenta { get;set;}
    }
}
