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
    public class PlataformaRepository:IPlataformaRepository
    {
        private readonly BillycockServiceContext _context;
        private readonly ICommonRepository<Plataforma> _commonRepository_P;
        private readonly IPlataformaCuentaRepository _Repository_PC;
        private readonly IEstadoRepository _Repository_E;
        private readonly IUsuarioPlataformaCuentaRepository _Repository_UPC;
        public PlataformaRepository(BillycockServiceContext context
            , ICommonRepository<Plataforma> commonRepository_P
            , IEstadoRepository Repository_E
            , IPlataformaCuentaRepository Repository_PC
            , IUsuarioPlataformaCuentaRepository Repository_UPC)
        {
            _context = context;
            _commonRepository_P = commonRepository_P;
            _Repository_E = Repository_E;
            _Repository_PC = Repository_PC;
            _Repository_UPC = Repository_UPC;
            Globales.mensaje = string.Empty;
        }
        #region Create
        public async Task CreatePlataforma(PlataformaDTO.Create_P plataforma)
        {
            try
            {
                Globales.mensaje = await _commonRepository_P.InsertObjeto(new Plataforma()
                {
                    descripcion = plataforma.descripcion,
                    idEstado = plataforma.idEstado,
                    numeroMaximoUsuarios = plataforma.numeroMaximoUsuarios,
                    precio = plataforma.precio,
                    costo = plataforma.costo
                }, _context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Globales.mensaje = await _commonRepository_P.ExceptionMessage(new Plataforma()
                {
                    descripcion = plataforma.descripcion,
                    idEstado = plataforma.idEstado,
                    numeroMaximoUsuarios = plataforma.numeroMaximoUsuarios,
                    precio = plataforma.precio,
                    costo = plataforma.costo
                }, "C");
            }
        }
        #endregion
        #region Read
        public async Task<List<PlataformaDTO.Read_P>> GetPlataformas(bool complemento)
        {
            return await ObtenerPlataformas(1, null, complemento);
        }
        public async Task<PlataformaDTO.Read_P> GetPlataformabyId(int? id, bool complemento)
        {
            List<PlataformaDTO.Read_P> plataformas = await ObtenerPlataformas(2, id.ToString(), complemento);
            if (plataformas.Count == 1) return plataformas[0];
            else return null;
        }
        public async Task<PlataformaDTO.Read_P> GetPlataformabyName(string name, bool complemento)
        {
            List<PlataformaDTO.Read_P> plataformas = await ObtenerPlataformas(2, name, complemento);
            if (plataformas.Count == 1) return plataformas[0];
            else return null;
        }
        public async Task<bool> PlataformaExists(int id)
        {
            return await _context.PLATAFORMA.AnyAsync(e => e.idPlataforma == id);
        }
        public async Task<List<PlataformaDTO.Read_P>> ObtenerPlataformas(int tipo, string dato, bool complemento)
        {
            List<PlataformaDTO.Read_P> plataformas;
            List<PlataformaCuenta> plataformaCuentas = new List<PlataformaCuenta>();
            List<PlataformaCuenta> _plataformaCuentas;
            List<UsuarioPlataformaCuenta> usuarioPlataformaCuentas = new List<UsuarioPlataformaCuenta>();
            if (tipo == 1)
            {
                plataformas = await (from p in _context.PLATAFORMA
                                     orderby p.idPlataforma
                                     select new PlataformaDTO.Read_P()
                                     {
                                         idPlataforma = p.idPlataforma,
                                         descripcion = p.descripcion,
                                         idEstado = p.idEstado,
                                         numeroMaximoUsuarios = p.numeroMaximoUsuarios,
                                         precio = p.precio,
                                         costo = p.costo,
                                         descEstado = _Repository_E.GetEstadobyId(p.idEstado).Result.descripcion
                                     }).ToListAsync();
            }
            else if (tipo == 2)
            {
                plataformas = await (from p in _context.PLATAFORMA
                                     where p.idPlataforma == int.Parse(dato)
                                     orderby p.idPlataforma
                                     select new PlataformaDTO.Read_P()
                                     {
                                         idPlataforma = p.idPlataforma,
                                         descripcion = p.descripcion,
                                         idEstado = p.idEstado,
                                         numeroMaximoUsuarios = p.numeroMaximoUsuarios,
                                         precio = p.precio,
                                         costo = p.costo,
                                         descEstado = _Repository_E.GetEstadobyId(p.idEstado).Result.descripcion
                                     }).ToListAsync();
            }
            else
            {
                plataformas = await (from p in _context.PLATAFORMA
                                     where p.descripcion == dato
                                     orderby p.idPlataforma
                                     select new PlataformaDTO.Read_P()
                                     {
                                         idPlataforma = p.idPlataforma,
                                         descripcion = p.descripcion,
                                         idEstado = p.idEstado,
                                         numeroMaximoUsuarios = p.numeroMaximoUsuarios,
                                         precio = p.precio,
                                         costo = p.costo,
                                         descEstado = _Repository_E.GetEstadobyId(p.idEstado).Result.descripcion
                                     }).ToListAsync();
            }
            if (complemento)
            {
                foreach (var _plataforma in plataformas)
                {
                    plataformaCuentas = await _Repository_PC.GetPlataformaCuentasbyIdPlataforma(_plataforma.idPlataforma);
                    if(plataformaCuentas != null)
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
                        _plataforma.plataformaCuentas = _plataformaCuentas;
                    }
                    usuarioPlataformaCuentas = await _Repository_UPC.GetUsuarioPlataformaCuentasbyIdPlataforma(_plataforma.idPlataforma);
                    if (usuarioPlataformaCuentas != null)
                    {
                        _plataforma.usuarioPlataformaCuentas = usuarioPlataformaCuentas;
                    }
                }
            }
            return plataformas;
        }
        #endregion
        #region Update
        public async Task UpdatePlataforma(PlataformaDTO.Update_P plataforma)
        {
            Plataforma platform = await GetPlataformabyId(plataforma.idPlataforma, false);
            try
            {
                Globales.mensaje = await _commonRepository_P.UpdateObjeto(new Plataforma()
                {
                    idPlataforma = platform.idPlataforma,
                    descripcion = plataforma.descripcion,
                    idEstado = platform.idEstado,
                    numeroMaximoUsuarios = plataforma.numeroMaximoUsuarios,
                    precio = plataforma.precio,
                    costo = plataforma.costo
                }, _context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Globales.mensaje = await _commonRepository_P.ExceptionMessage(new Plataforma()
                {
                    idPlataforma = platform.idPlataforma,
                    descripcion = plataforma.descripcion,
                    idEstado = platform.idEstado,
                    numeroMaximoUsuarios = plataforma.numeroMaximoUsuarios,
                    precio = plataforma.precio,
                    costo = plataforma.costo
                }, "U");
            }
        }
        public async Task DeactivatePlataforma(PlataformaDTO.Update_P plataforma)
        {
            Plataforma platform = await GetPlataformabyId(plataforma.idPlataforma, false);
            platform.idEstado = 2;
            try
            {
                Globales.mensaje = await _commonRepository_P.UpdateObjeto(platform, _context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Globales.mensaje = await _commonRepository_P.ExceptionMessage(platform, "U");
            }
        }
        #endregion
        #region Delete
        public async Task DeletePlataforma(int id)
        {
            PlataformaDTO.Read_P platform = await GetPlataformabyId(id, false);
            try
            {
                Globales.mensaje += await _commonRepository_P.DeleteObjeto(platform, _context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Globales.mensaje += _commonRepository_P.ExceptionMessage(platform, "D");
            }
        }
        #endregion
    }
}
