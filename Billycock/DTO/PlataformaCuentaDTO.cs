using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.DTO
{
    public class PlataformaCuentaDTO
    {
        public string idPlataformaCuenta { get; set; }
        public int idPlataforma { get; set; }
        public string descPlataforma { get; set; }
        public int idCuenta { get; set; }
        public string descCuenta { get; set; }
        public int? usuariosdisponibles { get; set; }
        public string fechaPago { get; set; }
    }
}
