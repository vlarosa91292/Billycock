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
        Task<List<UsuarioDTO>> GetUsuarios();
        Task<UsuarioDTO> GetUsuariobyId(int? id);
        Task<UsuarioDTO> GetUsuariobyName(string name);
        //Operaciones Transaccionales
        Task<string> InsertUsuario(UsuarioDTO usuario);    
        Task<string> UpdateUsuario(UsuarioDTO usuario);
        Task<string> DeleteUsuario(Usuario usuario);
        Task<bool> UsuarioExists(int id);
        Task Save();
    }
}
