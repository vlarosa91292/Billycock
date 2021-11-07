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
        #region Create
        Task<string> CreateEstado(EstadoDTO.Create_E estado);
        #endregion
        #region Read
        Task<List<Estado>> GetEstados();
        Task<Estado> GetEstadobyId(int? id);
        Task<Estado> GetEstadobyName(string Name);
        Task<bool> EstadoExists(int id);
        #endregion
        #region Update
        Task<string> UpdateEstado(Estado estado);
        #endregion
        #region Delete
        Task<string> DeleteEstado(int id);
        #endregion
    }
}
