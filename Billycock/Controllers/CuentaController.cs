using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billycock.DTO;
using Billycock.Models;
using Billycock.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Billycock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaRepository _context;

        public CuentaController(ICuentaRepository context)
        {
            _context = context;
        }

        // GET: api/Cuenta
        [HttpGet("ViewAccounts")]
        public async Task<ActionResult<IEnumerable<CuentaDTO>>> GetCuentas()
        {
            return await _context.GetCuentas();
        }

        // GET: api/Cuenta/5
        [HttpPost("ViewAccount")]
        public async Task<ActionResult<CuentaDTO>> GetCuenta([FromBody] CuentaDTO usuario)
        {
            var user = new CuentaDTO();
            if (usuario.idCuenta != 0)
            {
                user = await _context.GetCuentabyId(usuario.idCuenta);
            }
            else
            {
                user = await _context.GetCuentabyName(usuario.descripcion);
            }

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Cuenta
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("UpdateAccount")]
        public async Task<ActionResult<string>> PutCuenta([FromBody] Cuenta usuario)
        {
            if (usuario.idCuenta != usuario.idCuenta)
            {
                return BadRequest();
            }

            try
            {
                return await _context.UpdateCuenta(usuario);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.CuentaExists(usuario.idCuenta))
                {
                    return NotFound();
                }
                else
                {
                    return NoContent();
                }
            }

        }

        // POST: api/Cuenta
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("AddAccount")]
        public async Task<ActionResult<string>> PostCuenta([FromBody] Cuenta usuario)
        {
            return await _context.InsertCuenta(usuario);
        }

        // DELETE: api/Cuenta/5
        [HttpPost("DeleteAccount")]
        public async Task<ActionResult<string>> DeleteCuenta([FromBody] Cuenta usuario)
        {
            var user = await _context.GetCuentabyId(usuario.idCuenta);
            if (user == null)
            {
                return NotFound();
            }

            return await _context.DeleteCuenta(usuario);
        }
    }
}
