using Billycock.DTO;
using Billycock.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Repositories.Repositories
{
    public class UsuarioPlataformaRepository : IUsuarioPlataformaRepository
    {
        public Task<string> DeleteUsuarioPlataforma(UsuarioPlataformaDTO usuarioPlataforma)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioPlataformaDTO> GetUsuarioPlataformabyId(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioPlataformaDTO> GetUsuarioPlataformabyName(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<List<UsuarioPlataformaDTO>> GetUsuarioPlataformas()
        {
            throw new NotImplementedException();
        }

        public Task<string> InsertUsuarioPlataforma(UsuarioPlataformaDTO usuarioPlataforma)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateUsuarioPlataforma(UsuarioPlataformaDTO UsuarioPlataforma)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UsuarioPlataformaExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
