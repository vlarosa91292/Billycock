﻿﻿using Billycock.Data;
using Billycock.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billycock.Repositories.Interfaces;
using Billycock.Utils;

namespace Billycock.Repositories.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BillycockServiceContext _context;
        private readonly ICommonRepository<Usuario> _commonRepository;
        public UsuarioRepository(BillycockServiceContext context, ICommonRepository<Usuario> commonRepository)
        {
            _context = context;
            _commonRepository= commonRepository;
        }
        #region Metodos Principales
        public async Task<string> DeleteUsuario(Usuario usuario, string tipoSalida)
        {
            Usuario user = await GetUsuariobyId(usuario.idUsuario, tipoSalida);
            try
            {
                return await _commonRepository.DeleteLogicoObjeto(new Usuario()
                {
                    idUsuario = user.idUsuario,
                    descripcion = user.descripcion,
                    idEstado = 2,
                    fechaInscripcion = user.fechaInscripcion,
                    facturacion = user.facturacion,
                    pago = user.pago
                },_context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return _commonRepository.ExceptionMessage(usuario, "D");
            }
        }
        public async Task<string> InsertUsuario(Usuario usuario)
        {
            //List<PlataformaCuenta> plataformacuentasTemporal = new List<PlataformaCuenta>();
            //List<PlataformaCuenta> plataformacuentas = new List<PlataformaCuenta>();
            //PlataformaCuenta plataformacuenta = new PlataformaCuenta();
            //PlataformaCuenta plataformacuenta = new PlataformaCuenta();
            //List<string> resultadonulo = new List<string>();
            try
            {
                //foreach (var item in usuario.plataformasxusuario)
                //{
                //    plataformacuentas = new List<PlataformaCuenta>();
                //    plataformacuenta = await _cuentaRepository.GetCuentaDisponible(item.idPlataforma, item.cantidad);
                //    if (plataformacuenta == null)
                //    {
                //        for (int i = 0; i < item.cantidad; i++)
                //        {
                //            plataformacuenta = await _cuentaRepository.GetCuentaDisponible(item.idPlataforma, 1);
                //            if (plataformacuenta != null)
                //            {
                //                plataformacuentas.Add(plataformacuenta);

                //                plataformacuenta = _context.PLATAFORMACUENTA.Find(plataformacuenta.idCuenta, plataformacuenta.idPlataforma);
                //                _context.Entry(plataformacuenta).State = EntityState.Detached;

                //                _context.Entry(new PlataformaCuenta()
                //                {
                //                    idCuenta = plataformacuenta.idCuenta,
                //                    idPlataforma = plataformacuenta.idPlataforma,
                //                    fechaPago = plataformacuenta.fechaPago,
                //                    usuariosdisponibles = plataformacuenta.usuariosdisponibles - 1
                //                }).State = EntityState.Modified;
                //                await Save();
                //            }
                //        }
                //        if (item.cantidad > plataformacuentas.Count)
                //        {
                //            resultadonulo.Add(item.cantidad + "-" + _context.PLATAFORMA.Find(item.idPlataforma).descripcion);

                //            foreach (var pfc in plataformacuentas)
                //            {
                //                plataformacuenta = _context.PLATAFORMACUENTA.Find(pfc.idCuenta, pfc.idPlataforma);

                //                _context.Entry(plataformacuenta).State = EntityState.Detached;

                //                _context.Entry(new PlataformaCuenta()
                //                {
                //                    idCuenta = plataformacuenta.idCuenta,
                //                    idPlataforma = plataformacuenta.idPlataforma,
                //                    fechaPago = plataformacuenta.fechaPago,
                //                    usuariosdisponibles = plataformacuenta.usuariosdisponibles + 1
                //                }).State = EntityState.Modified;
                //                await Save();
                //            }
                //        }
                //    }
                //    else
                //    {
                //        plataformacuentas.Add(plataformacuenta);

                //        plataformacuenta = _context.PLATAFORMACUENTA.Find(plataformacuenta.idCuenta, plataformacuenta.idPlataforma);
                //        _context.Entry(plataformacuenta).State = EntityState.Detached;

                //        _context.Entry(new PlataformaCuenta()
                //        {
                //            idCuenta = plataformacuenta.idCuenta,
                //            idPlataforma = plataformacuenta.idPlataforma,
                //            fechaPago = plataformacuenta.fechaPago,
                //            usuariosdisponibles = plataformacuenta.usuariosdisponibles - item.cantidad
                //        }).State = EntityState.Modified;
                //        await Save();
                //    }
                //}
                //if (resultadonulo.Count != 0)
                //{
                //    string mensaje = "NO HAY SUFICIENTES USUARIOS DISPONIBLES: " + Environment.NewLine;
                //    for (int i = 0; i < resultadonulo.Count; i++)
                //    {
                //        mensaje += resultadonulo[i];
                //        if (i < resultadonulo.Count - 1) mensaje += Environment.NewLine;
                //    }
                //    return mensaje;
                //}
                return await _commonRepository.InsertObjeto(new Usuario()
                {
                    descripcion = usuario.descripcion,
                    fechaInscripcion = DateTime.Now,
                    idEstado = 1,
                    facturacion = ObtenerFechaFacturacion(),
                    //pago = ObtenerMontoPago(usuario.plataformasxusuario)
                    pago = usuario.pago
                },_context);
                //plataformacuentasTemporal = plataformacuentas.GroupBy(x => x.idPlataformaCuenta)
                //                    .Select(group => group.First()).ToList();

                //foreach (var plataformasxusuario in usuario.plataformasxusuario)
                //{
                //    for (int i = 0; i < plataformacuentasTemporal.Count; i++)
                //    {
                //        user = await GetUsuariobyName(usuario.descripcion);
                //        await _context.UsuarioPlataformaCuenta.AddAsync(new UsuarioPlataformaCuenta()
                //        {
                //            idUsuario = user.idUsuario,
                //            idPlataforma = plataformasxusuario.idPlataforma,
                //            cantidad = plataformasxusuario.cantidad,
                //            idCuenta = plataformacuentasTemporal[i].idCuenta
                //        });
                //        await Save();
                //    }
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return _commonRepository.ExceptionMessage(usuario, "C");
            }
        }
        public async Task<string> UpdateUsuario(Usuario usuario, string tipoSalida)
        {
            Usuario user = await GetUsuariobyId(usuario.idUsuario, tipoSalida);
            try
            {
                return await _commonRepository.UpdateObjeto(new Usuario()
                {
                    idUsuario = user.idUsuario,
                    descripcion = usuario.descripcion,
                    idEstado = usuario.idEstado,
                    fechaInscripcion = user.fechaInscripcion,
                    facturacion = usuario.facturacion,
                    pago = usuario.pago
                },_context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return _commonRepository.ExceptionMessage(usuario,"U");
            }
        }
        public async Task<List<Usuario>> GetUsuarios(string tipoSalida)
        {
            return await ObtenerUsuarios(1, "", tipoSalida);
        }
        public async Task<Usuario> GetUsuariobyId(int? id,string tipoSalida)
        {
            return (await ObtenerUsuarios(2, id.ToString(), tipoSalida))[0];
        }
        public async Task<Usuario> GetUsuariobyName(string name, string tipoSalida)
        {
            return (await ObtenerUsuarios(3, name, tipoSalida))[0];
        }
        public async Task<bool> UsuarioExists(int id)
        {
            return await _context.USUARIO.AnyAsync(e => e.idUsuario == id);
        }
        public async Task<List<Usuario>> ObtenerUsuarios(int tipo, string dato,string tipoSalida)
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                if (tipo == 1)
                {
                    if(tipoSalida == "WEB")
                    {
                        usuarios = await (from u in _context.USUARIO
                                          select new Usuario()
                                          {
                                              idUsuario = u.idUsuario,
                                              descripcion = u.descripcion,
                                              fechaInscripcion = u.fechaInscripcion,
                                              idEstado = u.idEstado,
                                              descEstado = (from e in _context.ESTADO where e.idEstado == u.idEstado select e.descripcion).FirstOrDefault(),
                                              facturacion = u.facturacion,
                                              //usuarioPlataformacuentas = (from up in _context.USUARIOPLATAFORMACUENTA
                                              //                            where up.idUsuario == u.idUsuario
                                              //                      orderby up.idUsuario
                                              //                      select new UsuarioPlataformaCuenta()
                                              //                      {
                                              //                          idUsuario = up.idUsuario,
                                              //                          idPlataforma = up.idPlataforma,
                                              //                          descPlataforma = (from p in _context.PLATAFORMA
                                              //                                            where p.idPlataforma == up.idPlataforma
                                              //                                            select p.descripcion).FirstOrDefault(),
                                              //                          cantidad = up.cantidad,
                                              //                          idCuenta = up.idCuenta,
                                              //                          credencial = (from c in _context.CUENTA
                                              //                                        where c.idCuenta == up.idCuenta
                                              //                                        select new UsuarioPlataformaCuenta.Credencial()
                                              //                                        {
                                              //                                            usuario = c.descripcion,
                                              //                                            clave = c.password
                                              //                                        }).FirstOrDefault()
                                              //                      }).ToList(),
                                              pago = u.pago
                                          }).ToListAsync();
                    }
                    else
                    {
                        usuarios = await (from u in _context.USUARIO
                                      where u.idEstado != 2
                                      select new Usuario()
                                      {
                                          idUsuario = u.idUsuario,
                                          descripcion = u.descripcion,
                                          fechaInscripcion = u.fechaInscripcion,
                                          idEstado = u.idEstado,
                                          descEstado = (from e in _context.ESTADO where e.idEstado == u.idEstado select e.descripcion).FirstOrDefault(),
                                          facturacion = u.facturacion,
                                          //usuarioPlataformacuentas = (from up in _context.USUARIOPLATAFORMACUENTA
                                          //                       where up.idUsuario == u.idUsuario
                                          //                       orderby up.idUsuario
                                          //                       select new UsuarioPlataformaCuenta()
                                          //                       {
                                          //                           idUsuario = up.idUsuario,
                                          //                           idPlataforma = up.idPlataforma,
                                          //                           descPlataforma = (from p in _context.PLATAFORMA
                                          //                                             where p.idPlataforma == up.idPlataforma
                                          //                                             select p.descripcion).FirstOrDefault(),
                                          //                           cantidad = up.cantidad,
                                          //                           idCuenta = up.idCuenta,
                                          //                           credencial = (from c in _context.CUENTA
                                          //                                         where c.idCuenta == up.idCuenta
                                          //                                         select new UsuarioPlataformaCuenta.Credencial()
                                          //                                         {
                                          //                                             usuario = c.descripcion,
                                          //                                             clave = c.password
                                          //                                         }).FirstOrDefault()
                                          //                       }).ToList(),
                                          pago = u.pago
                                      }).ToListAsync();
                    }
                }
                else if (tipo == 2)
                {
                    if (tipoSalida == "WEB")
                    {
                        usuarios = await (from u in _context.USUARIO
                                          where u.idUsuario == int.Parse(dato)
                                          select new Usuario()
                                          {
                                              idUsuario = u.idUsuario,
                                              descripcion = u.descripcion,
                                              fechaInscripcion = u.fechaInscripcion,
                                              idEstado = u.idEstado,
                                              descEstado = (from e in _context.ESTADO where e.idEstado == u.idEstado select e.descripcion).FirstOrDefault(),
                                              facturacion = u.facturacion,
                                              //usuarioPlataformacuentas = (from up in _context.USUARIOPLATAFORMACUENTA
                                              //                      where up.idUsuario == u.idUsuario
                                              //                      orderby up.idUsuario
                                              //                      select new UsuarioPlataformaCuenta()
                                              //                      {
                                              //                          idUsuario = up.idUsuario,
                                              //                          idPlataforma = up.idPlataforma,
                                              //                          descPlataforma = (from p in _context.PLATAFORMA
                                              //                                            where p.idPlataforma == up.idPlataforma
                                              //                                            select p.descripcion).FirstOrDefault(),
                                              //                          cantidad = up.cantidad,
                                              //                          idCuenta = up.idCuenta,
                                              //                          credencial = (from c in _context.CUENTA
                                              //                                        where c.idCuenta == up.idCuenta
                                              //                                        select new UsuarioPlataformaCuenta.Credencial()
                                              //                                        {
                                              //                                            usuario = c.descripcion,
                                              //                                            clave = c.password
                                              //                                        }).FirstOrDefault()
                                              //                      }).ToList(),
                                              pago = u.pago
                                          }).ToListAsync();
                    }
                    else
                    {
                        usuarios = await (from u in _context.USUARIO
                                  where u.idEstado != 2 && u.idUsuario == int.Parse(dato)
                                  select new Usuario()
                                  {
                                      idUsuario = u.idUsuario,
                                      descripcion = u.descripcion,
                                      fechaInscripcion = u.fechaInscripcion,
                                      idEstado = u.idEstado,
                                      descEstado = (from e in _context.ESTADO where e.idEstado == u.idEstado select e.descripcion).FirstOrDefault(),
                                      facturacion = u.facturacion,
                                      //usuarioPlataformacuentas = (from up in _context.USUARIOPLATAFORMACUENTA
                                      //                       where up.idUsuario == u.idUsuario
                                      //                       orderby up.idUsuario
                                      //                       select new UsuarioPlataformaCuenta()
                                      //                       {
                                      //                           idUsuario = up.idUsuario,
                                      //                           idPlataforma = up.idPlataforma,
                                      //                           descPlataforma = (from p in _context.PLATAFORMA
                                      //                                             where p.idPlataforma == up.idPlataforma
                                      //                                             select p.descripcion).FirstOrDefault(),
                                      //                           cantidad = up.cantidad,
                                      //                           idCuenta = up.idCuenta,
                                      //                           credencial = (from c in _context.CUENTA
                                      //                                         where c.idCuenta == up.idCuenta
                                      //                                         select new UsuarioPlataformaCuenta.Credencial()
                                      //                                         {
                                      //                                             usuario = c.descripcion,
                                      //                                             clave = c.password
                                      //                                         }).FirstOrDefault()
                                      //                       }).ToList(),
                                      pago = u.pago
                                  }).ToListAsync();
                    }
                }
                else
                {
                    if (tipoSalida == "WEB")
                    {
                        usuarios = await (from u in _context.USUARIO
                                          where u.descripcion == dato
                                          select new Usuario()
                                          {
                                              idUsuario = u.idUsuario,
                                              descripcion = u.descripcion,
                                              fechaInscripcion = u.fechaInscripcion,
                                              idEstado = u.idEstado,
                                              descEstado = (from e in _context.ESTADO where e.idEstado == u.idEstado select e.descripcion).FirstOrDefault(),
                                              facturacion = u.facturacion,
                                              //usuarioPlataformacuentas = (from up in _context.USUARIOPLATAFORMACUENTA
                                              //                      where up.idUsuario == u.idUsuario
                                              //                      orderby up.idUsuario
                                              //                      select new UsuarioPlataformaCuenta()
                                              //                      {
                                              //                          idUsuario = up.idUsuario,
                                              //                          idPlataforma = up.idPlataforma,
                                              //                          descPlataforma = (from p in _context.PLATAFORMA
                                              //                                            where p.idPlataforma == up.idPlataforma
                                              //                                            select p.descripcion).FirstOrDefault(),
                                              //                          cantidad = up.cantidad,
                                              //                          idCuenta = up.idCuenta,
                                              //                          credencial = (from c in _context.CUENTA
                                              //                                        where c.idCuenta == up.idCuenta
                                              //                                        select new UsuarioPlataformaCuenta.Credencial()
                                              //                                        {
                                              //                                            usuario = c.descripcion,
                                              //                                            clave = c.password
                                              //                                        }).FirstOrDefault()
                                              //                      }).ToList(),
                                              pago = u.pago
                                          }).ToListAsync();
                    }
                    else
                    {
                        usuarios = await (from u in _context.USUARIO
                                  where u.idEstado != 2 && u.descripcion == dato
                                  select new Usuario()
                                  {
                                      idUsuario = u.idUsuario,
                                      descripcion = u.descripcion,
                                      fechaInscripcion = u.fechaInscripcion,
                                      idEstado = u.idEstado,
                                      descEstado = (from e in _context.ESTADO where e.idEstado == u.idEstado select e.descripcion).FirstOrDefault(),
                                      facturacion = u.facturacion,
                                      //usuarioPlataformacuentas = (from up in _context.USUARIOPLATAFORMACUENTA
                                      //                       where up.idUsuario == u.idUsuario
                                      //                       orderby up.idUsuario
                                      //                       select new UsuarioPlataformaCuenta()
                                      //                       {
                                      //                           idUsuario = up.idUsuario,
                                      //                           idPlataforma = up.idPlataforma,
                                      //                           descPlataforma = (from p in _context.PLATAFORMA
                                      //                                             where p.idPlataforma == up.idPlataforma
                                      //                                             select p.descripcion).FirstOrDefault(),
                                      //                           cantidad = up.cantidad,
                                      //                           idCuenta = up.idCuenta,
                                      //                           credencial = (from c in _context.CUENTA
                                      //                                         where c.idCuenta == up.idCuenta
                                      //                                         select new UsuarioPlataformaCuenta.Credencial()
                                      //                                         {
                                      //                                             usuario = c.descripcion,
                                      //                                             clave = c.password
                                      //                                         }).FirstOrDefault()
                                      //                       }).ToList(),
                                      pago = u.pago
                                  }).ToListAsync();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return usuarios;
        }
        #endregion
        #region Metodos secundarios
        private string ObtenerFechaFacturacion()
        {
            DateTime fechaHoy = DateTime.Now;
            bool QuincenaMes = fechaHoy.Day <= 15 ? true : false;
            DateTime oPrimerDiaDelMes = new DateTime(fechaHoy.Year, fechaHoy.Month, 1);
            if (fechaHoy.Month < 12)
            {
                if (QuincenaMes)
                {
                    return new DateTime(fechaHoy.Year, fechaHoy.Month, 15).AddMonths(1).ToShortDateString();
                }
                else
                {
                    return oPrimerDiaDelMes.AddMonths(2).AddDays(-1).ToShortDateString();
                }
            }
            else
            {
                if (QuincenaMes)
                {
                    return new DateTime(fechaHoy.Year, fechaHoy.Month, 15).AddMonths(1).ToShortDateString();
                }
                else
                {
                    return oPrimerDiaDelMes.AddMonths(2).AddDays(-1).ToShortDateString();
                }
            }
        }
        private int? ObtenerMontoPago(List<UsuarioPlataformaCuenta> UsuarioPlataformaCuentas)
        {
            int? pago = 0;
            double? acumulado = 0;
            for (int i = 0; i < UsuarioPlataformaCuentas.Count; i++)
            {
                acumulado += ((from p in _context.PLATAFORMA
                               where p.idPlataforma == UsuarioPlataformaCuentas[i].idPlataforma
                               select p.precio).FirstOrDefault()) * UsuarioPlataformaCuentas[i].cantidad;

                if (i == UsuarioPlataformaCuentas.Count - 1)
                {
                    if (UsuarioPlataformaCuentas[i].cantidad == 1 && UsuarioPlataformaCuentas.Count > 1) { pago = reproceso(1, UsuarioPlataformaCuentas.Count, acumulado); }
                    else if (UsuarioPlataformaCuentas[i].cantidad > 1 && UsuarioPlataformaCuentas.Count == 1) { pago = reproceso(2, UsuarioPlataformaCuentas[i].cantidad, acumulado); }
                    else pago = Convert.ToInt16(acumulado);
                }
            }
            return pago;
        }
        private int reproceso(int tipo, int? cuenta, double? monto)
        {
            if (tipo == 1)
            {
                return (int)((monto / cuenta) * (cuenta * 0.9));
            }
            else
            {
                return (int)(monto * 0.85);
            }
        }
        #endregion
    }
}