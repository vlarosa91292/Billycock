using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Models.Hilario
{
    public class Proveedor
    {
        public int idProveedor { get; set; }
        public int descripcion { get; set; }
        public List<Producto> productos { get; set; }
    }
}
