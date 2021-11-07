using Billycock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.DTO
{
    public class CuentaDTO
    {
        public class Create_C
        {
            public string correo { get; set; }
            public string diminutivo { get; set; }
            public int idEstado = 1;
            public List<PlataformaCuenta> plataformaCuentas { get; set; }
        }
        public class Read_C:Cuenta
        {
            public string descEstado { get; set; }
        }
        public class Update_C
        {
            public int idCuenta { get; set; }
            public string correo { get; set; }
            public string diminutivo { get; set; }
            public int idEstado {get;set;}
            public List<PlataformaCuenta> plataformaCuentas { get; set; }
        }
    }
}
