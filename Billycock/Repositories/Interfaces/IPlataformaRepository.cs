using Billycock.DTO;
using Billycock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Repositories.Interfaces
{
    public interface IPlataformaRepository
    {
        #region Create
        Task CreatePlataforma(PlataformaDTO.Create_P usuario);
        #endregion
        #region Read
        Task<List<PlataformaDTO.Read_P>> GetPlataformas(bool complemento);
        Task<PlataformaDTO.Read_P> GetPlataformabyId(int? id, bool complemento);
        Task<PlataformaDTO.Read_P> GetPlataformabyName(string name, bool complemento);
        Task<bool> PlataformaExists(int id);
        #endregion
        #region Update
        Task UpdatePlataforma(PlataformaDTO.Update_P usuario);
        Task DeactivatePlataforma(PlataformaDTO.Update_P usuario);
        #endregion
        #region Delete
        Task DeletePlataforma(int id);
        #endregion
    }
}
