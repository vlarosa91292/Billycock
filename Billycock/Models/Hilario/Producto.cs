using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Models.Hilario
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }
        public int codigoBarra { get; set; }
        public string descripcion { get; set; }
        public int idlinea { get; set; }
        public int idProveedor { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public int loteCaja { get; set; }
        public double precioUnitario { get; set; }
    }
}
