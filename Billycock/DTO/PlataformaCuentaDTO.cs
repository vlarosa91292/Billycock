using Billycock.Models;
using System.Text.Json.Serialization;

namespace Billycock.DTO
{
    public class PlataformaCuentaDTO
    {
        public class Create_PC
        {
            public int idPlataforma { get; set; }
            public int idCuenta { get; set; }
            public int usuariosdisponibles { get; set; }
        }
        public class Update_PC
        {
            public string idPlataformaCuenta { get; set; }
            public string fechaPago           {get;set;}
            public int usuariosdisponibles {get;set;}
            public string clave               {get;set;}
        }
    }
}
