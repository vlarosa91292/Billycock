using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Billycock.Models
{
    public class Plataforma
    {
        [Key]
        [JsonIgnore]
        public int idPlataforma { get; set; }
        public string descripcion { get; set; }
        public int? numeroMaximoUsuarios { get; set; }
        public double precio { get; set; }
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
