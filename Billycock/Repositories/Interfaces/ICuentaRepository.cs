using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billycock.Models;

namespace Billycock.Repositories.Interfaces
{
    public interface ICuentaRepository
    {
        Task<List<Cuenta>> GetCuentas();
        Task<Cuenta> GetCuentabyId(int? id);
        Task<Cuenta> GetCuentabyName(string Name);
        //Task<PlataformaCuenta> GetCuentaDisponible(int idPlataforma,int? cantidad);
        //Operaciones Transaccionales
        Task<string> InsertCuenta(Cuenta cuenta);
        Task<string> UpdateCuenta(Cuenta cuenta);
        Task<string> DeleteCuenta(Cuenta cuenta);
        Task<bool> CuentaExists(int id,string descripcion);
    }
}
