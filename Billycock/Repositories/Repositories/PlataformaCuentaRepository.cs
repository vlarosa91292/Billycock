using Billycock.Models;
using Billycock.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Repositories.Repositories
{
    public class PlataformaCuentaRepository : IPlataformaCuentaRepository
    {
        public Task<string> DeletePlataformaCuenta(PlataformaCuenta plataformaCuenta)
        {
            throw new NotImplementedException();
        }

        public Task<PlataformaCuenta> GetPlataformaCuentabyId(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<PlataformaCuenta> GetPlataformaCuentabyName(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlataformaCuenta>> GetPlataformaCuentas()
        {
            throw new NotImplementedException();
        }

        public Task<string> InsertPlataformaCuenta(PlataformaCuenta plataformaCuenta)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PlataformaCuentaExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdatePlataformaCuenta(PlataformaCuenta plataformaCuenta)
        {
            throw new NotImplementedException();
        }
    }
}
