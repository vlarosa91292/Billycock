using Billycock.DTO;
using Billycock.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Repositories.Repositories
{
    public class PlataformaCuentaRepository : IPlataformaCuentaRepository
    {
        public Task<string> DeletePlataformaCuenta(PlataformaCuentaDTO plataformaCuenta)
        {
            throw new NotImplementedException();
        }

        public Task<PlataformaCuentaDTO> GetPlataformaCuentabyId(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<PlataformaCuentaDTO> GetPlataformaCuentabyName(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlataformaCuentaDTO>> GetPlataformaCuentas()
        {
            throw new NotImplementedException();
        }

        public Task<string> InsertPlataformaCuenta(PlataformaCuentaDTO plataformaCuenta)
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

        public Task<string> UpdatePlataformaCuenta(PlataformaCuentaDTO plataformaCuenta)
        {
            throw new NotImplementedException();
        }
    }
}
