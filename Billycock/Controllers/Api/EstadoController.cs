using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billycock.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Billycock.Repositories.Interfaces;

namespace Api_Billycock.Controllers
{
    [Route("/Estado")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoRepository _context;

        public EstadoController(IEstadoRepository context)
        {
            _context = context;
        }

        // GET: api/Estado
        [HttpGet("ViewStates")]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstados()
        {
            return await _context.GetEstados();
        }

        // GET: api/Estado/5
        [HttpPost("ViewState")]
        public async Task<ActionResult<Estado>> GetEstado([FromBody] Estado estado)
        {
            var user = new Estado();
            if (estado.idEstado != 0)
            {
                user = await _context.GetEstadobyId(estado.idEstado);
            }
            else
            {
                user = await _context.GetEstadobyName(estado.descripcion);
            }

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Estado
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("UpdateState")]
        public async Task<ActionResult<string>> PutEstado([FromBody] Estado estado)
        {
            if (estado.idEstado != estado.idEstado)
            {
                return BadRequest();
            }

            try
            {
                return await _context.UpdateEstado(estado);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.EstadoExists(estado.idEstado))
                {
                    return NotFound();
                }
                else
                {
                    return NoContent();
                }
            }

        }

        // POST: api/Estado
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("AddState")]
        public async Task<ActionResult<string>> PostEstado([FromBody] Estado estado)
        {
            return await _context.InsertEstado(estado);
        }

        // DELETE: api/Estado/5
        [HttpPost("DeleteState")]
        public async Task<ActionResult<string>> DeleteEstado([FromBody] Estado estado)
        {
            var user = await _context.GetEstadobyId(estado.idEstado);
            if (user == null)
            {
                return NotFound();
            }

            return await _context.DeleteEstado(estado);
        }
    }
}
