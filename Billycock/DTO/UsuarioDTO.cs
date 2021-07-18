using Billycock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.DTO
{
    public class UsuarioDTO:Usuario
    {
        public int netflix { get; set; }
        public int amazon { get; set; }
        public int disney { get; set; }
        public int hbo { get; set; }
        public int youtube { get; set; }
        public int spotify { get; set; }
    }
}
