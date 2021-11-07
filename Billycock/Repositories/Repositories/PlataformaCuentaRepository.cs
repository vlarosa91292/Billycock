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
    public class PlataformaCuentaRepository: IPlataformaCuentaRepository
    {
        private readonly BillycockServiceContext _context;
        private readonly ICommonRepository<PlataformaCuenta> _commonRepository_PC;

        public PlataformaCuentaRepository(BillycockServiceContext context
            ,ICommonRepository<PlataformaCuenta> Repository_PC
            )
        {
            _context = context;
            _commonRepository_PC = Repository_PC;
            Globales.mensaje = string.Empty;
        }
        #region Create
        public async Task<string> CreatePlataformaCuenta(PlataformaCuentaDTO.Create_PC plataformaCuenta)
        {
            try
            {
                return await _commonRepository_PC.InsertObjeto(new PlataformaCuenta()
                {
                    idPlataformaCuenta = plataformaCuenta.idPlataforma.ToString() + "-" + plataformaCuenta.idCuenta.ToString(),
                    idPlataforma = plataformaCuenta.idPlataforma,
                    idCuenta = plataformaCuenta.idCuenta,
                    fechaPago = _commonRepository_PC.SetearFecha(DateTime.Now.AddMonths(1)),
                    clave = "",
                    usuariosdisponibles = plataformaCuenta.usuariosdisponibles
                }, _context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await _commonRepository_PC.ExceptionMessage(new PlataformaCuenta()
                {
                    idPlataformaCuenta = plataformaCuenta.idPlataforma.ToString() + "-" + plataformaCuenta.idCuenta.ToString(),
                    idPlataforma = plataformaCuenta.idPlataforma,
                    idCuenta = plataformaCuenta.idCuenta,
                    fechaPago = _commonRepository_PC.SetearFecha(DateTime.Now.AddMonths(1)),
                    clave = "",
                    usuariosdisponibles = plataformaCuenta.usuariosdisponibles
                }, "C");
            }
        }
        #endregion
        #region Read
        public async Task<List<PlataformaCuenta>> GetPlataformaCuentas()
        {
            return await ObtenerPlataformaCuentas(1, null);
        }
        public async Task<PlataformaCuenta> GetPlataformaCuentabyIds(string id)
        {
            List<PlataformaCuenta> plataformaCuentas = await ObtenerPlataformaCuentas(2, id);
            if (plataformaCuentas.Count == 1) return plataformaCuentas[0];
            else return null;
        }
        public async Task<List<PlataformaCuenta>> GetPlataformaCuentasbyIdPlataforma(int id)
        {
            return (await ObtenerPlataformaCuentas(3, id.ToString()));
        }
        public async Task<List<PlataformaCuenta>> GetPlataformaCuentasbyIdCuenta(int id)
        {
            return (await ObtenerPlataformaCuentas(4, id.ToString()));
        }
        public async Task<bool> PlataformaCuentaExists(string idPlataformaCuenta)
        {
            int idPlataforma = int.Parse(idPlataformaCuenta.Split("-")[0]);
            int idCuenta = int.Parse(idPlataformaCuenta.Split("-")[1]);
            return await _context.PLATAFORMACUENTA.AnyAsync(e => e.idPlataforma == idPlataforma
                                                                && e.idCuenta == idCuenta);
        }
        public async Task<List<PlataformaCuenta>> ObtenerPlataformaCuentas(int tipo, string dato)
        {
            List<PlataformaCuenta> plataformaCuentas;
            string[] array;
            if (tipo == 1)
            {
                plataformaCuentas = await (from pc in _context.PLATAFORMACUENTA
                                           orderby pc.idCuenta
                                           select new PlataformaCuenta()
                                           {
                                               idPlataformaCuenta = pc.idPlataformaCuenta,
                                               idPlataforma = pc.idPlataforma,
                                               idCuenta = pc.idCuenta,
                                               clave = pc.clave,
                                               fechaPago = pc.fechaPago,
                                               usuariosdisponibles = pc.usuariosdisponibles
                                           }).ToListAsync();
            }
            else if (tipo == 2)
            {
                array = dato.Split("-");
                plataformaCuentas = await (from pc in _context.PLATAFORMACUENTA
                                           where pc.idPlataforma == int.Parse(array[0]) && pc.idCuenta == int.Parse(array[1])
                                           orderby pc.idCuenta
                                           select new PlataformaCuenta()
                                           {
                                               idPlataformaCuenta = pc.idPlataformaCuenta,
                                               idPlataforma = pc.idPlataforma,
                                               idCuenta = pc.idCuenta,
                                               clave = pc.clave,
                                               fechaPago = pc.fechaPago,
                                               usuariosdisponibles = pc.usuariosdisponibles
                                           }).ToListAsync();
            }
            else if (tipo == 3)
            {
                plataformaCuentas = await (from pc in _context.PLATAFORMACUENTA
                                           where pc.idPlataforma == int.Parse(dato)
                                           orderby pc.idCuenta
                                           select new PlataformaCuenta()
                                           {
                                               idPlataformaCuenta = pc.idPlataformaCuenta,
                                               idPlataforma = pc.idPlataforma,
                                               idCuenta = pc.idCuenta,
                                               clave = pc.clave,
                                               fechaPago = pc.fechaPago,
                                               usuariosdisponibles = pc.usuariosdisponibles
                                           }).ToListAsync();
            }
            else
            {
                plataformaCuentas = await (from pc in _context.PLATAFORMACUENTA
                                           where pc.idCuenta == int.Parse(dato)
                                           orderby pc.idCuenta
                                           select new PlataformaCuenta()
                                           {
                                               idPlataformaCuenta = pc.idPlataformaCuenta,
                                               idPlataforma = pc.idPlataforma,
                                               idCuenta = pc.idCuenta,
                                               clave = pc.clave,
                                               fechaPago = pc.fechaPago,
                                               usuariosdisponibles = pc.usuariosdisponibles
                                           }).ToListAsync();
            }
            return plataformaCuentas;
        }
        #endregion
        #region Update
        public async Task<string> UpdatePlataformaCuenta(PlataformaCuentaDTO.Update_PC plataformaCuenta)
        {
            PlataformaCuenta platformAccount = await GetPlataformaCuentabyIds(plataformaCuenta.idPlataformaCuenta);
            try
            {
                return await _commonRepository_PC.UpdateObjeto(new PlataformaCuenta()
                {
                    idPlataformaCuenta = platformAccount.idPlataformaCuenta,
                    idCuenta = platformAccount.idCuenta,
                    idPlataforma = platformAccount.idPlataforma,
                    fechaPago = platformAccount.fechaPago == plataformaCuenta.fechaPago ? platformAccount.fechaPago : plataformaCuenta.fechaPago,
                    usuariosdisponibles = plataformaCuenta.usuariosdisponibles != platformAccount.usuariosdisponibles ? plataformaCuenta.usuariosdisponibles : platformAccount.usuariosdisponibles,
                    clave = plataformaCuenta.clave != platformAccount.clave ? plataformaCuenta.clave : platformAccount.clave
                }, _context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await _commonRepository_PC.ExceptionMessage(new PlataformaCuenta()
                {
                    idPlataformaCuenta = platformAccount.idPlataformaCuenta,
                    idCuenta = platformAccount.idCuenta,
                    idPlataforma = platformAccount.idPlataforma,
                    fechaPago = platformAccount.fechaPago == plataformaCuenta.fechaPago ? platformAccount.fechaPago : plataformaCuenta.fechaPago,
                    usuariosdisponibles = plataformaCuenta.usuariosdisponibles != platformAccount.usuariosdisponibles ? plataformaCuenta.usuariosdisponibles : platformAccount.usuariosdisponibles,
                    clave = plataformaCuenta.clave != platformAccount.clave ? plataformaCuenta.clave : platformAccount.clave
                }, "U");
            }
        }
        #endregion
        #region Delete
        public async Task<string> DeletePlataformaCuenta(string id)
        {         
            PlataformaCuenta platformAccount = await GetPlataformaCuentabyIds(id);
            try
            {
                return await _commonRepository_PC.DeleteObjeto(platformAccount, _context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await _commonRepository_PC.ExceptionMessage(platformAccount, "D");
            }
        }
        #endregion
        #region Extras
        public async Task<PlataformaCuenta> GetPlataformaCuentaDisponible(int idPlataforma, int cantidad)
        {
            return await (from pc in _context.PLATAFORMACUENTA
                          join c in _context.CUENTA on pc.idCuenta equals c.idCuenta
                          where pc.idPlataforma == idPlataforma && pc.usuariosdisponibles >= cantidad && c.idEstado != 2
                          select new PlataformaCuenta()
                          {
                              idPlataformaCuenta = pc.idPlataformaCuenta,
                              idCuenta = pc.idCuenta,
                              idPlataforma = pc.idPlataforma,
                              usuariosdisponibles = pc.usuariosdisponibles,
                              fechaPago = pc.fechaPago,
                              clave = pc.clave
                          }).FirstOrDefaultAsync();
        }
        #endregion
    }
}
