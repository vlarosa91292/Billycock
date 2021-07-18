﻿using System;
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
        public string correo { get; set; }
        public string diminutivo { get; set; }
        public bool netflix { get; set; }
        public bool amazon { get; set; }
        public bool disney { get; set; }
        public bool hbo { get; set; }
        public bool youtube { get; set; }
        public bool spotify { get; set; }

        [JsonIgnore]
        public int? idEstado { get; set; }
        [NotMapped]
        [JsonIgnore]
        public string descEstado { get; set; }
        [JsonIgnore]
        public List<UsuarioPlataformaCuenta> usuarioPlataformaCuentas { get; set; }
        [JsonIgnore]
        public List<PlataformaCuenta> plataformaCuentas { get; set; }
    }
}
