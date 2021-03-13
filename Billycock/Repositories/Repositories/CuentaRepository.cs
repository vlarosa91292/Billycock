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
    public class CuentaRepository:ICuentaRepository
    {
        private readonly BillycockServiceContext _context;
        public CuentaRepository(BillycockServiceContext context)
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

        public async Task<string> DeleteCuenta(Cuenta cuenta)
        {
            CuentaDTO account = await GetCuentabyId(cuenta.idCuenta);
            try
            {
                _context.Update(new Cuenta()
                {
                    idCuenta = account.idCuenta,
                    descripcion = cuenta.descripcion,
                    idEstado = 2,
                    netflix = cuenta.netflix,
                    amazon = cuenta.amazon,
                    disney = cuenta.disney,
                    hbo = cuenta.hbo,
                    youtube = cuenta.youtube,
                    spotify = cuenta.spotify,
                    diminutivo = cuenta.diminutivo,
                    nombre = cuenta.nombre,
                    password = cuenta.password
                });
                await Save();
                return "Eliminacion de Cuenta Correcta";
            }
            catch (Exception ex)
            {
                return "Error en la eliminacion de Cuenta";
            }
        }

        public async Task<CuentaDTO> GetCuentabyId(int? id)
        {
            return (await ObtenerCuentas(2, id.ToString()))[0];
        }

        public async Task<CuentaDTO> GetCuentabyName(string name)
        {
            return (await ObtenerCuentas(3, name))[0];
        }

        public async Task<List<CuentaDTO>> GetCuentas()
        {
            return await ObtenerCuentas(1, "");
        }

        public async Task<string> InsertCuenta(Cuenta cuenta)
        {
            CuentaDTO account;
            List<int> idPlataformas=new List<int>();
            try
            {
                await _context.CUENTA.AddAsync(new Cuenta()
                {
                    descripcion = cuenta.descripcion,
                    netflix = cuenta.netflix,
                    amazon = cuenta.amazon,
                    disney = cuenta.disney,
                    hbo = cuenta.hbo,
                    youtube = cuenta.youtube,
                    spotify = cuenta.spotify,
                    diminutivo = cuenta.diminutivo,
                    idEstado = 1,
                    nombre = cuenta.nombre,
                    password = cuenta.password
                });
                await Save();
                if (cuenta.netflix == 1) idPlataformas.Add(1);
                if (cuenta.amazon == 1) idPlataformas.Add(2);
                if (cuenta.disney == 1) idPlataformas.Add(3);
                if (cuenta.hbo == 1) idPlataformas.Add(4);
                if (cuenta.youtube == 1) idPlataformas.Add(5);
                if (cuenta.spotify == 1) idPlataformas.Add(6);
                account = await GetCuentabyName(cuenta.descripcion);
                foreach (var item in idPlataformas)
                {
                    await _context.PLATAFORMACUENTA.AddAsync(new PlataformaCuenta()
                    {
                        idCuenta = account.idCuenta,
                        idPlataforma = item,
                        fechaPago = DateTime.Now.ToShortDateString(),
                        usuariosdisponibles = await (from p in _context.PLATAFORMA where p.idPlataforma == item select p.numeroMaximoUsuarios).FirstOrDefaultAsync()
                    });
                    await Save();
                }

                return "CREACION DE CUENTA EXITOSA";
            }
            catch 
            {
                return "ERROR EN LA CREACION DE CUENTA-SERVER";
            }
        }

        public async Task<string> UpdateCuenta(Cuenta cuenta)
        {
            CuentaDTO account = await GetCuentabyId(cuenta.idCuenta);
            List<int> idPlataformasAgregar = new List<int>();
            List<int> idPlataformasEliminar = new List<int>();
            try
            {
                _context.Update(new Cuenta()
                {
                    idCuenta = cuenta.idCuenta,
                    descripcion = cuenta.descripcion,
                    netflix = cuenta.netflix,
                    amazon = cuenta.amazon,
                    disney = cuenta.disney,
                    hbo = cuenta.hbo,
                    youtube = cuenta.youtube,
                    spotify = cuenta.spotify,
                    diminutivo = cuenta.diminutivo,
                    idEstado = cuenta.idEstado,
                    nombre = cuenta.nombre,
                    password = cuenta.password
                });
                await Save();
                if (cuenta.netflix != account.netflix)
                {
                    if(cuenta.netflix < account.netflix) idPlataformasEliminar.Add(1);
                    else idPlataformasAgregar.Add(1);
                }
                if (cuenta.amazon != account.amazon)
                {
                    if (cuenta.amazon < account.amazon) idPlataformasEliminar.Add(2);
                    else idPlataformasAgregar.Add(2);
                }
                if (cuenta.disney != account.disney)
                {
                    if (cuenta.disney < account.disney) idPlataformasEliminar.Add(3);
                    else idPlataformasAgregar.Add(3);
                }
                if (cuenta.hbo != account.hbo)
                {
                    if (cuenta.hbo < account.hbo) idPlataformasEliminar.Add(4);
                    else idPlataformasAgregar.Add(4);
                }
                if (cuenta.youtube != account.youtube)
                {
                    if (cuenta.youtube < account.youtube) idPlataformasEliminar.Add(5);
                    else idPlataformasAgregar.Add(5);
                }
                if (cuenta.spotify != account.spotify)
                {
                    if (cuenta.spotify < account.spotify) idPlataformasEliminar.Add(6);
                    else idPlataformasAgregar.Add(6);
                }
                foreach (var item in idPlataformasAgregar)
                {
                    await _context.PLATAFORMACUENTA.AddAsync(new PlataformaCuenta()
                    {
                        idPlataforma = item,
                        idCuenta = cuenta.idCuenta,
                        fechaPago = DateTime.Now.ToShortDateString(),
                        usuariosdisponibles = await (from p in _context.PLATAFORMA where p.idPlataforma == item select p.numeroMaximoUsuarios).FirstOrDefaultAsync()
                    });
                    await Save();
                }
                foreach (var item in idPlataformasEliminar)
                {
                     _context.PLATAFORMACUENTA.Remove(new PlataformaCuenta()
                    {
                        idCuenta = cuenta.idCuenta,
                        idPlataforma = item
                     });
                    await Save();
                }

                return "ACTUALIZACION DE CUENTA EXITOSA";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "ERROR EN LA CREACION DE ACTUALIZACION-SERVER";
            }
        }

        public async Task<bool> CuentaExists(int id)
        {
            return await _context.CUENTA.AnyAsync(e => e.idCuenta == id);
        }

        public async Task<List<CuentaDTO>> ObtenerCuentas(int tipo, string dato)
        {
            if (tipo == 1)
            {
                return await (from c in _context.CUENTA
                              where c.idEstado != 2
                              select new CuentaDTO()
                              {
                                  idCuenta = c.idCuenta,
                                  descripcion = c.descripcion,
                                  idEstado = c.idEstado,
                                  descEstado = (from e in _context.ESTADO where e.idEstado == c.idEstado select e.descripcion).FirstOrDefault(),
                                  netflix = c.netflix,
                                  amazon = c.amazon,
                                  disney = c.disney,
                                  hbo = c.hbo,
                                  youtube = c.youtube,
                                  spotify = c.spotify,
                                  nombre = c.nombre,
                                  diminutivo = c.diminutivo,
                                  password = c.password,
                                  plataformaCuentas = (from pc in _context.PLATAFORMACUENTA
                                                       where pc.idCuenta == c.idCuenta
                                                       select new PlataformaCuentaDTO()
                                                       {
                                                           idCuenta = pc.idCuenta,
                                                           descCuenta = c.descripcion,
                                                           idPlataforma = pc.idPlataforma,
                                                           descPlataforma = (from p in _context.PLATAFORMA where p.idPlataforma == pc.idPlataforma select p.descripcion).FirstOrDefault(),
                                                           fechaPago = pc.fechaPago,
                                                           usuariosdisponibles = pc.usuariosdisponibles
                                                       }).ToList()
                              }).ToListAsync();
            }
            else if (tipo == 2)
            {
                return await (from c in _context.CUENTA
                              where c.idEstado != 2 && c.idEstado == int.Parse(dato)
                              select new CuentaDTO()
                              {
                                  idCuenta = c.idCuenta,
                                  descripcion = c.descripcion,
                                  idEstado = c.idEstado,
                                  descEstado = (from e in _context.ESTADO where e.idEstado == c.idEstado select e.descripcion).FirstOrDefault(),
                                  netflix = c.netflix,
                                  amazon = c.amazon,
                                  disney = c.disney,
                                  hbo = c.hbo,
                                  youtube = c.youtube,
                                  spotify = c.spotify,
                                  nombre = c.nombre,
                                  diminutivo = c.diminutivo,
                                  password = c.password,
                                  plataformaCuentas = (from pc in _context.PLATAFORMACUENTA
                                                       where pc.idCuenta == c.idCuenta
                                                       select new PlataformaCuentaDTO()
                                                       {
                                                           idCuenta = pc.idCuenta,
                                                           descCuenta = c.descripcion,
                                                           idPlataforma = pc.idPlataforma,
                                                           descPlataforma = (from p in _context.PLATAFORMA where p.idPlataforma == pc.idPlataforma select p.descripcion).FirstOrDefault(),
                                                           fechaPago = pc.fechaPago,
                                                           usuariosdisponibles = pc.usuariosdisponibles
                                                       }).ToList()
                              }).ToListAsync();
            }
            else
            {
                return await (from c in _context.CUENTA
                              where c.idEstado != 2 && c.descripcion == dato
                              select new CuentaDTO()
                              {
                                  idCuenta = c.idCuenta,
                                  descripcion = c.descripcion,
                                  idEstado = c.idEstado,
                                  descEstado = (from e in _context.ESTADO where e.idEstado == c.idEstado select e.descripcion).FirstOrDefault(),
                                  netflix = c.netflix,
                                  amazon = c.amazon,
                                  disney = c.disney,
                                  hbo = c.hbo,
                                  youtube = c.youtube,
                                  spotify = c.spotify,
                                  nombre = c.nombre,
                                  diminutivo = c.diminutivo,
                                  password = c.password,
                                  plataformaCuentas = (from pc in _context.PLATAFORMACUENTA
                                                       where pc.idCuenta == c.idCuenta
                                                       select new PlataformaCuentaDTO()
                                                       {
                                                           idCuenta = pc.idCuenta,
                                                           descCuenta = c.descripcion,
                                                           idPlataforma = pc.idPlataforma,
                                                           descPlataforma = (from p in _context.PLATAFORMA where p.idPlataforma == pc.idPlataforma select p.descripcion).FirstOrDefault(),
                                                           fechaPago = pc.fechaPago,
                                                           usuariosdisponibles = pc.usuariosdisponibles
                                                       }).ToList()
                              }).ToListAsync();
            }
        }

        public async Task<PlataformaCuentaDTO> GetCuentaDisponible(int idPlataforma, int? cantidad)
        {
            return await (from pc in _context.PLATAFORMACUENTA
                          where pc.idPlataforma == idPlataforma && pc.usuariosdisponibles >= cantidad
                          select new PlataformaCuentaDTO()
                          {
                              idCuenta = pc.idCuenta,
                              usuariosdisponibles = pc.usuariosdisponibles
                          }).FirstOrDefaultAsync();
        }
    }
}
