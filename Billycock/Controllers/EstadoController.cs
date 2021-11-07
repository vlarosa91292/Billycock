using Billycock.DTO;
using Billycock.Models;
using Billycock.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Billycock.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoRepository _context;

        public EstadoController(IEstadoRepository context)
        {
            _context = context;
        }

        // POST: api/Estado
        [HttpPost]
        public async Task<string> PostEstado(EstadoDTO.Create_E estado)
        {
            return await _context.CreateEstado(estado);
        }

        // GET: api/Estado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstado()
        {
            return await _context.GetEstados();
        }

        // GET: api/Estado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estado>> GetEstado(int id)
        {
            var estado = await _context.GetEstadobyId(id);

            if (estado == null)
            {
                return NotFound();
            }

            return estado;
        }

        // PUT: api/Estado
        [HttpPut]
        public async Task<string> PutEstado(Estado estado)
        {
            if (await _context.EstadoExists(estado.idEstado) == false)
            {
                return "Estado no encontrado";
            }


            return await _context.UpdateEstado(estado);
        }

        // DELETE: api/Estado/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteEstado(int id)
        {
            if (await _context.EstadoExists(id) == false)
            {
                return "Estado no encontrado";
            }

            return await _context.DeleteEstado(id);
        }
    }
}
