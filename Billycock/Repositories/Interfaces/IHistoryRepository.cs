using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billycock.Models;

namespace Billycock.Repositories.Interfaces
{
    public interface IHistoryRepository<T>
    {
        Task<string> InsertHistory(T model);
    }
}
