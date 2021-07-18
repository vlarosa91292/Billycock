using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billycock.Models;
using Billycock.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Billycock.Controllers
{
    [Route("/Cuenta")]
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
        public async Task<ActionResult<IEnumerable<Cuenta>>> GetCuentas()
        {
            return await _context.GetCuentas();
        }

        // GET: api/Cuenta/5
        [HttpPost("ViewAccount")]
        public async Task<ActionResult<Cuenta>> GetCuenta([FromBody] Cuenta cuenta)
        {
            Cuenta account=null;
            if (cuenta.idCuenta != 0)
            {
                account = await _context.GetCuentabyId(cuenta.idCuenta);
            }

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        // PUT: api/Cuenta
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("UpdateAccount")]
        public async Task<ActionResult<string>> PutCuenta([FromBody] Cuenta cuenta)
        {
            if (cuenta.idCuenta != cuenta.idCuenta)
            {
                return BadRequest();
            }

            try
            {
                return await _context.UpdateCuenta(cuenta);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.CuentaExists(cuenta.idCuenta,null))
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
        public async Task<ActionResult<string>> PostCuenta([FromBody] Cuenta cuenta)
        {
            return await _context.InsertCuenta(cuenta);
        }

        // DELETE: api/Cuenta/5
        [HttpPost("DeleteAccount")]
        public async Task<ActionResult<string>> DeleteCuenta([FromBody] Cuenta cuenta)
        {
            return await _context.DeleteCuenta(cuenta);
        }
    }
}
