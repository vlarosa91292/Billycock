using Billycock.Data;
using Billycock.DTO;
using Billycock.Models;
using Billycock.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Repositories.Repositories
{
    public class EstadoRepository:IEstadoRepository
    {
        private readonly BillycockServiceContext _context;
        public EstadoRepository(BillycockServiceContext context)
        {
            _context = context;
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

        public async Task<string> DeleteEstado(EstadoDTO estado)
        {
            EstadoDTO account = await GetEstadobyId(estado.idEstado);
            try
            {
                _context.Update(new Estado()
                {
                    idEstado = account.idEstado,
                    descripcion = estado.descripcion
                });
                await Save();
                return "Eliminacion de Estado Correcta";
            }
            catch (Exception ex)
            {
                return "Error en la eliminacion de Estado";
            }
        }

        public async Task<EstadoDTO> GetEstadobyId(int? id)
        {
            return (await ObtenerEstados(2, id.ToString()))[0];
        }

        public async Task<EstadoDTO> GetEstadobyName(string name)
        {
            return (await ObtenerEstados(3, name))[0];
        }

        public async Task<List<EstadoDTO>> GetEstados()
        {
            return await ObtenerEstados(1, "");
        }

        public async Task<string> InsertEstado(EstadoDTO estado)
        {
            try
            {
                await _context.ESTADO.AddAsync(new Estado()
                {
                    descripcion = estado.descripcion
                });
                await Save();

                return "CREACION DE PLATAFORMA EXITOSA";
            }
            catch
            {
                return "ERROR EN LA CREACION DE PLATAFORMA-SERVER";
            }
        }

        public async Task<string> UpdateEstado(EstadoDTO estado)
        {
            EstadoDTO account = await GetEstadobyId(estado.idEstado);
            try
            {
                _context.Update(new Estado()
                {
                    idEstado = estado.idEstado,
                    descripcion = account.descripcion
                });
                await Save();

                return "ACTUALIZACION DE PLATAFORMA EXITOSA";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "ERROR EN LA CREACION DE PLATAFORMA-SERVER";
            }
        }

        public async Task<bool> EstadoExists(int id)
        {
            return await _context.ESTADO.AnyAsync(e => e.idEstado == id);
        }

        public async Task<List<EstadoDTO>> ObtenerEstados(int tipo, string dato)
        {
            if (tipo == 1)
            {
                return await (from c in _context.ESTADO
                              select new EstadoDTO()
                              {
                                  idEstado = c.idEstado,
                                  descripcion = c.descripcion
                              }).ToListAsync();
            }
            else if (tipo == 2)
            {
                return await (from c in _context.ESTADO
                              where c.idEstado == int.Parse(dato)
                              select new EstadoDTO()
                              {
                                  idEstado = c.idEstado,
                                  descripcion = c.descripcion
                              }).ToListAsync();
            }
            else
            {
                return await (from c in _context.ESTADO
                              where c.descripcion == dato
                              select new EstadoDTO()
                              {
                                  idEstado = c.idEstado,
                                  descripcion = c.descripcion
                              }).ToListAsync();
            }
        }
    }
}
