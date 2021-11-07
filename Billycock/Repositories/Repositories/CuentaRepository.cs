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
    public class CuentaRepository: ICuentaRepository
    {
        private readonly BillycockServiceContext _context;
        private readonly ICommonRepository<Cuenta> _commonRepository_C;
        private readonly IPlataformaRepository _Repository_P;
        private readonly IEstadoRepository _Repository_E;
        private readonly IPlataformaCuentaRepository _Repository_PC;
        private readonly IUsuarioPlataformaCuentaRepository _Repository_UPC;

        public CuentaRepository(BillycockServiceContext context,
            ICommonRepository<Cuenta> commonRepository_C
            , IPlataformaRepository Repository_P
            , IEstadoRepository Repository_E
            , IPlataformaCuentaRepository Repository_PC
            , IUsuarioPlataformaCuentaRepository Repository_UPC
            )
        {
            _context = context;
            _commonRepository_C = commonRepository_C;
            _Repository_P = Repository_P;
            _Repository_E = Repository_E;
            _Repository_PC = Repository_PC;
            _Repository_UPC = Repository_UPC;
            Globales.mensaje = string.Empty;
        }
        #region Create
        public async Task CreateCuenta(CuentaDTO.Create_C cuenta)
        {
            Cuenta account = new Cuenta();
            int contador = 0;

            try
            {
                Globales.mensaje += await _commonRepository_C.InsertObjeto(new Cuenta()
                {
                    diminutivo = cuenta.diminutivo,
                    correo = cuenta.correo,
                    idEstado = cuenta.idEstado,
                    plataformaCuentas = cuenta.plataformaCuentas
                }, _context);
                if (Globales.mensaje.Contains("CORRECTA"))
                {
                    Globales.mensaje += Environment.NewLine;
                    try
                    {
                        account = await GetCuentabyName(cuenta.correo, false);
                        foreach (var item in cuenta.plataformaCuentas)
                        {
                            if (contador >= 1) Globales.mensaje += Environment.NewLine;
                            Globales.mensaje += await _Repository_PC.CreatePlataformaCuenta(new PlataformaCuentaDTO.Create_PC()
                            {
                                idCuenta = account.idCuenta,
                                idPlataforma = item.idPlataforma,
                                usuariosdisponibles = _Repository_P.GetPlataformabyId(item.idPlataforma, false).Result.numeroMaximoUsuarios
                            });
                            contador++;
                        }
                    }
                    catch
                    {
                        Globales.mensaje += await _commonRepository_C.ExceptionMessage(account, "C");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Globales.mensaje += await _commonRepository_C.ExceptionMessage(new Cuenta()
                {
                    diminutivo = cuenta.diminutivo,
                    correo = cuenta.correo,
                    idEstado = 1,
                    plataformaCuentas = cuenta.plataformaCuentas
                }, "C");
            }
        }
        #endregion
        #region Read
        public async Task<List<CuentaDTO.Read_C>> GetCuentas(bool complemento)
        {
            return await ObtenerCuentas(1, null, complemento);
        }
        public async Task<CuentaDTO.Read_C> GetCuentabyId(int? id, bool complemento)
        {
            List<CuentaDTO.Read_C> cuentas = await ObtenerCuentas(2, id.ToString(), complemento);
            if (cuentas.Count == 1) return cuentas[0];
            else return null;
        }
        public async Task<CuentaDTO.Read_C> GetCuentabyName(string name, bool complemento)
        {
            List<CuentaDTO.Read_C> cuentas = await ObtenerCuentas(3, name, complemento);
            if (cuentas.Count == 1) return cuentas[0];
            else return null;
        }
        public async Task<bool> CuentaExists(int id)
        {
            return await _context.CUENTA.AnyAsync(e => e.idCuenta == id);
        }
        public async Task<List<CuentaDTO.Read_C>> ObtenerCuentas(int tipo, string dato, bool complemento)
        {
            List<CuentaDTO.Read_C> cuentas;
            List<PlataformaCuenta> plataformaCuentas = new List<PlataformaCuenta>();
            List<PlataformaCuenta> _plataformaCuentas;
            List<UsuarioPlataformaCuenta> usuarioPlataformaCuentas;
            if (tipo == 1)
            {
                cuentas = await (from c in _context.CUENTA
                                 orderby c.idCuenta
                                 select new CuentaDTO.Read_C()
                                 {
                                     idCuenta = c.idCuenta,
                                     idEstado = c.idEstado,
                                     correo = c.correo,
                                     diminutivo = c.diminutivo,
                                     descEstado = _Repository_E.GetEstadobyId(c.idEstado).Result.descripcion
                                 }).ToListAsync();
            }
            else if (tipo == 2)
            {
                cuentas = await (from c in _context.CUENTA
                                 where c.idCuenta == int.Parse(dato)
                                 orderby c.idCuenta
                                 select new CuentaDTO.Read_C()
                                 {
                                     idCuenta = c.idCuenta,
                                     idEstado = c.idEstado,
                                     correo = c.correo,
                                     diminutivo = c.diminutivo,
                                     descEstado = _Repository_E.GetEstadobyId(c.idEstado).Result.descripcion
                                 }).ToListAsync();
            }
            else
            {
                cuentas = await (from c in _context.CUENTA
                                 where c.correo == dato
                                 orderby c.idCuenta
                                 select new CuentaDTO.Read_C()
                                 {
                                     idCuenta = c.idCuenta,
                                     idEstado = c.idEstado,
                                     correo = c.correo,
                                     diminutivo = c.diminutivo,
                                     descEstado = _Repository_E.GetEstadobyId(c.idEstado).Result.descripcion
                                 }).ToListAsync();
            }
            if (complemento)
            {
                foreach (var _cuenta in cuentas)
                {
                    plataformaCuentas = await _Repository_PC.GetPlataformaCuentasbyIdCuenta(_cuenta.idCuenta);
                    if (plataformaCuentas != null)
                    {
                        _plataformaCuentas = new List<PlataformaCuenta>();
                        foreach (var _plataformaCuenta in plataformaCuentas)
                        {
                            _plataformaCuentas.Add(new PlataformaCuenta()
                            {
                                idPlataformaCuenta = _plataformaCuenta.idPlataformaCuenta,
                                idPlataforma = _plataformaCuenta.idPlataforma,
                                idCuenta = _plataformaCuenta.idCuenta,
                                fechaPago = _plataformaCuenta.fechaPago,
                                clave = _plataformaCuenta.clave,
                                usuariosdisponibles = _plataformaCuenta.usuariosdisponibles
                            });
                        }
                        _cuenta.plataformaCuentas = _plataformaCuentas;
                    }
                    usuarioPlataformaCuentas = await _Repository_UPC.GetUsuarioPlataformaCuentasbyIdCuenta(_cuenta.idCuenta);
                    if (usuarioPlataformaCuentas != null)
                    {
                        _cuenta.usuarioPlataformaCuentas = usuarioPlataformaCuentas;
                    }
                }
            }
            return cuentas;
        }
        #endregion
        #region Update
        public async Task UpdateCuenta(CuentaDTO.Update_C cuenta)
        {
            List<PlataformaCuenta> plataformacuentasAgregarEliminar = new List<PlataformaCuenta>();
            PlataformaCuenta plataformaCuentaTemporal;

            Cuenta account = await GetCuentabyId(cuenta.idCuenta, true);
            try
            {
                Globales.mensaje += await _commonRepository_C.UpdateObjeto(new Cuenta()
                {
                    idCuenta = account.idCuenta,
                    diminutivo = cuenta.diminutivo,
                    correo = cuenta.correo,
                    plataformaCuentas = cuenta.plataformaCuentas,
                    idEstado = account.idEstado
                }, _context);

                if (Globales.mensaje.Contains("CORRECTA"))
                {
                    foreach (var item in account.plataformaCuentas)
                    {
                        plataformaCuentaTemporal = cuenta.plataformaCuentas
                            .Where(u => u.idPlataforma == item.idPlataforma && u.idCuenta == item.idCuenta)
                            .Select(u => u).FirstOrDefault();
                        if (plataformaCuentaTemporal == null)
                        {
                            plataformacuentasAgregarEliminar.Add(new PlataformaCuenta() //Eliminar
                            {
                                idPlataforma = item.idPlataforma
                            });
                        }
                    }
                    foreach (var item in plataformacuentasAgregarEliminar)
                    {
                        Globales.mensaje += Environment.NewLine;
                        Globales.mensaje += await _Repository_PC.DeletePlataformaCuenta(item.idPlataformaCuenta);
                    }
                    plataformacuentasAgregarEliminar = new List<PlataformaCuenta>();
                    foreach (var item in cuenta.plataformaCuentas)
                    {
                        plataformaCuentaTemporal = cuenta.plataformaCuentas
                            .Where(u => u.idPlataforma == item.idPlataforma && u.idCuenta == item.idCuenta)
                            .Select(u => u).FirstOrDefault();
                        if (plataformaCuentaTemporal == null)
                        {
                            plataformacuentasAgregarEliminar.Add(new PlataformaCuenta() //Agregar
                            {
                                idPlataforma = item.idPlataforma
                            });
                        }
                    }
                    foreach (var item in plataformacuentasAgregarEliminar)
                    {
                        Globales.mensaje += Environment.NewLine;
                        Globales.mensaje += await _Repository_PC.CreatePlataformaCuenta(new PlataformaCuentaDTO.Create_PC()
                        {
                            idPlataforma = item.idPlataforma,
                            idCuenta = account.idCuenta,
                            usuariosdisponibles = _Repository_P.GetPlataformabyId(item.idPlataforma, false).Result.numeroMaximoUsuarios
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Globales.mensaje += await _commonRepository_C.ExceptionMessage(new Cuenta()
                {
                    idCuenta = account.idCuenta,
                    diminutivo = cuenta.diminutivo,
                    correo = cuenta.correo,
                    plataformaCuentas = cuenta.plataformaCuentas,
                    idEstado = account.idEstado
                }, "U");
            }
        }
        public async Task DeactivateCuenta(CuentaDTO.Update_C cuenta)
        {
            Cuenta account = await GetCuentabyId(cuenta.idCuenta, false);
            account.idEstado = 2;
            try
            {
                Globales.mensaje = await _commonRepository_C.UpdateObjeto(account, _context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Globales.mensaje = await _commonRepository_C.ExceptionMessage(account, "U");
            }
        }
        #endregion
        #region Delete
        public async Task DeleteCuenta(int id)
        {
            Cuenta account = await GetCuentabyId(id, false);
            try
            {
                Globales.mensaje += await _commonRepository_C.DeleteObjeto(account, _context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Globales.mensaje += _commonRepository_C.ExceptionMessage(account, "D");
            }
        }
        #endregion
    }
}
