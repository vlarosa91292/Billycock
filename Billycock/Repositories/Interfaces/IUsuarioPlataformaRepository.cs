using Billycock.DTO;
using Billycock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Repositories.Interfaces
{
    public interface IUsuarioPlataformaRepository
    {
        Task<List<UsuarioPlataformaDTO>> GetUsuarioPlataformas();
        Task<UsuarioPlataformaDTO> GetUsuarioPlataformabyId(int? id);
        Task<UsuarioPlataformaDTO> GetUsuarioPlataformabyName(string Name);
        //Operaciones Transaccionales
        Task<string> InsertUsuarioPlataforma(UsuarioPlataformaDTO usuarioPlataforma);
        Task<string> UpdateUsuarioPlataforma(UsuarioPlataformaDTO UsuarioPlataforma);
        Task<string> DeleteUsuarioPlataforma(UsuarioPlataformaDTO usuarioPlataforma);
        Task<bool> UsuarioPlataformaExists(int id);
        Task Save();
    }
}
