using Billycock.DTO;
using Billycock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Repositories.Interfaces
{
    public interface IPlataformaCuentaRepository
    {
        #region Create
        Task<string> CreatePlataformaCuenta(PlataformaCuentaDTO.Create_PC plataformaCuenta);
        #endregion
        #region Read
        Task<List<PlataformaCuenta>> GetPlataformaCuentas();
        Task<PlataformaCuenta> GetPlataformaCuentabyIds(string id);
        Task<List<PlataformaCuenta>> GetPlataformaCuentasbyIdPlataforma(int id);
        Task<List<PlataformaCuenta>> GetPlataformaCuentasbyIdCuenta(int id);
        Task<bool> PlataformaCuentaExists(string idPlataformaCuenta);
        #endregion
        #region Update
        Task<string> UpdatePlataformaCuenta(PlataformaCuentaDTO.Update_PC plataformaCuenta);
        #endregion
        #region Delete
        Task<string> DeletePlataformaCuenta(string id);
        #endregion
        #region Extras
        Task<PlataformaCuenta> GetPlataformaCuentaDisponible(int idPlataforma, int cantidad);
        #endregion
    }
}
