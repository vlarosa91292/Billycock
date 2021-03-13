using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billycock.DTO;
using Billycock.Models;

namespace Billycock.Repositories.Interfaces
{
    public interface ICuentaRepository
    {
        Task<CuentaDTO> GetCuentabyId(int? id);
        Task<CuentaDTO> GetCuentabyName(string Name);
        Task<PlataformaCuentaDTO> GetCuentaDisponible(int idPlataforma,int? cantidad);
        //Operaciones Transaccionales
        Task<string> InsertCuenta(Cuenta cuenta);
        Task<string> UpdateCuenta(Cuenta Cuenta);
        Task<string> DeleteCuenta(Cuenta cuenta);
        Task<bool> CuentaExists(int id);
        Task<List<CuentaDTO>> GetCuentas();
        Task Save();
    }
}
