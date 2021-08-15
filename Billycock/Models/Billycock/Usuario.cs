using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Billycock.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string descripcion { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string fechaInscripcion { get; set; }
        [JsonIgnore]
        public int idEstado { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string facturacion { get; set; }
        public int pago { get; set; }
        [Column(TypeName = "varchar(4)")]
        public string pin { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string contacto { get; set; }
        [JsonIgnore]
        public List<UsuarioPlataformaCuenta> usuarioPlataformaCuentas { get; set; }
    }
}
