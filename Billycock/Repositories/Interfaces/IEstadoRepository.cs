using Billycock.DTO;
using Billycock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Repositories.Interfaces
{
    public interface IEstadoRepository
    {
        Task<List<EstadoDTO>> GetEstados();
        Task<EstadoDTO> GetEstadobyId(int? id);
        Task<EstadoDTO> GetEstadobyName(string Name);
        //Operaciones Transaccionales
        Task<string> InsertEstado(EstadoDTO estado);
        Task<string> UpdateEstado(EstadoDTO estado);
        Task<string> DeleteEstado(EstadoDTO estado);
        Task<bool> EstadoExists(int id);
        Task Save();
    }
}
