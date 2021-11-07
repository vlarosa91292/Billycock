using Billycock.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Repositories.Interfaces
{
    public interface ICuentaRepository
    {
        #region Create
        Task CreateCuenta(CuentaDTO.Create_C cuenta);
        #endregion
        #region Read
        Task<List<CuentaDTO.Read_C>> GetCuentas(bool complemento);
        Task<CuentaDTO.Read_C> GetCuentabyId(int? id, bool complemento);
        Task<CuentaDTO.Read_C> GetCuentabyName(string Name, bool complemento);
        Task<bool> CuentaExists(int id);
        #endregion
        #region Update
        Task UpdateCuenta(CuentaDTO.Update_C cuenta);
        Task DeactivateCuenta(CuentaDTO.Update_C cuenta);
        #endregion
        #region Delete
        Task DeleteCuenta(int id);
        #endregion
    }
}
