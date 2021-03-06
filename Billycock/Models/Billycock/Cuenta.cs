using Billycock.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Billycock.Models
{
    public class Cuenta
    {
        [Key]
        public int idCuenta { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string correo { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string diminutivo { get; set; }
        public int idEstado { get; set; }
        public List<UsuarioPlataformaCuenta> usuarioPlataformaCuentas { get; set; }
        public List<PlataformaCuenta> plataformaCuentas { get; set; }
    }
}
