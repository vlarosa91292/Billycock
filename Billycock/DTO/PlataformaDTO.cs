using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.DTO
{
    public class PlataformaDTO
    {
        public int idPlataforma { get; set; }
        public string descripcion { get; set; }
        public int? idEstado { get; set; }
        public string descEstado { get; set; }
        public int? numeroMaximoUsuarios { get; set; }
        public double precio { get; set; }
        public List<UsuarioPlataformaDTO> plataformasxusuario { get; set; }
        public List<PlataformaCuentaDTO> plataformaCuentas { get; set; }
    }
}
