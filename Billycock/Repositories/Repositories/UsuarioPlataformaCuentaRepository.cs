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
    public class UsuarioPlataformaCuentaRepository: IUsuarioPlataformaCuentaRepository
    {
        private readonly BillycockServiceContext _context;
        private readonly ICommonRepository<UsuarioPlataformaCuenta> _commonRepository_UPC;

        public UsuarioPlataformaCuentaRepository(BillycockServiceContext context, ICommonRepository<Usuario> commonRepository_U,
            ICommonRepository<UsuarioPlataformaCuenta> commonRepository_UPC)
        {
            _context = context;
            _commonRepository_UPC = commonRepository_UPC;
            Globales.mensaje = string.Empty;
        }
        #region Create
        public async Task<string> InsertUsuarioPlataformaCuenta(UsuarioPlataformaCuentaDTO.Create_UPC usuarioPlataformaCuenta)
        {
            try
            {
                return await _commonRepository_UPC.InsertObjeto(new UsuarioPlataformaCuenta()
                {
                    idUsuarioPlataformaCuenta = usuarioPlataformaCuenta.idUsuario.ToString() + "-" + usuarioPlataformaCuenta.idPlataforma.ToString() + "-" + usuarioPlataformaCuenta.idCuenta.ToString(),
                    idUsuario = usuarioPlataformaCuenta.idUsuario,
                    idPlataforma = usuarioPlataformaCuenta.idPlataforma,
                    idCuenta = usuarioPlataformaCuenta.idCuenta,
                    cantidad = usuarioPlataformaCuenta.cantidad
                }, _context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await _commonRepository_UPC.ExceptionMessage(new UsuarioPlataformaCuenta()
                {
                    idUsuarioPlataformaCuenta = usuarioPlataformaCuenta.idUsuario.ToString() + "-" + usuarioPlataformaCuenta.idPlataforma.ToString() + "-" + usuarioPlataformaCuenta.idCuenta.ToString(),
                    idUsuario = usuarioPlataformaCuenta.idUsuario,
                    idPlataforma = usuarioPlataformaCuenta.idPlataforma,
                    idCuenta = usuarioPlataformaCuenta.idCuenta,
                    cantidad = usuarioPlataformaCuenta.cantidad
                }, "C");
            }
        }
        #endregion
        #region Read
        public async Task<List<UsuarioPlataformaCuenta>> GetUsuarioPlataformaCuentas()
        {
            return await ObtenerUsuarioPlataformaCuentas(1, null);
        }
        public async Task<UsuarioPlataformaCuenta> GetUsuarioPlataformaCuentabyIds(string id)
        {
            List<UsuarioPlataformaCuenta> usuarioPlataformaCuentas = await ObtenerUsuarioPlataformaCuentas(2, id);
            if (usuarioPlataformaCuentas.Count == 1) return usuarioPlataformaCuentas[0];
            else return null;
        }
        public async Task<List<UsuarioPlataformaCuenta>> GetUsuarioPlataformaCuentasbyIdUsuario(int id)
        {
            return (await ObtenerUsuarioPlataformaCuentas(3, id.ToString()));
        }
        public async Task<List<UsuarioPlataformaCuenta>> GetUsuarioPlataformaCuentasbyIdPlataforma(int id)
        {
            return (await ObtenerUsuarioPlataformaCuentas(4, id.ToString()));
        }
        public async Task<List<UsuarioPlataformaCuenta>> GetUsuarioPlataformaCuentasbyIdCuenta(int id)
        {
            return (await ObtenerUsuarioPlataformaCuentas(5, id.ToString()));
        }
        public async Task<List<UsuarioPlataformaCuenta>> GetUsuarioPlataformaCuentasbyIdUsuarioIdPlataforma(string id)
        {
            return (await ObtenerUsuarioPlataformaCuentas(6, id));
        }
        public async Task<List<UsuarioPlataformaCuenta>> GetUsuarioPlataformaCuentasbyIdUsuarioIdCuenta(string id)
        {
            return (await ObtenerUsuarioPlataformaCuentas(7, id));
        }
        public async Task<List<UsuarioPlataformaCuenta>> GetUsuarioPlataformaCuentasbyIdPlataformaIdCuenta(string id)
        {
            return (await ObtenerUsuarioPlataformaCuentas(8, id));
        }
        public async Task<bool> UsuarioPlataformaCuentaExists(string idUsuarioPlataformaCuenta)
        {
            int idUsuario = int.Parse(idUsuarioPlataformaCuenta.Split("-")[0]);
            int idPlataforma = int.Parse(idUsuarioPlataformaCuenta.Split("-")[1]);
            int idCuenta = int.Parse(idUsuarioPlataformaCuenta.Split("-")[2]);
            return await _context.USUARIOPLATAFORMACUENTA.AnyAsync(e => e.idUsuario == idUsuario
                                                                && e.idPlataforma == idPlataforma
                                                                && e.idCuenta == idCuenta);
        }
        public async Task<List<UsuarioPlataformaCuenta>> ObtenerUsuarioPlataformaCuentas(int tipo, string dato)
        {
            List<UsuarioPlataformaCuenta> usuarioPlataformaCuentas = new List<UsuarioPlataformaCuenta>();
            string[] array;
            if (tipo == 1)
            {
                usuarioPlataformaCuentas = await (from upc in _context.USUARIOPLATAFORMACUENTA
                                                  orderby upc.idUsuario
                                                  select new UsuarioPlataformaCuenta()
                                                  {
                                                      idUsuarioPlataformaCuenta = upc.idUsuarioPlataformaCuenta,
                                                      idUsuario = upc.idUsuario,
                                                      idPlataforma = upc.idPlataforma,
                                                      idCuenta = upc.idCuenta,
                                                      cantidad = upc.cantidad
                                                  }).ToListAsync();
            }
            else if (tipo == 2)
            {
                array = dato.Split("-");
                usuarioPlataformaCuentas = await (from upc in _context.USUARIOPLATAFORMACUENTA
                                                  where upc.idUsuario == int.Parse(array[0])
                                                  && upc.idPlataforma == int.Parse(array[1])
                                                  && upc.idCuenta == int.Parse(array[2])
                                                  orderby upc.idUsuario
                                                  select new UsuarioPlataformaCuenta()
                                                  {
                                                      idUsuarioPlataformaCuenta = upc.idUsuarioPlataformaCuenta,
                                                      idUsuario = upc.idUsuario,
                                                      idPlataforma = upc.idPlataforma,
                                                      idCuenta = upc.idCuenta,
                                                      cantidad = upc.cantidad
                                                  }).ToListAsync();
            }
            else if (tipo == 3)
            {
                usuarioPlataformaCuentas = await (from upc in _context.USUARIOPLATAFORMACUENTA
                                                  where upc.idUsuario == int.Parse(dato)
                                                  orderby upc.idUsuario
                                                  select new UsuarioPlataformaCuenta()
                                                  {
                                                      idUsuarioPlataformaCuenta = upc.idUsuarioPlataformaCuenta,
                                                      idUsuario = upc.idUsuario,
                                                      idPlataforma = upc.idPlataforma,
                                                      idCuenta = upc.idCuenta,
                                                      cantidad = upc.cantidad
                                                  }).ToListAsync();
            }
            else if (tipo == 4)
            {
                usuarioPlataformaCuentas = await (from upc in _context.USUARIOPLATAFORMACUENTA
                                                  where upc.idPlataforma == int.Parse(dato)
                                                  orderby upc.idPlataforma
                                                  select new UsuarioPlataformaCuenta()
                                                  {
                                                      idUsuarioPlataformaCuenta = upc.idUsuarioPlataformaCuenta,
                                                      idUsuario = upc.idUsuario,
                                                      idPlataforma = upc.idPlataforma,
                                                      idCuenta = upc.idCuenta,
                                                      cantidad = upc.cantidad
                                                  }).ToListAsync();
            }
            else if (tipo == 5)
            {
                usuarioPlataformaCuentas = await (from upc in _context.USUARIOPLATAFORMACUENTA
                                                  where upc.idCuenta == int.Parse(dato)
                                                  orderby upc.idCuenta
                                                  select new UsuarioPlataformaCuenta()
                                                  {
                                                      idUsuarioPlataformaCuenta = upc.idUsuarioPlataformaCuenta,
                                                      idUsuario = upc.idUsuario,
                                                      idPlataforma = upc.idPlataforma,
                                                      idCuenta = upc.idCuenta,
                                                      cantidad = upc.cantidad
                                                  }).ToListAsync();
            }
            else if (tipo == 6)
            {
                array = dato.Split("-");
                usuarioPlataformaCuentas = await (from upc in _context.USUARIOPLATAFORMACUENTA
                                                  where upc.idUsuario == int.Parse(array[0])
                                                  && upc.idPlataforma == int.Parse(array[1])
                                                  orderby upc.idCuenta
                                                  select new UsuarioPlataformaCuenta()
                                                  {
                                                      idUsuarioPlataformaCuenta = upc.idUsuarioPlataformaCuenta,
                                                      idUsuario = upc.idUsuario,
                                                      idPlataforma = upc.idPlataforma,
                                                      idCuenta = upc.idCuenta,
                                                      cantidad = upc.cantidad
                                                  }).ToListAsync();
            }
            else if (tipo == 7)
            {
                array = dato.Split("-");
                usuarioPlataformaCuentas = await (from upc in _context.USUARIOPLATAFORMACUENTA
                                                  where upc.idUsuario == int.Parse(array[0])
                                                  && upc.idCuenta == int.Parse(array[1])
                                                  orderby upc.idCuenta
                                                  select new UsuarioPlataformaCuenta()
                                                  {
                                                      idUsuarioPlataformaCuenta = upc.idUsuarioPlataformaCuenta,
                                                      idUsuario = upc.idUsuario,
                                                      idPlataforma = upc.idPlataforma,
                                                      idCuenta = upc.idCuenta,
                                                      cantidad = upc.cantidad
                                                  }).ToListAsync();
            }
            else if (tipo == 8)
            {
                array = dato.Split("-");
                usuarioPlataformaCuentas = await (from upc in _context.USUARIOPLATAFORMACUENTA
                                                  where upc.idPlataforma == int.Parse(array[0])
                                                  && upc.idCuenta == int.Parse(array[1])
                                                  orderby upc.idCuenta
                                                  select new UsuarioPlataformaCuenta()
                                                  {
                                                      idUsuarioPlataformaCuenta = upc.idUsuarioPlataformaCuenta,
                                                      idUsuario = upc.idUsuario,
                                                      idPlataforma = upc.idPlataforma,
                                                      idCuenta = upc.idCuenta,
                                                      cantidad = upc.cantidad
                                                  }).ToListAsync();
            }
            return usuarioPlataformaCuentas;
        }
        #endregion
        #region Update
        public async Task<string> UpdateUsuarioPlataformaCuenta(UsuarioPlataformaCuentaDTO.Update_UPC usuarioPlataformaCuenta)
        {
            UsuarioPlataformaCuenta userPlatformAccount = await GetUsuarioPlataformaCuentabyIds(usuarioPlataformaCuenta.idUsuarioPlataformaCuenta);
            try
            {
                return await _commonRepository_UPC.UpdateObjeto(new UsuarioPlataformaCuenta()
                {
                    idUsuarioPlataformaCuenta = userPlatformAccount.idUsuarioPlataformaCuenta,
                    idUsuario = userPlatformAccount.idUsuario,
                    idPlataforma = userPlatformAccount.idPlataforma,
                    idCuenta = userPlatformAccount.idCuenta,
                    cantidad = usuarioPlataformaCuenta.cantidad
                }, _context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await _commonRepository_UPC.ExceptionMessage(new UsuarioPlataformaCuenta()
                {
                    idUsuarioPlataformaCuenta = userPlatformAccount.idUsuarioPlataformaCuenta,
                    idUsuario = userPlatformAccount.idUsuario,
                    idPlataforma = userPlatformAccount.idPlataforma,
                    idCuenta = userPlatformAccount.idCuenta,
                    cantidad = usuarioPlataformaCuenta.cantidad
                }, "U");
            }
        }
        #endregion
        #region Delete
        public async Task<string> DeleteUsuarioPlataformaCuenta(string id)
        {
            UsuarioPlataformaCuenta usuarioPlataformaCuenta = await GetUsuarioPlataformaCuentabyIds(id);
            try
            {
                return await _commonRepository_UPC.DeleteObjeto(usuarioPlataformaCuenta, _context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await _commonRepository_UPC.ExceptionMessage(usuarioPlataformaCuenta, "D");
            }
        }
        #endregion
    }
}
