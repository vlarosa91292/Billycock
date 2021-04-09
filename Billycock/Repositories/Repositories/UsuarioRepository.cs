using Billycock.Data;
using Billycock.DTO;
using Billycock.Models;
using Billycock.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Repositories.Repositories
{
    public class UsuarioRepository:IUsuarioRepository
    {
        private readonly BillycockServiceContext _context;
        private readonly ICuentaRepository _cuentaRepository;
        public UsuarioRepository(BillycockServiceContext context, ICuentaRepository cuentaRepository)
        {
            _context = context;
            _cuentaRepository = cuentaRepository;
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

        public async Task<string> DeleteUsuario(Usuario usuario)
        {
            UsuarioDTO user = await GetUsuariobyId(usuario.idUsuario);
            try
            {
                _context.Entry(user).State = EntityState.Detached;
                _context.Entry(new Usuario()
                {
                    idUsuario = user.idUsuario,
                    descripcion = user.descripcion,
                    idEstado = 2,
                    fechaInscripcion = user.fechaInscripcion,
                    facturacion = user.facturacion,
                    pago = user.pago
                }).State = EntityState.Modified;
                await Save();
                return "Eliminacion de Usuario Correcta";
            }
            catch
            {
                return "Error en la eliminacion de Usuario";
            }
        }

        public async Task<UsuarioDTO> GetUsuariobyId(int? id)
        {
            return (await ObtenerUsuarios(2,id.ToString()))[0]; 
        }

        public async Task<UsuarioDTO> GetUsuariobyName(string name)
        {
            return (await ObtenerUsuarios(3, name))[0];
        }

        public async Task<List<UsuarioDTO>> GetUsuarios()
        {
            return await ObtenerUsuarios(1,"");
        }

        public async Task<string> InsertUsuario(UsuarioDTO usuario)
        {
            UsuarioDTO user = new UsuarioDTO();
            List<PlataformaCuentaDTO> plataformacuentasTemporal = new List<PlataformaCuentaDTO>();
            List<PlataformaCuentaDTO> plataformacuentas = new List<PlataformaCuentaDTO>();
            PlataformaCuentaDTO plataformacuentaDTO = new PlataformaCuentaDTO();
            PlataformaCuenta plataformacuenta = new PlataformaCuenta();
            List<string> resultadonulo = new List<string>();
            try
            {
                foreach (var item in usuario.plataformasxusuario)
                {
                    plataformacuentas = new List<PlataformaCuentaDTO>();
                    plataformacuentaDTO = await _cuentaRepository.GetCuentaDisponible(item.idPlataforma, item.cantidad);
                    if (plataformacuentaDTO == null)
                    {
                        for (int i = 0; i < item.cantidad; i++)
                        {
                            plataformacuentaDTO = await _cuentaRepository.GetCuentaDisponible(item.idPlataforma, 1);
                            if (plataformacuentaDTO != null)
                            {
                                plataformacuentas.Add(plataformacuentaDTO);

                                plataformacuenta = _context.PLATAFORMACUENTA.Find(plataformacuentaDTO.idCuenta, plataformacuentaDTO.idPlataforma);
                                _context.Entry(plataformacuenta).State = EntityState.Detached;

                                _context.Entry(new PlataformaCuenta() 
                                { 
                                    idCuenta= plataformacuenta.idCuenta,
                                    idPlataforma = plataformacuenta.idPlataforma,
                                    fechaPago = plataformacuenta.fechaPago,
                                    usuariosdisponibles = plataformacuenta.usuariosdisponibles - 1
                                }).State = EntityState.Modified;
                                await Save();
                            }
                        }
                        if (item.cantidad > plataformacuentas.Count)
                        {
                            resultadonulo.Add(item.cantidad + "-" + _context.PLATAFORMA.Find(item.idPlataforma).descripcion);

                            foreach (var pfc in plataformacuentas)
                            {
                                plataformacuenta = _context.PLATAFORMACUENTA.Find(pfc.idCuenta,pfc.idPlataforma);

                                _context.Entry(plataformacuenta).State = EntityState.Detached;

                                _context.Entry(new PlataformaCuenta()
                                {
                                    idCuenta = plataformacuenta.idCuenta,
                                    idPlataforma = plataformacuenta.idPlataforma,
                                    fechaPago = plataformacuenta.fechaPago,
                                    usuariosdisponibles = plataformacuenta.usuariosdisponibles + 1
                                }).State = EntityState.Modified;
                                await Save();
                            }
                        }
                    }
                    else
                    {
                        plataformacuentas.Add(plataformacuentaDTO);

                        plataformacuenta = _context.PLATAFORMACUENTA.Find(plataformacuentaDTO.idCuenta, plataformacuentaDTO.idPlataforma);
                        _context.Entry(plataformacuenta).State = EntityState.Detached;

                        _context.Entry(new PlataformaCuenta()
                        {
                            idCuenta = plataformacuenta.idCuenta,
                            idPlataforma = plataformacuenta.idPlataforma,
                            fechaPago = plataformacuenta.fechaPago,
                            usuariosdisponibles = plataformacuenta.usuariosdisponibles - item.cantidad
                        }).State = EntityState.Modified;
                        await Save();
                    }
                }
                if (resultadonulo.Count != 0)
                {
                    string mensaje = "NO HAY SUFICIENTES USUARIOS DISPONIBLES: " + Environment.NewLine;
                    for (int i = 0; i < resultadonulo.Count; i++)
                    {
                        mensaje += resultadonulo[i];
                        if (i < resultadonulo.Count - 1) mensaje += Environment.NewLine;
                    }
                    return mensaje;
                }
                await _context.USUARIO.AddAsync(new Usuario()
                {
                    descripcion = usuario.descripcion,
                    fechaInscripcion = DateTime.Now,
                    idEstado = 1,
                    facturacion = ObtenerFechaFacturacion(),
                    pago = ObtenerMontoPago(usuario.plataformasxusuario)
                });
                await Save();
                plataformacuentasTemporal = plataformacuentas.GroupBy(x => x.idPlataformaCuenta)
                                    .Select(group => group.First()).ToList();

                foreach (var plataformasxusuario in usuario.plataformasxusuario)
                {
                    for (int i= 0;i< plataformacuentasTemporal.Count;i++)
                    {
                        user = await GetUsuariobyName(usuario.descripcion);
                        await _context.USUARIOPLATAFORMA.AddAsync(new UsuarioPlataforma()
                        {
                            idUsuario = user.idUsuario,
                            idPlataforma = plataformasxusuario.idPlataforma,
                            cantidad = plataformasxusuario.cantidad,
                            idCuenta = plataformacuentasTemporal[i].idCuenta
                        });
                        await Save();
                    }
                }
                _context.HISTORY.Add(new BillycockHistory() 
                {
                    Request = JsonConvert.SerializeObject(usuario),
                    Response = "CREACION DE USUARIO EXITOSA",
                    fecha = DateTime.Now
                });
                await Save();
                return "CREACION DE USUARIO EXITOSA";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                _context.HISTORY.Add(new BillycockHistory()
                {
                    Request = JsonConvert.SerializeObject(usuario),
                    Response = ex.Message,
                    fecha = DateTime.Now
                });
                await Save();
                return "ERROR EN LA CREACION DE USUARIO-SERVER";
            }
        }

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

        private int? ObtenerMontoPago(List<UsuarioPlataformaDTO> usuarioPlataforma)
        {
            int? pago = 0;
            double? acumulado=0;
            for (int i = 0; i < usuarioPlataforma.Count; i++)
            {
                acumulado += ((from p in _context.PLATAFORMA
                            where p.idPlataforma == usuarioPlataforma[i].idPlataforma
                            select p.precio).FirstOrDefault()) * usuarioPlataforma[i].cantidad;
                
                if(i == usuarioPlataforma.Count-1)
                {
                    if (usuarioPlataforma[i].cantidad == 1 && usuarioPlataforma.Count > 1) { pago = reproceso(1, usuarioPlataforma.Count, acumulado); }
                    else if (usuarioPlataforma[i].cantidad > 1 && usuarioPlataforma.Count == 1) { pago = reproceso(2, usuarioPlataforma[i].cantidad, acumulado); }
                    else pago = Convert.ToInt16(acumulado);
                }
            }
            return pago;
        }

        private int reproceso(int tipo, int? cuenta,double? monto)
        {
            if(tipo == 1)
            {
                return (int)((monto / cuenta) * (cuenta * 0.9)); 
            }
            else
            {
                return (int)(monto * 0.85);
            }
        }

        public async Task<string> UpdateUsuario(UsuarioDTO usuario)
        {
            UsuarioDTO user = await GetUsuariobyId(usuario.idUsuario);
            try
            {
                _context.Update(new Usuario()
                {
                    idUsuario = usuario.idUsuario,
                    descripcion = usuario.descripcion,
                    idEstado = user.idEstado,
                    fechaInscripcion = user.fechaInscripcion,
                    facturacion = user.facturacion,
                    pago = user.pago
                });
                await Save();
                return "Actualizacion de Usuario Correcta";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Error en la actualizacion de Usuario";
            }
        }

        public async Task<bool> UsuarioExists(int id)
        {
            return await _context.USUARIO.AnyAsync(e => e.idUsuario == id);
        }

        public async Task<List<UsuarioDTO>> ObtenerUsuarios(int tipo,string dato)
        {
            if(tipo == 1)
            {
                return await (from u in _context.USUARIO
                              where u.idEstado != 2
                              select new UsuarioDTO()
                              {
                                  idUsuario = u.idUsuario,
                                  descripcion = u.descripcion,
                                  fechaInscripcion = u.fechaInscripcion,
                                  idEstado = u.idEstado,
                                  descEstado = (from e in _context.ESTADO where e.idEstado == u.idEstado select e.descripcion).FirstOrDefault(),
                                  facturacion = u.facturacion,
                                  plataformasxusuario = (from up in _context.USUARIOPLATAFORMA
                                                         where up.idUsuario == u.idUsuario
                                                         orderby up.idUsuario
                                                         select new UsuarioPlataformaDTO()
                                                         {
                                                             idUsuario = up.idUsuario,
                                                             idPlataforma = up.idPlataforma,
                                                             descPlataforma = (from p in _context.PLATAFORMA
                                                                               where p.idPlataforma == up.idPlataforma
                                                                               select p.descripcion).FirstOrDefault(),
                                                             cantidad = up.cantidad,
                                                             idCuenta = up.idCuenta,
                                                             credencial = (from c in _context.CUENTA
                                                                           where c.idCuenta == up.idCuenta
                                                                           select new UsuarioPlataformaDTO.Credencial()
                                                                           {
                                                                               usuario = c.descripcion,
                                                                               clave = c.password
                                                                           }).FirstOrDefault()
                                                         }).ToList(),
                                  pago = u.pago
                              }).ToListAsync();
            }
            else if(tipo == 2)
            {
                return await (from u in _context.USUARIO
                              where u.idEstado != 2 && u.idUsuario == int.Parse(dato)
                              select new UsuarioDTO()
                              {
                                  idUsuario = u.idUsuario,
                                  descripcion = u.descripcion,
                                  fechaInscripcion = u.fechaInscripcion,
                                  idEstado = u.idEstado,
                                  descEstado = (from e in _context.ESTADO where e.idEstado == u.idEstado select e.descripcion).FirstOrDefault(),
                                  facturacion = u.facturacion,
                                  plataformasxusuario = (from up in _context.USUARIOPLATAFORMA
                                                         where up.idUsuario == u.idUsuario
                                                         orderby up.idUsuario
                                                         select new UsuarioPlataformaDTO()
                                                         {
                                                             idUsuario = up.idUsuario,
                                                             idPlataforma = up.idPlataforma,
                                                             descPlataforma = (from p in _context.PLATAFORMA
                                                                               where p.idPlataforma == up.idPlataforma
                                                                               select p.descripcion).FirstOrDefault(),
                                                             cantidad = up.cantidad,
                                                             idCuenta = up.idCuenta,
                                                             credencial = (from c in _context.CUENTA
                                                                           where c.idCuenta == up.idCuenta
                                                                           select new UsuarioPlataformaDTO.Credencial()
                                                                           {
                                                                               usuario = c.descripcion,
                                                                               clave = c.password
                                                                           }).FirstOrDefault()
                                                         }).ToList(),
                                  pago = u.pago
                              }).ToListAsync();
            }
            else
            {
                return await (from u in _context.USUARIO
                              where u.idEstado != 2 && u.descripcion == dato
                              select new UsuarioDTO()
                              {
                                  idUsuario = u.idUsuario,
                                  descripcion = u.descripcion,
                                  fechaInscripcion = u.fechaInscripcion,
                                  idEstado = u.idEstado,
                                  descEstado = (from e in _context.ESTADO where e.idEstado == u.idEstado select e.descripcion).FirstOrDefault(),
                                  facturacion = u.facturacion,
                                  plataformasxusuario = (from up in _context.USUARIOPLATAFORMA
                                                         where up.idUsuario == u.idUsuario
                                                         orderby up.idUsuario
                                                         select new UsuarioPlataformaDTO()
                                                         {
                                                             idUsuario = up.idUsuario,
                                                             idPlataforma = up.idPlataforma,
                                                             descPlataforma = (from p in _context.PLATAFORMA
                                                                               where p.idPlataforma == up.idPlataforma
                                                                               select p.descripcion).FirstOrDefault(),
                                                             cantidad = up.cantidad,
                                                             idCuenta = up.idCuenta,
                                                             credencial = (from c in _context.CUENTA
                                                                           where c.idCuenta == up.idCuenta
                                                                           select new UsuarioPlataformaDTO.Credencial()
                                                                           {
                                                                               usuario = c.descripcion,
                                                                               clave = c.password
                                                                           }).FirstOrDefault()
                                                         }).ToList(),
                                  pago = u.pago
                              }).ToListAsync();
            }
        }
    }
}
