using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Billycock.Models
{
    public class Cuenta
    {
        [Key]
        [JsonIgnore]
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
        [JsonIgnore]
        public int? idEstado { get; set; }
        [NotMapped]
        [JsonIgnore]
        public string descEstado { get; set; }
        [JsonIgnore]
        public List<UsuarioPlataformaCuenta> usuarioPlataformacuentas { get; set; }
        [JsonIgnore]
        public List<PlataformaCuenta> plataformaCuentas { get; set; }
    }
}
