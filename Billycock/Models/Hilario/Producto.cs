using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Models.Hilario
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string codigoBarra { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string descripcion { get; set; }
        public int idlinea { get; set; }
        [NotMapped]
        public string descLinea { get; set; }
        public int idProveedor { get; set; }
        [NotMapped]
        public string descProveedor { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public int loteCaja { get; set; }
        public double precioUnitario { get; set; }
        public List<Oferta> ofertas { get; set; }
    }
}
