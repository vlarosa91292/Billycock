using Billycock.Data;
using Billycock.Models;
using Billycock.Repositories.Interfaces;
using Billycock.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Repositories.Repositories
{
    public class HistoryRepository<T> : IHistoryRepository<T> where T:class
    {
        private readonly BillycockServiceContext _context;
        public HistoryRepository(BillycockServiceContext context)
        {
            _context = context;
        }
        public async Task Save(BillycockServiceContext _context)
        {
            await _context.SaveChangesAsync();
        }
        public async Task InsertHistory(T t,string response)
        {
            string mensaje = "Creacion XXX de " + t.GetType().Name;
            try
            {
                await _context.AddAsync(new Historia()
                {
                    Request = JsonConvert.SerializeObject(t),
                    Response = response,
                    fecha = DateTime.Now
                });
                await Save(_context);

                mensaje.Replace("XXX", "Correcta").ToUpper();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                mensaje.Replace("XXX", "Incorrecta").ToUpper();
            }
        }
    }
}
