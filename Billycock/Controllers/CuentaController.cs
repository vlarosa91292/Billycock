using Billycock.DTO;
using Billycock.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Api_Billycock.Program;

namespace Billycock.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaRepository _context;

        public CuentaController(ICuentaRepository context
            )
        {
            _context = context;
        }

        // POST: api/Cuenta
        [HttpPost]
        public async Task<string> PostCuenta(CuentaDTO.Create_C Cuenta)
        {
            await _context.CreateCuenta(Cuenta);
            return Globales.mensaje;
        }

        // GET: api/Cuenta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CuentaDTO.Read_C>>> GetCuentas()
        {
            return await _context.GetCuentas(true);
        }

        //GET: api/Cuenta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CuentaDTO.Read_C>> GetCuenta(int id)
        {
            var Cuenta = await _context.GetCuentabyId(id, true);
            if (Cuenta == null)
            {
                return NotFound();
            }

            return Cuenta;
        }

        // PUT: api/Cuenta/5
        [HttpPut]
        public async Task<string> PutCuenta(CuentaDTO.Update_C Cuenta)
        {
            if (await _context.CuentaExists(Cuenta.idCuenta) == false)
            {
                return "Cuenta no encontrado";
            }
            else
            {
                await _context.UpdateCuenta(Cuenta);
            }

            return Globales.mensaje;
        }

        // PUT: ActivarDesactivarCuenta/5
        [HttpPut("{id}")]
        public async Task<string> ActivateDeactivateCuenta(CuentaDTO.Update_C Cuenta)
        {
            if (await _context.CuentaExists(Cuenta.idCuenta) == false)
            {
                return "Cuenta no encontrado";
            }
            else
            {
                await _context.DeactivateCuenta(Cuenta);
            }

            return Globales.mensaje;
        }

        // DELETE: api/Cuenta/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteCuenta(int id)
        {
            if (await _context.CuentaExists(id) == false)
            {
                return "Cuenta no encontrado";
            }
            else
            {
                await _context.DeleteCuenta(id);
            }

            return Globales.mensaje;
        }
    }
}
