using Billycock.DTO;
using Billycock.Models;
using Billycock.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlataformaCuentaController : ControllerBase
    {
        private readonly IPlataformaCuentaRepository _context;

        public PlataformaCuentaController(IPlataformaCuentaRepository context)
        {
            _context = context;
        }

        // GET: api/PlataformaCuenta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlataformaCuenta>>> GetPlataformaCuentas()
        {
            return await _context.GetPlataformaCuentas();
        }

        // GET: api/PlataformaCuenta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlataformaCuenta>> GetPlataformaCuenta(string id)
        {
            var PlataformaCuenta = await _context.GetPlataformaCuentabyIds(id);
            if (PlataformaCuenta == null)
            {
                return NotFound();
            }

            return PlataformaCuenta;
        }

        // PUT: api/PlataformaCuenta/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<string> PutPlataformaCuenta(PlataformaCuentaDTO.Update_PC _PlataformaCuenta)
        {
            if (await _context.PlataformaCuentaExists(_PlataformaCuenta.idPlataformaCuenta) == false)
            {
                return "PlataformaCuenta no encontrado";
            }


            return await _context.UpdatePlataformaCuenta(_PlataformaCuenta);
        }

        // POST: api/PlataformaCuenta
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<string> PostPlataformaCuenta(PlataformaCuentaDTO.Create_PC _PlataformaCuenta)
        {
            return await _context.CreatePlataformaCuenta(_PlataformaCuenta);
        }

        // DELETE: api/PlataformaCuenta/5
        [HttpDelete("{id}")]
        public async Task<string> DeletePlataformaCuenta(string id)
        {
            if (await _context.PlataformaCuentaExists(id) == false)
            {
                return "PlataformaCuenta no encontrado";
            }

            return await _context.DeletePlataformaCuenta(id);
        }
    }
}
