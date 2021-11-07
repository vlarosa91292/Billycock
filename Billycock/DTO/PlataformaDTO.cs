using Billycock.Models;
using System.Text.Json.Serialization;

namespace Billycock.DTO
{
    public class PlataformaDTO
    {
        public class Create_P
        {
            public string descripcion { get; set; }
            public int idEstado = 1;
            public int numeroMaximoUsuarios { get; set; }
            public int precio { get; set; }
            public int costo { get; set; }
        }
        public class Read_P:Plataforma
        {
            public string descEstado { get; set; }
        }
        public class Update_P
        {
            public int idPlataforma { get; set; }
            public string descripcion { get; set; }
            public int numeroMaximoUsuarios { get; set; }
            public int precio { get; set; }
            public int costo { get; set; }
            public int idEstado { get; set; }
        }
    }
}
