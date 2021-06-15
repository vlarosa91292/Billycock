using Billycock.Data;
using Billycock.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billycock.Repositories.Repositories
{
    public class CommonRepository<T> : ICommonRepository<T> where T : class
    {
        public CommonRepository()
        {
        }
        public async Task Save(BillycockServiceContext _context)
        {
            await _context.SaveChangesAsync();
        }
        public async Task<string> DeleteLogicoObjeto(T t, BillycockServiceContext _context)
        {
            try
            {
                _context.Update(t);
                await Save(_context);
                return "Eliminacion Correcta de " + t.GetType().Name.ToUpper();
            }
            catch
            {
                return "0";
            }
        }
        public async Task<string> DeleteObjeto(T t, BillycockServiceContext _context)
        {
            try
            {
                _context.Remove(t);
                await Save(_context);
                return "Eliminacion Correcta de " + t.GetType().Name.ToUpper();
            }
            catch
            {
                return "0";
            }
        }
        public async Task<string> InsertObjeto(T t, BillycockServiceContext _context)
        {
            try
            {
                await _context.AddAsync(t);
                await Save(_context);

                return "Creacion Correcta de " + t.GetType().Name.ToUpper();
            }
            catch
            {
                return "0";
            }
        }
        public async Task<string> UpdateObjeto(T t, BillycockServiceContext _context)
        {
            try
            {
                _context.Update(t);
                await Save(_context);

                return "Actualizacion correcta de " + t.GetType().Name.ToUpper();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "0";
            }
        }
    }
}