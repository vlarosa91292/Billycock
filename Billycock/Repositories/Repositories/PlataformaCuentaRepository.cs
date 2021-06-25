using Billycock.Data;
using Billycock.Models;
using Billycock.Repositories.Interfaces;
using Billycock.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Repositories.Repositories
{
    public class PlataformaCuentaRepository : IPlataformaCuentaRepository
    {
        private readonly BillycockServiceContext _context;
        private readonly ICommonRepository<PlataformaCuenta> _commonRepository;
        public PlataformaCuentaRepository(BillycockServiceContext context, ICommonRepository<PlataformaCuenta> commonRepository)
        {
            _context = context;
            _commonRepository = commonRepository;
        }
        public async Task<string> DeletePlataformaCuenta(PlataformaCuenta plataformaCuenta)
        {
            return await _commonRepository.DeleteObjeto(plataformaCuenta, _context);
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

        public async Task<string> InsertPlataformaCuenta(PlataformaCuenta plataformaCuenta)
        {
            return await _commonRepository.InsertObjeto(plataformaCuenta, _context);
        }

        public async Task<bool> PlataformaCuentaExists(string idPlataformaCuenta)
        {
            int idPlataforma = int.Parse(idPlataformaCuenta.Split("-")[0]);
            int idCuenta = int.Parse(idPlataformaCuenta.Split("-")[1]);
            return await _context.PLATAFORMACUENTA.AnyAsync(e => e.idPlataforma == idPlataforma 
                                                                && e.idCuenta == idCuenta);
        }

        public async Task<string> UpdatePlataformaCuenta(PlataformaCuenta plataformaCuenta)
        {
            return await _commonRepository.UpdateObjeto(plataformaCuenta, _context);
        }
    }
}
