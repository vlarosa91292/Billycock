using Billycock.DTO;
using Billycock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Repositories.Interfaces
{
    public interface IUsuarioPlataformaCuentaRepository
    {
        #region Create
        Task<string> InsertUsuarioPlataformaCuenta(UsuarioPlataformaCuentaDTO.Create_UPC usuarioPlataformaCuenta);
        #endregion
        #region Read
        Task<List<UsuarioPlataformaCuenta>> GetUsuarioPlataformaCuentas();
        Task<UsuarioPlataformaCuenta> GetUsuarioPlataformaCuentabyIds(string id);
        Task<List<UsuarioPlataformaCuenta>> GetUsuarioPlataformaCuentasbyIdUsuario(int id);
        Task<List<UsuarioPlataformaCuenta>> GetUsuarioPlataformaCuentasbyIdPlataforma(int id);
        Task<List<UsuarioPlataformaCuenta>> GetUsuarioPlataformaCuentasbyIdCuenta(int id);
        Task<List<UsuarioPlataformaCuenta>> GetUsuarioPlataformaCuentasbyIdUsuarioIdPlataforma(string id);
        Task<List<UsuarioPlataformaCuenta>> GetUsuarioPlataformaCuentasbyIdUsuarioIdCuenta(string id);
        Task<List<UsuarioPlataformaCuenta>> GetUsuarioPlataformaCuentasbyIdPlataformaIdCuenta(string id);
        Task<bool> UsuarioPlataformaCuentaExists(string idUsuarioPlataformaCuenta);
        #endregion
        #region Update
        Task<string> UpdateUsuarioPlataformaCuenta(UsuarioPlataformaCuentaDTO.Update_UPC usuarioPlataformaCuenta);
        #endregion
        #region Delete
        Task<string> DeleteUsuarioPlataformaCuenta(string id);
        #endregion
    }
}
