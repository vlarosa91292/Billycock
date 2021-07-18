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
        Task<List<Usuario>> GetUsuarios(string tipoSalida);
        Task<Usuario> GetUsuariobyId(int? id, string tipoSalida);
        Task<Usuario> GetUsuariobyName(string name, string tipoSalida);
        //Operaciones Transaccionales
        Task<string> InsertUsuario(UsuarioDTO usuario);    
        Task<string> UpdateUsuario(Usuario usuario, string tipoSalida);
        Task<string> DeleteUsuario(Usuario usuario, string tipoSalida);
        Task<bool> UsuarioExists(int id);
    }
}
