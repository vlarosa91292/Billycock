using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Models
{
    public class Historia
    {
        [Key]
        public int idHistory {get;set;}
        public string Request { get; set; }
        public string Response { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string fecha { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string integracion { get; set; }
    }
}
