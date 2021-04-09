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

        public async Task<string> DeleteCuenta(Cuenta cuenta)
        {
            CommonRepository<Cuenta> _commonRepository_C = new CommonRepository<Cuenta>();
            CommonRepository<PlataformaCuenta> _commonRepository_PC = new CommonRepository<PlataformaCuenta>();
            string mensaje = string.Empty;
            CuentaDTO account = await GetCuentabyId(cuenta.idCuenta);
            mensaje = await _commonRepository_C.DeleteLogicoObjeto(new Cuenta()
            { 
                idCuenta = account.idCuenta,
                descripcion = account.descripcion,
                diminutivo = account.diminutivo,
                nombre = account.nombre,
                password = account.password,
                netflix = account.netflix,
                amazon = account.amazon,
                disney = account.disney,
                hbo = account.hbo,
                youtube = account.youtube,
                spotify = account.spotify,
                idEstado = 2
            }) + Environment.NewLine;
            foreach (var item in account.plataformaCuentas)
            {
                mensaje += await _commonRepository_PC.UpdateObjeto(new PlataformaCuenta()
                {
                    idPlataforma = item.idPlataforma,
                    idCuenta = item.idCuenta,
                    fechaPago = item.fechaPago,
                    usuariosdisponibles = item.usuariosdisponibles
                });
            }
            return mensaje;
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
            CommonRepository<Cuenta> _commonRepository_C = new CommonRepository<Cuenta>();
            CommonRepository<PlataformaCuenta> _commonRepository_PC = new CommonRepository<PlataformaCuenta>();
            CuentaDTO account;
            List<int> idPlataformas=new List<int>();
            string mensaje=string.Empty;

            mensaje = await _commonRepository_C.InsertObjeto(cuenta) + Environment.NewLine;
            if(mensaje != "0")
            {
                try
                {
                    if (cuenta.netflix == 1) idPlataformas.Add(1);
                    if (cuenta.amazon == 1) idPlataformas.Add(2);
                    if (cuenta.disney == 1) idPlataformas.Add(3);
                    if (cuenta.hbo == 1) idPlataformas.Add(4);
                    if (cuenta.youtube == 1) idPlataformas.Add(5);
                    if (cuenta.spotify == 1) idPlataformas.Add(6);
                    account = await GetCuentabyName(cuenta.descripcion);
                    foreach (var item in idPlataformas)
                    {
                        mensaje += await _commonRepository_PC.InsertObjeto(new PlataformaCuenta()
                        {
                            idCuenta = account.idCuenta,
                            idPlataforma = item,
                            fechaPago = DateTime.Now.ToShortDateString(),
                            usuariosdisponibles = await (from p in _context.PLATAFORMA where p.idPlataforma == item select p.numeroMaximoUsuarios).FirstOrDefaultAsync()
                        });
                    }

                    return mensaje;
                }
                catch 
                {
                    return "ERROR EN LA CREACION DE PLATAFORMAS EN CUENTA-SERVER";
                }
            }
            else
            {
                return "ERROR EN LA CREACION DE CUENTA-SERVER";
            }
        }

        public async Task<string> UpdateCuenta(Cuenta cuenta)
        {
            CommonRepository<Cuenta> _commonRepository_C = new CommonRepository<Cuenta>();
            CommonRepository<PlataformaCuenta> _commonRepository_PC = new CommonRepository<PlataformaCuenta>();
            CuentaDTO account = await GetCuentabyId(cuenta.idCuenta);
            List<int> idPlataformasAgregar = new List<int>();
            List<int> idPlataformasEliminar = new List<int>();
            string mensaje = string.Empty;

            mensaje = await _commonRepository_C.UpdateObjeto(new Cuenta()
            {
                idCuenta = account.idCuenta,
                descripcion = account.descripcion,
                diminutivo = account.diminutivo,
                nombre = account.nombre,
                password = account.password,
                netflix = account.netflix,
                amazon = account.amazon,
                disney = account.disney,
                hbo = account.hbo,
                youtube = account.youtube,
                spotify = account.spotify,
                idEstado = account.idEstado
            }) + Environment.NewLine;
            if(mensaje != "0")
            {
                try
                {
                    if (cuenta.netflix != account.netflix)
                    {
                        if (cuenta.netflix < account.netflix) idPlataformasEliminar.Add(1);
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
                        mensaje += await _commonRepository_PC.InsertObjeto(new PlataformaCuenta()
                        {
                            idPlataforma = item,
                            idCuenta = cuenta.idCuenta,
                            fechaPago = DateTime.Now.ToShortDateString(),
                            usuariosdisponibles = await (from p in _context.PLATAFORMA where p.idPlataforma == item select p.numeroMaximoUsuarios).FirstOrDefaultAsync()
                        });
                    }
                    foreach (var item in idPlataformasEliminar)
                    {
                        mensaje += await _commonRepository_PC.DeleteObjeto(new PlataformaCuenta()
                        {
                            idCuenta = cuenta.idCuenta,
                            idPlataforma = item
                        });
                    }

                    return mensaje;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return "ERROR EN LA ACTUALIZACION DE PLATAFORMAS EN CUENTA-SERVER";
                }
            }
            else
            {
                return "ERROR EN LA ACTUALIZACION DE CUENTA-SERVER";
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
                                                           idPlataformaCuenta = pc.idCuenta + "-" + pc.idPlataforma,
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
                                                           idPlataformaCuenta = pc.idCuenta + "-" + pc.idPlataforma,
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
                                                           idPlataformaCuenta = pc.idCuenta + "-" + pc.idPlataforma,
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
                          join c in _context.CUENTA on pc.idCuenta equals c.idCuenta
                          where pc.idPlataforma == idPlataforma && pc.usuariosdisponibles >= cantidad && c.idEstado != 2
                          select new PlataformaCuentaDTO()
                          {
                              idPlataformaCuenta = pc.idCuenta.ToString() + "-" + pc.idPlataforma.ToString(),
                              idCuenta = pc.idCuenta,
                              idPlataforma = pc.idPlataforma,
                              usuariosdisponibles = pc.usuariosdisponibles,
                              fechaPago = pc.fechaPago
                          }).FirstOrDefaultAsync();
        }
    }
}
