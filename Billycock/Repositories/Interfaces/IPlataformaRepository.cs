using Billycock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Repositories.Interfaces
{
    public interface IPlataformaRepository
    {
        Task<List<Plataforma>> GetPlataformas();
        Task<Plataforma> GetPlataformabyId(int? id);
        Task<Plataforma> GetPlataformabyName(string name);
        //Operaciones Transaccionales
        Task<string> InsertPlataforma(Plataforma usuario);
        Task<string> UpdatePlataforma(Plataforma usuario);
        Task<string> DeletePlataforma(Plataforma usuario);
        Task<bool> PlataformaExists(int id);
        Task<double> GetPricePlataforma(int id);
    }
}
