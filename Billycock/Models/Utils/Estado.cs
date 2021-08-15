using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Models
{
    public class Estado
    {
        [Key]
        public int idEstado { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string descripcion { get; set; }
    }
}
