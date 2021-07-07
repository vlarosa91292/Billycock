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
            string mensaje = "Eliminacion XXX de " + t.GetType().Name.ToUpper();
            try
            {
                _context.Update(t);
                await Save(_context);
                return mensaje.Replace("XXX","Correcta");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return mensaje.Replace("XXX", "Incorrecta");
            }
        }
        public async Task<string> DeleteObjeto(T t, BillycockServiceContext _context)
        {
            string mensaje = "Eliminacion XXX de " + t.GetType().Name.ToUpper();
            try
            {
                _context.Remove(t);
                await Save(_context);
                return mensaje.Replace("XXX", "Correcta");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return mensaje.Replace("XXX", "Incorrecta");
            }
        }
        public async Task<string> InsertObjeto(T t, BillycockServiceContext _context)
        {
            string mensaje = "Creacion XXX de " + t.GetType().Name.ToUpper();
            try
            {
                await _context.AddAsync(t);
                await Save(_context);

                return mensaje.Replace("XXX", "Correcta");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return mensaje.Replace("XXX", "Incorrecta");
            }
        }
        public async Task<string> UpdateObjeto(T t, BillycockServiceContext _context)
        {
            string mensaje = "Actualizacion XXX de " + t.GetType().Name.ToUpper();
            try
            {
                _context.Update(t);
                await Save(_context);

                return mensaje.Replace("XXX", "Correcta");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return mensaje.Replace("XXX", "Incorrecta");
            }
        }
    }
}