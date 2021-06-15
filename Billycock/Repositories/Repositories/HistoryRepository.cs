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
        private readonly ICommonRepository<BillycockHistory> _commonRepository;
        public HistoryRepository(BillycockServiceContext context, ICommonRepository<BillycockHistory> commonRepository)
        {
            _context = context;
            _commonRepository = commonRepository;
        }
        public async Task<string> InsertHistory(T model)
        {
            string mensaje = string.Empty;

            mensaje = await _commonRepository.InsertObjeto(new BillycockHistory()
            {
                Request = JsonConvert.SerializeObject(model),
                Response = "CREACION DE "+ model.GetType().Name.ToUpper()+" EXITOSA",
                fecha = DateTime.Now
            }, _context);
            return mensaje;
        }
    }
}
