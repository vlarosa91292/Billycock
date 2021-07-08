using Billycock.Data;
using Billycock.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billycock.Repositories.Interfaces;
using Billycock.Repositories.Repositories;
using Billycock.Utils;

namespace Billycock.Repositories.Repositories
{
    public class CuentaRepository:ICuentaRepository
    {
        private readonly BillycockServiceContext _context;
        private readonly ICommonRepository<Cuenta> _commonRepository;
        private readonly IPlataformaCuentaRepository _plataformaCuentaRepository;
        public CuentaRepository(BillycockServiceContext context, ICommonRepository<Cuenta> commonRepository, IPlataformaCuentaRepository plataformaCuentaRepository)
        {
            _context = context;
            _commonRepository = commonRepository;
            _plataformaCuentaRepository = plataformaCuentaRepository;
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

        public async Task<string> DeleteCuenta(int idCuenta)
        {
            string mensaje;
            if (await CuentaExists(idCuenta,null))
            {
                Cuenta account = await GetCuentabyId(idCuenta);
                mensaje = await _commonRepository.DeleteLogicoObjeto(new Cuenta()
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
                },_context);
                if(mensaje.Contains("Correcta"))
                {
                    try
                    {
                        //foreach (var item in account.plataformaCuentas)
                        //{
                        //    mensaje += Environment.NewLine;
                        //    mensaje += await _plataformaCuentaRepository.DeletePlataformaCuenta(new PlataformaCuenta()
                        //    {
                        //        idPlataforma = item.idPlataforma,
                        //        idCuenta = item.idCuenta,
                        //        fechaPago = item.fechaPago,
                        //        usuariosdisponibles = item.usuariosdisponibles
                        //    });
                        //}
                    }
                    catch
                    {
                        mensaje += "Error en la eliminacion de plataformas en Cuenta-Server";
                    }
                }
            }
            else mensaje = "No se encontro cuenta con ese id";
            return mensaje;
        }
        public async Task<Cuenta> GetCuentabyId(int? id)
        {
            if (await CuentaExists((int)id, null)) return (await ObtenerCuentas(2, id.ToString()))[0];
            else return null;
        }
        public async Task<Cuenta> GetCuentabyName(string name)
        {
            if (await CuentaExists(0, name)) return (await ObtenerCuentas(3, name))[0];
            else return null;
        }
        public async Task<List<Cuenta>> GetCuentas()
        {
            return await ObtenerCuentas(1, "");
        }
        public async Task<string> InsertCuenta(Cuenta cuenta)
        {
            Cuenta account;
            List<int> idPlataformas=new List<int>();
            string mensaje=string.Empty;
            int contador = 0;

            mensaje = await _commonRepository.InsertObjeto(new Cuenta()
            {
                descripcion = cuenta.descripcion,
                diminutivo = cuenta.diminutivo,
                nombre = cuenta.nombre,
                password = cuenta.password,
                netflix = cuenta.netflix,
                amazon = cuenta.amazon,
                disney = cuenta.disney,
                hbo = cuenta.hbo,
                youtube = cuenta.youtube,
                spotify = cuenta.spotify,
                idEstado = 1
            },_context);
            if (mensaje.Contains("Correcta"))
            {
                mensaje += Environment.NewLine;
                try
                {
                    if (cuenta.netflix == 1) idPlataformas.Add(1);
                    if (cuenta.amazon == 1) idPlataformas.Add(2);
                    if (cuenta.disney == 1) idPlataformas.Add(3);
                    if (cuenta.hbo == 1) idPlataformas.Add(4);
                    if (cuenta.youtube == 1) idPlataformas.Add(5);
                    if (cuenta.spotify == 1) idPlataformas.Add(6);
                    account = await GetCuentabyName(cuenta.nombre);
                    foreach (var item in idPlataformas)
                    {
                        if(contador>=1)mensaje += Environment.NewLine;
                        mensaje += await _plataformaCuentaRepository.InsertPlataformaCuenta(new PlataformaCuenta()
                        {
                            idCuenta = account.idCuenta,
                            idPlataforma = item,
                            fechaPago = DateTime.Now.ToShortDateString(),
                            usuariosdisponibles = await (from p in _context.PLATAFORMA where p.idPlataforma == item select p.numeroMaximoUsuarios).FirstOrDefaultAsync()
                        });
                        contador++;
                    }
                }
                catch 
                {
                    mensaje += "Error en la creacion de plataformas en cuenta-Server";
                }
            }
            return mensaje;
        }
        public async Task<string> UpdateCuenta(Cuenta cuenta)
        {
            Cuenta account = await GetCuentabyId(cuenta.idCuenta);
            List<int> idPlataformasAgregar = new List<int>();
            List<int> idPlataformasEliminar = new List<int>();
            string mensaje = string.Empty;

            mensaje = await _commonRepository.UpdateObjeto(new Cuenta()
            {
                idCuenta = cuenta.idCuenta == 0?account.idCuenta:cuenta.idCuenta,
                descripcion = cuenta.descripcion==""?account.descripcion:cuenta.descripcion,
                diminutivo = cuenta.diminutivo==""?account.diminutivo:cuenta.diminutivo,
                nombre = cuenta.nombre==""?account.nombre:cuenta.nombre,
                password = cuenta.password==""?account.password:cuenta.password,
                netflix = cuenta.netflix==account.netflix?account.netflix:cuenta.netflix,
                amazon = cuenta.amazon==account.amazon?account.amazon:cuenta.amazon,
                disney = cuenta.disney==account.disney?account.disney:cuenta.disney,
                hbo = cuenta.hbo==account.hbo?account.hbo:cuenta.hbo,
                youtube = cuenta.youtube==account.youtube?account.youtube:cuenta.youtube,
                spotify = cuenta.spotify==account.spotify?account.spotify:cuenta.spotify,
                idEstado = cuenta.idEstado==account.idEstado?account.idEstado:cuenta.idEstado
            },_context);
            if (mensaje.Contains("Correcta"))
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
                        mensaje += Environment.NewLine;
                        mensaje += await _plataformaCuentaRepository.InsertPlataformaCuenta(new PlataformaCuenta()
                        {
                            idPlataforma = item,
                            idCuenta = cuenta.idCuenta,
                            fechaPago = DateTime.Now.ToShortDateString(),
                            usuariosdisponibles = await (from p in _context.PLATAFORMA where p.idPlataforma == item select p.numeroMaximoUsuarios).FirstOrDefaultAsync()
                        });
                    }
                    foreach (var item in idPlataformasEliminar)
                    {
                        mensaje += Environment.NewLine;
                        mensaje += await _plataformaCuentaRepository.DeletePlataformaCuenta(new PlataformaCuenta()
                        {
                            idCuenta = cuenta.idCuenta,
                            idPlataforma = item
                        });
                    }
                }
                catch
                {
                    mensaje += "ERROR EN LA ACTUALIZACION DE PLATAFORMAS EN CUENTA-SERVER";
                }
            }
            return mensaje;
        }
        public async Task<bool> CuentaExists(int id,string nombre)
        {
            if(nombre == null) return await _context.CUENTA.AnyAsync(e => e.idCuenta == id && e.idEstado == 1);
            else return await _context.CUENTA.AnyAsync(e => e.nombre == nombre && e.idEstado == 1);
        }
        public async Task<List<Cuenta>> ObtenerCuentas(int tipo, string dato)
        {
            List<Cuenta> cuentas;
            if (tipo == 1)
            {
                cuentas = await (from c in _context.CUENTA
                              where c.idEstado != 2
                              select new Cuenta()
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
                                  //plataformaCuentas = (from pc in _context.PLATAFORMACUENTA
                                  //                     where pc.idCuenta == c.idCuenta
                                  //                     select new PlataformaCuenta()
                                  //                     {
                                  //                         idPlataformaCuenta = pc.idCuenta + "-" + pc.idPlataforma,
                                  //                         idCuenta = pc.idCuenta,
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
                cuentas = await (from c in _context.CUENTA
                              where c.idEstado != 2 && c.idCuenta == int.Parse(dato)
                              select new Cuenta()
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
                                  //plataformaCuentas = (from pc in _context.PLATAFORMACUENTA
                                  //                     where pc.idCuenta == c.idCuenta
                                  //                     select new PlataformaCuenta()
                                  //                     {
                                  //                         idPlataformaCuenta = pc.idCuenta + "-" + pc.idPlataforma,
                                  //                         idCuenta = pc.idCuenta,
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
                cuentas = await (from c in _context.CUENTA
                              where c.idEstado != 2 && c.nombre == dato
                              select new Cuenta()
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
                                  //plataformaCuentas = (from pc in _context.PLATAFORMACUENTA
                                  //                     where pc.idCuenta == c.idCuenta
                                  //                     select new PlataformaCuenta()
                                  //                     {
                                  //                         idPlataformaCuenta = pc.idCuenta + "-" + pc.idPlataforma,
                                  //                         idCuenta = pc.idCuenta,
                                  //                         descCuenta = c.descripcion,
                                  //                         idPlataforma = pc.idPlataforma,
                                  //                         descPlataforma = (from p in _context.PLATAFORMA where p.idPlataforma == pc.idPlataforma select p.descripcion).FirstOrDefault(),
                                  //                         fechaPago = pc.fechaPago,
                                  //                         usuariosdisponibles = pc.usuariosdisponibles
                                  //                     }).ToList()
                              }).ToListAsync();
            }
            return cuentas;
        }
        public async Task<PlataformaCuenta> GetCuentaDisponible(int idPlataforma, int? cantidad)
        {
            return await (from pc in _context.PLATAFORMACUENTA
                          join c in _context.CUENTA on pc.idCuenta equals c.idCuenta
                          where pc.idPlataforma == idPlataforma && pc.usuariosdisponibles >= cantidad && c.idEstado != 2
                          select new PlataformaCuenta()
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
