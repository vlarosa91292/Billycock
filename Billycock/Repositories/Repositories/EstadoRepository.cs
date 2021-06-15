using Billycock.Data;
using Billycock.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billycock.Repositories.Interfaces;
using Billycock.Utils;

namespace Billycock.Repositories.Repositories
{
    public class EstadoRepository:IEstadoRepository
    {
        private readonly BillycockServiceContext _context;
        private readonly ICommonRepository<Estado> _commonRepository;
        public EstadoRepository(BillycockServiceContext context, ICommonRepository<Estado> commonRepository)
        {
            _context = context;
            _commonRepository = commonRepository;
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

        public async Task<string> DeleteEstado(Estado estado)
        {
            Estado account = await GetEstadobyId(estado.idEstado);
            return await _commonRepository.DeleteObjeto(new Estado()
            {
                idEstado = account.idEstado,
                descripcion = estado.descripcion
            },_context);
        }

        public async Task<Estado> GetEstadobyId(int? id)
        {
            return (await ObtenerEstados(2, id.ToString()))[0];
        }

        public async Task<Estado> GetEstadobyName(string name)
        {
            return (await ObtenerEstados(3, name))[0];
        }

        public async Task<List<Estado>> GetEstados()
        {
            return await ObtenerEstados(1, "");
        }

        public async Task<string> InsertEstado(Estado estado)
        {
            return await _commonRepository.InsertObjeto(new Estado()
            {
                descripcion = estado.descripcion
            },_context);
        }

        public async Task<string> UpdateEstado(Estado estado)
        {
            Estado account = await GetEstadobyId(estado.idEstado);
            return await _commonRepository.UpdateObjeto(new Estado()
            {
                idEstado = account.idEstado,
                descripcion = estado.descripcion
            },_context);
        }

        public async Task<bool> EstadoExists(int id)
        {
            return await _context.ESTADO.AnyAsync(e => e.idEstado == id);
        }

        public async Task<List<Estado>> ObtenerEstados(int tipo, string dato)
        {
            if (tipo == 1)
            {
                return await (from c in _context.ESTADO
                              select new Estado()
                              {
                                  idEstado = c.idEstado,
                                  descripcion = c.descripcion
                              }).ToListAsync();
            }
            else if (tipo == 2)
            {
                return await (from c in _context.ESTADO
                              where c.idEstado == int.Parse(dato)
                              select new Estado()
                              {
                                  idEstado = c.idEstado,
                                  descripcion = c.descripcion
                              }).ToListAsync();
            }
            else
            {
                return await (from c in _context.ESTADO
                              where c.descripcion == dato
                              select new Estado()
                              {
                                  idEstado = c.idEstado,
                                  descripcion = c.descripcion
                              }).ToListAsync();
            }
        }
    }
}
