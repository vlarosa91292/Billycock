using Billycock.Data;
using Billycock.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Repositories.Repositories
{
    public class CommonRepository<T>
    {
        private readonly BillycockServiceContext _context;
        public CommonRepository(BillycockServiceContext context)
        {
            _context = context;
        }

        public CommonRepository()
        {
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<string> DeleteLogicoObjeto(T t)
        {
            try
            {
                _context.Update(t);
                await Save();
                return "Eliminacion Correcta";
            }
            catch
            {
                return "0";
            }
        }
        public async Task<string> DeleteObjeto(T t)
        {
            try
            {
                _context.Remove(t);
                await Save();
                return "Eliminacion Correcta";
            }
            catch
            {
                return "0";
            }
        }
        public async Task<string> InsertObjeto(T t)
        {
            try
            {
                await _context.AddAsync(t);
                await Save();

                return "CREACION EXITOSA";
            }
            catch
            {
                return "0";
            }
        }
        public async Task<string> UpdateObjeto(T t)
        {
            try
            {
                _context.Update(t);
                await Save();

                return "ACTUALIZACION EXITOSA";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "0";
            }
        }
    }
}
