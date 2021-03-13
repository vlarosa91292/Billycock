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
                _context.Update(new Usuario()
                {
                    idUsuario = user.idUsuario,
                    descripcion = user.descripcion,
                    idEstado = 2,
                    fechaInscripcion = user.fechaInscripcion,
                    facturacion = user.facturacion
                });
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
            List<PlataformaCuentaDTO> plataformacuentas = new List<PlataformaCuentaDTO>();
            PlataformaCuentaDTO plataformacuenta = new PlataformaCuentaDTO();
            List<string> resultadonulo = new List<string>();
            try
            {
                foreach (var item in usuario.plataformasxusuario)
                {
                    plataformacuenta = await _cuentaRepository.GetCuentaDisponible(item.idPlataforma, item.cantidad);
                    if (plataformacuenta == null) resultadonulo.Add(item.cantidad+"-"+_context.PLATAFORMA.Find(item.idPlataforma).descripcion);
                    plataformacuentas.Add(plataformacuenta);
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
                    facturacion = DateTime.Now.Day <= 15?"Quincena":"Fin de Mes",
                    pago = ObtenerMontoPago(usuario.plataformasxusuario)
                });
                await Save();
                for(int i= 0;i< plataformacuentas.Count;i++)
                {
                    user = await GetUsuariobyName(usuario.descripcion);
                    await _context.USUARIOPLATAFORMA.AddAsync(new UsuarioPlataforma()
                    {
                        idUsuario = user.idUsuario,
                        idPlataforma = usuario.plataformasxusuario[i].idPlataforma,
                        cantidad = usuario.plataformasxusuario[i].cantidad,
                        idCuenta = plataformacuentas[i].idCuenta
                    });
                    await Save();
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

        private double? ObtenerMontoPago(List<UsuarioPlataformaDTO> usuarioPlataforma)
        {
            double? pago = 0;
            for (int i = 0; i < usuarioPlataforma.Count; i++)
            {
                pago += ((from p in _context.PLATAFORMA
                            where p.idPlataforma == usuarioPlataforma[i].idPlataforma
                            select p.precio).FirstOrDefault()) * usuarioPlataforma[i].cantidad;
                
                if(i == usuarioPlataforma.Count-1)
                {
                    if (usuarioPlataforma[i].cantidad == 1 && usuarioPlataforma.Count > 1) { pago = reproceso(1,usuarioPlataforma.Count,pago); }
                    else if (usuarioPlataforma[i].cantidad > 1 && usuarioPlataforma.Count == 1) { pago = reproceso(2, usuarioPlataforma[i].cantidad, pago); }
                }
            }
            return pago;
        }

        private double reproceso(int tipo, int? cuenta,double? monto)
        {
            if(tipo == 1)
            {
                return (double)((monto / cuenta) * (cuenta * 0.8)); 
            }
            else
            {
                return (double)(monto * 0.7);
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
                    pago = ObtenerMontoPago(user.plataformasxusuario)
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
