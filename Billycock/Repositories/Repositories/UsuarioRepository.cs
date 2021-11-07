using Billycock.Data;
using Billycock.DTO;
using Billycock.Models;
using Billycock.Repositories.Interfaces;
using Billycock.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Api_Billycock.Program;

namespace Billycock.Repositories.Repositories
{
    public class UsuarioRepository:IUsuarioRepository
    {
        private readonly BillycockServiceContext _context;
        private readonly ICommonRepository<Usuario> _commonRepository_U;
        private readonly IPlataformaRepository _Repository_P;
        private readonly IPlataformaCuentaRepository _Repository_PC;
        private readonly IUsuarioPlataformaCuentaRepository _Repository_UPC;
        
        public UsuarioRepository(BillycockServiceContext context, ICommonRepository<Usuario> commonRepository_U
            ,IPlataformaRepository Repository_P, IPlataformaCuentaRepository Repository_PC
            , IUsuarioPlataformaCuentaRepository Repository_UPC)
        {
            _context = context;
            _commonRepository_U = commonRepository_U;
            _Repository_P = Repository_P;
            _Repository_PC = Repository_PC;
            _Repository_UPC = Repository_UPC;
            Globales.mensaje = string.Empty;
        }
        #region Create
        public async Task CreateUsuario(UsuarioDTO.Create_U usuario)
        {
            try
            {
                if(await GetUsuariobyName(usuario.descripcion,false) != null)
                {
                    Globales.mensaje = "Ya existe un usuario con ese nombre";
                }
                else
                {
                    if (await ValidarPlataformaCuentasDisponibles(usuario.usuarioPlataformaCuentas))
                    {
                        Globales.mensaje += await _commonRepository_U.InsertObjeto(new Usuario()
                        {
                            descripcion = usuario.descripcion,
                            idEstado = usuario.idEstado,
                            fechaInscripcion = _commonRepository_U.SetearFechaTiempo(),
                            facturacion = _commonRepository_U.ObtenerFechaFacturacionUsuario(),
                            pago = await ObtenerMontoPagoUsuario(usuario.usuarioPlataformaCuentas)
                        }, _context);

                        await ObteneryReservarPlataformaCuentas(usuario.usuarioPlataformaCuentas, usuario.descripcion);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Globales.mensaje += await _commonRepository_U.ExceptionMessage(new Usuario()
                {
                    descripcion = usuario.descripcion,
                    contacto = usuario.contacto,
                    idEstado = usuario.idEstado,
                    pin = usuario.pin,
                    usuarioPlataformaCuentas = usuario.usuarioPlataformaCuentas
                }, "C");
            }
        }
        #endregion
        #region Read
        public async Task<List<UsuarioDTO.Read_U>> GetUsuarios(bool complemento)
        {
            return await ObtenerUsuarios(1, null, complemento);
        }
        public async Task<UsuarioDTO.Read_U> GetUsuariobyId(int? id, bool complemento)
        {
            List<UsuarioDTO.Read_U> usuarios = await ObtenerUsuarios(2, id.ToString(), complemento);
            if (usuarios.Count == 1) return usuarios[0];
            else return null;
        }
        public async Task<UsuarioDTO.Read_U> GetUsuariobyName(string name, bool complemento)
        {
            List<UsuarioDTO.Read_U> usuarios = await ObtenerUsuarios(3, name, complemento);
            if (usuarios.Count == 1) return usuarios[0];
            else return null;
        }
        public async Task<bool> UsuarioExists(int id)
        {
            return await _context.USUARIO.AnyAsync(e => e.idUsuario == id);
        }
        public async Task<List<UsuarioDTO.Read_U>> ObtenerUsuarios(int tipo, string dato, bool complemento)
        {
            List<UsuarioDTO.Read_U> usuarios = new List<UsuarioDTO.Read_U>();
            List<UsuarioPlataformaCuenta> usuarioPlataformaCuentas = new List<UsuarioPlataformaCuenta>();
            UsuarioPlataformaCuenta usuarioPlataformaCuenta = new UsuarioPlataformaCuenta();
            try
            {
                if (tipo == 1)
                {
                    usuarios = await (from u in _context.USUARIO
                                      orderby u.idUsuario
                                      select new UsuarioDTO.Read_U()
                                      {
                                          idUsuario = u.idUsuario,
                                          descripcion = u.descripcion,
                                          fechaInscripcion = u.fechaInscripcion,
                                          idEstado = u.idEstado,
                                          facturacion = u.facturacion,
                                          pago = u.pago
                                      }).ToListAsync();

                }
                else if (tipo == 2)
                {
                    usuarios = await (from u in _context.USUARIO
                                      where u.idUsuario == int.Parse(dato)
                                      orderby u.idUsuario
                                      select new UsuarioDTO.Read_U()
                                      {
                                          idUsuario = u.idUsuario,
                                          descripcion = u.descripcion,
                                          fechaInscripcion = u.fechaInscripcion,
                                          idEstado = u.idEstado,
                                          facturacion = u.facturacion,
                                          pago = u.pago
                                      }).ToListAsync();

                }
                else
                {
                    usuarios = await (from u in _context.USUARIO
                                      where u.descripcion == dato
                                      orderby u.idUsuario
                                      select new UsuarioDTO.Read_U()
                                      {
                                          idUsuario = u.idUsuario,
                                          descripcion = u.descripcion,
                                          fechaInscripcion = u.fechaInscripcion,
                                          idEstado = u.idEstado,
                                          facturacion = u.facturacion,
                                          pago = u.pago,

                                      }).ToListAsync();

                }
                if (complemento)
                {
                    foreach (var _usuario in usuarios)
                    {
                        usuarioPlataformaCuentas = await _Repository_UPC.GetUsuarioPlataformaCuentasbyIdUsuario(_usuario.idUsuario);
                        if (usuarioPlataformaCuentas != null)
                        {
                            _usuario.usuarioPlataformaCuentas = usuarioPlataformaCuentas;
                        }
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
        #region Update
        public async Task UpdateUsuario(UsuarioDTO.Update_U usuario)
        {
            try
            {
                UsuarioDTO.Read_U user = await GetUsuariobyId(usuario.idUsuario, true);
                await CrearActualizarEliminarUsuarioPlataformaCuenta(new UsuarioDTO.Update_U()
                {
                    idUsuario = user.idUsuario,
                    descripcion = user.descripcion,
                    contacto = user.contacto,
                    pin = user.pin,
                    idEstado = user.idEstado,
                    usuarioPlataformaCuentas = user.usuarioPlataformaCuentas
                }, usuario);

                if (Globales.mensaje != string.Empty) Globales.mensaje += Environment.NewLine;
                Globales.mensaje += await _commonRepository_U.UpdateObjeto(new Usuario()
                {
                    idUsuario = user.idUsuario,
                    descripcion = usuario.descripcion,
                    idEstado = user.idEstado,
                    fechaInscripcion = user.fechaInscripcion,
                    facturacion = user.facturacion,
                    pago = await ObtenerMontoPagoUsuario(usuario.usuarioPlataformaCuentas),
                    pin = usuario.pin,
                    contacto = usuario.contacto
                }, _context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Globales.mensaje += _commonRepository_U.ExceptionMessage(new Usuario()
                {
                    idUsuario = usuario.idUsuario,
                    descripcion = usuario.descripcion,
                    contacto = usuario.contacto,
                    idEstado = usuario.idEstado,
                    pin = usuario.pin,
                    usuarioPlataformaCuentas = usuario.usuarioPlataformaCuentas
                }, "U");
            }
        }
        public async Task DeactivateUsuario(Usuario usuario)
        {
            try
            {
                Usuario user = await GetUsuariobyId(usuario.idUsuario, true);
                user.idEstado = 2;
                Globales.mensaje += await _commonRepository_U.UpdateObjeto(user, _context);
                foreach (var item in user.usuarioPlataformaCuentas)
                {
                    PlataformaCuenta plataformaCuenta = await _Repository_PC.GetPlataformaCuentabyIds(item.Plataforma+"-"+item.idCuenta);
                    Globales.mensaje += await _Repository_PC.UpdatePlataformaCuenta(new PlataformaCuentaDTO.Update_PC()
                    {
                        idPlataformaCuenta = plataformaCuenta.idPlataformaCuenta,
                        fechaPago = plataformaCuenta.fechaPago,
                        clave = plataformaCuenta.clave,
                        usuariosdisponibles = plataformaCuenta.usuariosdisponibles + item.cantidad
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Globales.mensaje += _commonRepository_U.ExceptionMessage(usuario, "U");
            }
        }
        #endregion
        #region Delete
        public async Task DeleteUsuario(Usuario usuario)
        {
            try
            {
                Usuario user = await GetUsuariobyId(usuario.idUsuario, false);
                user.idEstado = 2;
                Globales.mensaje += await _commonRepository_U.DeleteObjeto(user, _context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Globales.mensaje += _commonRepository_U.ExceptionMessage(usuario, "D");
            }
        }
        #endregion
        #region  Extras
        public async Task<int> ObtenerMontoPagoUsuario(List<UsuarioPlataformaCuenta> UsuarioPlataformaCuentas)
        {
            double acumulado = 0;
            Plataforma Plataforma;
            for (int i = 0; i < UsuarioPlataformaCuentas.Count; i++)
            {
                Plataforma = await _Repository_P.GetPlataformabyId(UsuarioPlataformaCuentas[i].idPlataforma, false);
                if (UsuarioPlataformaCuentas[i].cantidad > 1 && UsuarioPlataformaCuentas[i].cantidad < 4) acumulado += Plataforma.precio * UsuarioPlataformaCuentas[i].cantidad * 0.875;
                else acumulado += Plataforma.precio * UsuarioPlataformaCuentas[i].cantidad;
            }
            if (UsuarioPlataformaCuentas.Count >= 2) { acumulado = _commonRepository_U.reprocesoUsuario(UsuarioPlataformaCuentas.Count, acumulado); }
            return (int)(acumulado);
        }
        public async Task CrearActualizarEliminarUsuarioPlataformaCuenta(UsuarioDTO.Update_U user, UsuarioDTO.Update_U usuario)
        {
            List<UsuarioPlataformaCuentaDTO.Create_UPC> usuarioplataformacuentasAgregar = new List<UsuarioPlataformaCuentaDTO.Create_UPC>();
            List<PlataformaCuenta> plataformacuentasTotalitario = new List<PlataformaCuenta>();
            List<UsuarioPlataformaCuentaDTO.Update_UPC> usuarioplataformacuentasActualizar = new List<UsuarioPlataformaCuentaDTO.Update_UPC>();
            List<UsuarioPlataformaCuenta> usuarioplataformacuentasEliminar = new List<UsuarioPlataformaCuenta>();
            UsuarioPlataformaCuenta usuarioPlataformaCuentaTemporal;

            foreach (var item in usuario.usuarioPlataformaCuentas)
            {
                usuarioPlataformaCuentaTemporal = user.usuarioPlataformaCuentas.Where(u => u.idUsuario == item.idUsuario && u.idPlataforma == item.idPlataforma)
                    .Select(u => u).FirstOrDefault();
                if (usuarioPlataformaCuentaTemporal == null)
                {
                    usuarioplataformacuentasAgregar.Add(new UsuarioPlataformaCuentaDTO.Create_UPC()
                    {
                        idUsuario = usuario.idUsuario,
                        idPlataforma = item.idPlataforma,
                        cantidad = item.cantidad
                    });
                }
            }
            foreach (var item in user.usuarioPlataformaCuentas)
            {
                usuarioPlataformaCuentaTemporal = usuario.usuarioPlataformaCuentas
                    .Where(u => u.idUsuario == item.idUsuario && u.idPlataforma == item.idPlataforma && u.idCuenta == item.idCuenta)
                    .Select(u => u).FirstOrDefault();
                if (usuarioPlataformaCuentaTemporal != null)
                {
                    if (usuarioPlataformaCuentaTemporal.cantidad != item.cantidad)
                    {
                        usuarioplataformacuentasActualizar.Add(new UsuarioPlataformaCuentaDTO.Update_UPC()
                        {
                            idUsuarioPlataformaCuenta = usuarioPlataformaCuentaTemporal.idUsuarioPlataformaCuenta,
                            idPlataforma = usuarioPlataformaCuentaTemporal.idPlataforma,
                            cantidad = item.cantidad - usuarioPlataformaCuentaTemporal.cantidad
                        });
                    }
                }
                else
                {
                    usuarioplataformacuentasEliminar.Add(new UsuarioPlataformaCuenta()
                    {
                        idUsuarioPlataformaCuenta = usuarioPlataformaCuentaTemporal.idUsuarioPlataformaCuenta
                    });
                }
            }

            foreach (var agregar in usuarioplataformacuentasAgregar)
            {
                if (await ValidarPlataformaCuentasDisponibles(new List<UsuarioPlataformaCuenta>() { new UsuarioPlataformaCuenta() {idPlataforma = agregar.idPlataforma,cantidad=agregar.cantidad} }))
                {
                    await ObteneryReservarPlataformaCuentas(new List<UsuarioPlataformaCuenta>() { new UsuarioPlataformaCuenta() { idPlataforma = agregar.idPlataforma, cantidad = agregar.cantidad }}, user.descripcion);
                }
                else return;
            }
            foreach (var actualizar in usuarioplataformacuentasActualizar)
            {
                if (actualizar.cantidad < 0)
                {
                    if (await ValidarPlataformaCuentasDisponibles(new List<UsuarioPlataformaCuenta>() { new UsuarioPlataformaCuenta() { idPlataforma = actualizar.idPlataforma, cantidad = actualizar.cantidad } }))
                    {
                        await ObteneryReservarPlataformaCuentas(new List<UsuarioPlataformaCuenta>() { new UsuarioPlataformaCuenta() { idPlataforma = actualizar.idPlataforma, cantidad = actualizar.cantidad } }, user.descripcion);
                        if (Globales.mensaje != string.Empty) Globales.mensaje += Environment.NewLine;
                        UsuarioPlataformaCuenta usuarioPlataformaCuenta = await _Repository_UPC.GetUsuarioPlataformaCuentabyIds(actualizar.idUsuarioPlataformaCuenta);
                        usuarioPlataformaCuenta.cantidad -= actualizar.cantidad;
                        Globales.mensaje += await _Repository_UPC.DeleteUsuarioPlataformaCuenta(actualizar.idUsuarioPlataformaCuenta);

                        Globales.mensaje += await _Repository_UPC.InsertUsuarioPlataformaCuenta(new UsuarioPlataformaCuentaDTO.Create_UPC()
                        {
                            idUsuario = usuarioPlataformaCuenta.idUsuario,
                            idPlataforma = usuarioPlataformaCuenta.idPlataforma,
                            idCuenta = usuarioPlataformaCuenta.idCuenta,
                            cantidad = usuarioPlataformaCuenta.cantidad
                        });
                    }
                    else return;
                }
                else
                {
                    if (Globales.mensaje != string.Empty) Globales.mensaje += Environment.NewLine;
                    UsuarioPlataformaCuenta usuarioPlataformaCuenta = await _Repository_UPC.GetUsuarioPlataformaCuentabyIds(actualizar.idUsuarioPlataformaCuenta);
                    usuarioPlataformaCuenta.cantidad -= actualizar.cantidad;
                    Globales.mensaje += await _Repository_UPC.DeleteUsuarioPlataformaCuenta(actualizar.idUsuarioPlataformaCuenta);

                    Globales.mensaje += await _Repository_UPC.InsertUsuarioPlataformaCuenta(new UsuarioPlataformaCuentaDTO.Create_UPC()
                    {
                        idUsuario = usuarioPlataformaCuenta.idUsuario,
                        idPlataforma = usuarioPlataformaCuenta.idPlataforma,
                        idCuenta = usuarioPlataformaCuenta.idCuenta,
                        cantidad = usuarioPlataformaCuenta.cantidad
                    });
                }
            }
            foreach (var eliminar in usuarioplataformacuentasEliminar)
            {
                if (Globales.mensaje != string.Empty) Globales.mensaje += Environment.NewLine;
                Globales.mensaje += await _Repository_UPC.DeleteUsuarioPlataformaCuenta(eliminar.idUsuarioPlataformaCuenta);
            }
        }
        public async Task<bool> ValidarPlataformaCuentasDisponibles(List<UsuarioPlataformaCuenta> usuarioplataformacuentasAgregar)
        {
            List<string> resultadonulo = new List<string>();

            foreach (var item in usuarioplataformacuentasAgregar)
            {
                int usuariosdisponibles = _Repository_PC.GetPlataformaCuentasbyIdPlataforma(item.idPlataforma).Result.Sum(pc => pc.usuariosdisponibles);

                if (usuariosdisponibles < item.cantidad) resultadonulo.Add(item.cantidad + "-" + (await _Repository_P.GetPlataformabyId(item.idPlataforma, false)).descripcion);
            }
            if (resultadonulo.Any())
            {
                if (Globales.mensaje != string.Empty) Globales.mensaje += Environment.NewLine;
                Globales.mensaje += "NO HAY SUFICIENTES USUARIOS DISPONIBLES: ";

                for (int i = 0; i < resultadonulo.Count; i++)
                {
                    Globales.mensaje += Environment.NewLine;
                    Globales.mensaje += resultadonulo[i];
                }

                return false;
            }
            else
            {
                return true;
            }
        }
        public async Task ObteneryReservarPlataformaCuentas(List<UsuarioPlataformaCuenta> usuarioplataformacuentasAgregar,string descripcion)
        {
            PlataformaCuenta platformAccount;

            Usuario user = await GetUsuariobyName(descripcion, false);
            foreach (var item in usuarioplataformacuentasAgregar)
            {
                platformAccount = await _Repository_PC.GetPlataformaCuentaDisponible(item.idPlataforma, item.cantidad);
                if (platformAccount == null)
                {
                    for (int i = 0; i < item.cantidad; i++)
                    {
                        platformAccount = new PlataformaCuenta();
                        platformAccount = await _Repository_PC.GetPlataformaCuentaDisponible(item.idPlataforma, 1);
                        if (platformAccount != null)
                        {
                            Globales.mensaje += Environment.NewLine;
                            Globales.mensaje += await _Repository_UPC.InsertUsuarioPlataformaCuenta(new UsuarioPlataformaCuentaDTO.Create_UPC()
                            {
                                idUsuario = user.idUsuario,
                                idPlataforma = item.idPlataforma,
                                idCuenta = platformAccount.idCuenta,
                                cantidad = 1
                            });
                        }
                    }
                }
                else
                {
                    Globales.mensaje += Environment.NewLine;
                    Globales.mensaje += await _Repository_UPC.InsertUsuarioPlataformaCuenta(new UsuarioPlataformaCuentaDTO.Create_UPC()
                    {
                        idUsuario = user.idUsuario,
                        idPlataforma = item.idPlataforma,
                        idCuenta = platformAccount.idCuenta,
                        cantidad = item.cantidad
                    });
                }
            }
        }
        #endregion
    }
}
