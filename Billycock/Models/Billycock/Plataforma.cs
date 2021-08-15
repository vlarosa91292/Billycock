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
        public int idPlataforma { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string descripcion { get; set; }
        public int numeroMaximoUsuarios { get; set; }
        public double precio { get; set; }
        [JsonIgnore]
        public int idEstado { get; set; }
        [JsonIgnore]
        public List<UsuarioPlataformaCuenta> usuarioPlataformaCuentas { get; set; }
        [JsonIgnore]
        public List<PlataformaCuenta> plataformaCuentas { get; set; }
    }
}
