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
    public class EstadoRepository: IEstadoRepository
    {
        private readonly ICommonRepository<Estado> _commonRepository_E;
        private readonly BillycockServiceContext _context;
        public EstadoRepository(BillycockServiceContext context, ICommonRepository<Estado> commonRepository_E)
        {
            _context = context;
            _commonRepository_E = commonRepository_E;
            Globales.mensaje = string.Empty;
        }
        #region Create
        public async Task<string> CreateEstado(EstadoDTO.Create_E estado)
        {
            try
            {
                return await _commonRepository_E.InsertObjeto(new Estado()
                {
                    descripcion = estado.descripcion
                }, _context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await _commonRepository_E.ExceptionMessage(new Estado()
                {
                    descripcion = estado.descripcion
                }, "C");
            }
        }
        #endregion
        #region Read
        public async Task<List<Estado>> GetEstados()
        {
            return await ObtenerEstados(1, null);
        }
        public async Task<Estado> GetEstadobyId(int? id)
        {
            List<Estado> estados = await ObtenerEstados(2, id.ToString());
            if (estados.Count == 1) return estados[0];
            else return null;
        }
        public async Task<Estado> GetEstadobyName(string name)
        {
            List<Estado> estados = await ObtenerEstados(3, name);
            if (estados.Count == 1) return estados[0];
            else return null;
        }
        public async Task<bool> EstadoExists(int id)
        {
            return await _context.ESTADO.AnyAsync(e => e.idEstado == id);
        }
        public async Task<List<Estado>> ObtenerEstados(int tipo, string dato)
        {
            if (tipo == 1)
            {
                return await (from e in _context.ESTADO
                              select new Estado()
                              {
                                  idEstado = e.idEstado,
                                  descripcion = e.descripcion
                              }).ToListAsync();
            }
            else if (tipo == 2)
            {
                return await (from e in _context.ESTADO
                              where e.idEstado == int.Parse(dato)
                              orderby e.idEstado
                              select new Estado()
                              {
                                  idEstado = e.idEstado,
                                  descripcion = e.descripcion
                              }).ToListAsync();
            }
            else
            {
                return await (from e in _context.ESTADO
                              where e.descripcion == dato
                              orderby e.idEstado
                              select new Estado()
                              {
                                  idEstado = e.idEstado,
                                  descripcion = e.descripcion
                              }).ToListAsync();
            }
        }
        #endregion
        #region Update
        public async Task<string> UpdateEstado(Estado estado)
        {
            Estado account = await GetEstadobyId(estado.idEstado);
            try
            {
                return await _commonRepository_E.UpdateObjeto(new Estado()
                {
                    idEstado = account.idEstado,
                    descripcion = estado.descripcion
                }, _context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await _commonRepository_E.ExceptionMessage(new Estado()
                {
                    idEstado = account.idEstado,
                    descripcion = estado.descripcion
                }, "U");
            }
        }
        #endregion
        #region Delete
        public async Task<string> DeleteEstado(int id)
        {
            Estado estado = await GetEstadobyId(id);
            try
            {
                return await _commonRepository_E.DeleteObjeto(estado, _context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await _commonRepository_E.ExceptionMessage(estado, "D");
            }
        }
        #endregion
    }
}
