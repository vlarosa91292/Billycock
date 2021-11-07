using Billycock.DTO;
using Billycock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        #region Create
        Task CreateUsuario(UsuarioDTO.Create_U usuario);
        #endregion
        #region Read
        Task<List<UsuarioDTO.Read_U>> GetUsuarios(bool complemento);
        Task<UsuarioDTO.Read_U> GetUsuariobyId(int? id, bool complemento);
        Task<UsuarioDTO.Read_U> GetUsuariobyName(string name, bool complemento);
        Task<bool> UsuarioExists(int id);
        #endregion
        #region Update
        Task UpdateUsuario(UsuarioDTO.Update_U usuario);
        Task DeactivateUsuario(Usuario usuario);
        #endregion
        #region Delete
        Task DeleteUsuario(Usuario usuario);
        #endregion
    }
}
