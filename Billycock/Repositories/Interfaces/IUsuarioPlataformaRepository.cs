using Billycock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Repositories.Interfaces
{
    public interface IUsuarioPlataformaRepository
    {
        Task<List<UsuarioPlataforma>> GetUsuarioPlataformas();
        Task<UsuarioPlataforma> GetUsuarioPlataformabyId(int? id);
        Task<UsuarioPlataforma> GetUsuarioPlataformabyName(string Name);
        //Operaciones Transaccionales
        Task<string> InsertUsuarioPlataforma(UsuarioPlataforma usuarioPlataforma);
        Task<string> UpdateUsuarioPlataforma(UsuarioPlataforma UsuarioPlataforma);
        Task<string> DeleteUsuarioPlataforma(UsuarioPlataforma usuarioPlataforma);
        Task<bool> UsuarioPlataformaExists(int id);
        Task Save();
    }
}
