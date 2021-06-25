using Billycock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Repositories.Interfaces
{
    public interface IPlataformaCuentaRepository
    {
        Task<List<PlataformaCuenta>> GetPlataformaCuentas();
        Task<PlataformaCuenta> GetPlataformaCuentabyId(int? id);
        Task<PlataformaCuenta> GetPlataformaCuentabyName(string Name);
        //Operaciones Transaccionales
        Task<string> InsertPlataformaCuenta(PlataformaCuenta plataformaCuenta);
        Task<string> UpdatePlataformaCuenta(PlataformaCuenta plataformaCuenta);
        Task<string> DeletePlataformaCuenta(PlataformaCuenta plataformaCuenta);
        Task<bool> PlataformaCuentaExists(string idPlataformaCuenta);
    }
}
