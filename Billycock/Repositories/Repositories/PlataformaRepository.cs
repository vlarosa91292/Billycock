using Billycock.Data;
using Billycock.Models;
using Billycock.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Repositories.Repositories
{
    public class PlataformaRepository : IPlataformaRepository
    {
        private readonly BillycockServiceContext _context;
        public PlataformaRepository(BillycockServiceContext context)
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

        public async Task<string> DeletePlataforma(Plataforma plataforma)
        {
            Plataforma account = await GetPlataformabyId(plataforma.idPlataforma);
            try
            {
                _context.Update(new Plataforma()
                {
                    idPlataforma = account.idPlataforma,
                    descripcion = plataforma.descripcion,
                    idEstado = 2,
                    numeroMaximoUsuarios = account.numeroMaximoUsuarios,
                    precio = account.precio
                });
                await Save();
                return "Eliminacion de Plataforma Correcta";
            }
            catch (Exception ex)
            {
                return "Error en la eliminacion de Plataforma";
            }
        }

        public async Task<Plataforma> GetPlataformabyId(int? id)
        {
            return (await ObtenerPlataformas(2, id.ToString()))[0];
        }

        public async Task<Plataforma> GetPlataformabyName(string name)
        {
            return (await ObtenerPlataformas(3, name))[0];
        }

        public async Task<List<Plataforma>> GetPlataformas()
        {
            return await ObtenerPlataformas(1, "");
        }

        public async Task<string> InsertPlataforma(Plataforma plataforma)
        {
            try
            {
                await _context.PLATAFORMA.AddAsync(new Plataforma()
                {
                    descripcion = plataforma.descripcion,
                    idEstado = 1,
                    numeroMaximoUsuarios = plataforma.numeroMaximoUsuarios,
                    precio = plataforma.precio
                });
                await Save();

                return "CREACION DE PLATAFORMA EXITOSA";
            }
            catch
            {
                return "ERROR EN LA CREACION DE PLATAFORMA-SERVER";
            }
        }

        public async Task<string> UpdatePlataforma(Plataforma plataforma)
        {
            Plataforma account = await GetPlataformabyId(plataforma.idPlataforma);
            List<int> idPlataformasAgregar = new List<int>();
            List<int> idPlataformasEliminar = new List<int>();
            try
            {
                _context.Update(new Plataforma()
                {
                    idPlataforma = plataforma.idPlataforma,
                    descripcion = account.descripcion,
                    idEstado = plataforma.idEstado,
                    numeroMaximoUsuarios = plataforma.numeroMaximoUsuarios,
                    precio = account.precio
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

        public async Task<bool> PlataformaExists(int id)
        {
            return await _context.PLATAFORMA.AnyAsync(e => e.idPlataforma == id);
        }

        public async Task<List<Plataforma>> ObtenerPlataformas(int tipo, string dato)
        {
            if (tipo == 1)
            {
                return await (from c in _context.PLATAFORMA
                              where c.idEstado != 2
                              select new Plataforma()
                              {
                                  idPlataforma = c.idPlataforma,
                                  descripcion = c.descripcion,
                                  idEstado = c.idEstado,
                                  descEstado = (from e in _context.ESTADO where e.idEstado == c.idEstado select e.descripcion).FirstOrDefault(),
                                  precio = c.precio,  
                                  //plataformaCuentas = (from pc in _context.PLATAFORMACUENTA
                                  //                     where pc.idPlataforma == c.idPlataforma
                                  //                     select new PlataformaCuenta()
                                  //                     {
                                  //                         idCuenta = pc.idPlataforma,
                                  //                         descCuenta = c.descripcion,
                                  //                         idPlataforma = pc.idPlataforma,
                                  //                         descPlataforma = (from p in _context.PLATAFORMA where p.idPlataforma == pc.idPlataforma select p.descripcion).FirstOrDefault(),
                                  //                         fechaPago = pc.fechaPago,
                                  //                         usuariosdisponibles = pc.usuariosdisponibles
                                  //                     }).ToList()
                              }).ToListAsync();
            }
            else if (tipo == 2)
            {
                return await (from c in _context.PLATAFORMA
                              where c.idEstado != 2 && c.idEstado == int.Parse(dato)
                              select new Plataforma()
                              {
                                  idPlataforma = c.idPlataforma,
                                  descripcion = c.descripcion,
                                  idEstado = c.idEstado,
                                  descEstado = (from e in _context.ESTADO where e.idEstado == c.idEstado select e.descripcion).FirstOrDefault(),
                                  precio = c.precio,
                                  //plataformaCuentas = (from pc in _context.PLATAFORMACUENTA
                                  //                     where pc.idPlataforma == c.idPlataforma
                                  //                     select new PlataformaCuenta()
                                  //                     {
                                  //                         idCuenta = pc.idPlataforma,
                                  //                         descCuenta = c.descripcion,
                                  //                         idPlataforma = pc.idPlataforma,
                                  //                         descPlataforma = (from p in _context.PLATAFORMA where p.idPlataforma == pc.idPlataforma select p.descripcion).FirstOrDefault(),
                                  //                         fechaPago = pc.fechaPago,
                                  //                         usuariosdisponibles = pc.usuariosdisponibles
                                  //                     }).ToList()
                              }).ToListAsync();
            }
            else
            {
                return await (from c in _context.PLATAFORMA
                              where c.idEstado != 2 && c.descripcion == dato
                              select new Plataforma()
                              {
                                  idPlataforma = c.idPlataforma,
                                  descripcion = c.descripcion,
                                  idEstado = c.idEstado,
                                  descEstado = (from e in _context.ESTADO where e.idEstado == c.idEstado select e.descripcion).FirstOrDefault(),
                                  precio = c.precio,
                                  //plataformaCuentas = (from pc in _context.PLATAFORMACUENTA
                                  //                     where pc.idPlataforma == c.idPlataforma
                                  //                     select new PlataformaCuenta()
                                  //                     {
                                  //                         idCuenta = pc.idPlataforma,
                                  //                         descCuenta = c.descripcion,
                                  //                         idPlataforma = pc.idPlataforma,
                                  //                         descPlataforma = (from p in _context.PLATAFORMA where p.idPlataforma == pc.idPlataforma select p.descripcion).FirstOrDefault(),
                                  //                         fechaPago = pc.fechaPago,
                                  //                         usuariosdisponibles = pc.usuariosdisponibles
                                  //                     }).ToList()
                              }).ToListAsync();
            }
        }
    }
}
