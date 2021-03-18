using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.DTO
{
    public class UsuarioDTO
    {
        public int idUsuario { get; set; }
        public string descripcion { get; set; }
        public DateTime? fechaInscripcion { get; set; }
        public int? idEstado { get; set; }
        public string descEstado { get; set; }
        public string facturacion { get; set; }
        public int? pago { get; set; }
        public List<UsuarioPlataformaDTO> plataformasxusuario { get; set; }
    }
}
