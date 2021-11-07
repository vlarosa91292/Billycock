using Billycock.DTO;
using Billycock.Models;
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
    public class PlataformaController : ControllerBase
    {
        private readonly IPlataformaRepository _context;

        public PlataformaController(IPlataformaRepository context)
        {
            _context = context;
        }

        // POST: api/Plataforma
        [HttpPost]
        public async Task<string> PostPlataforma(PlataformaDTO.Create_P Plataforma)
        {
            await _context.CreatePlataforma(Plataforma);
            return Globales.mensaje;
        }

        // GET: api/Plataforma
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlataformaDTO.Read_P>>> GetPlataformas()
        {
            return await _context.GetPlataformas(true);
        }

        // GET: api/Plataforma/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlataformaDTO.Read_P>> GetPlataforma(int id)
        {
            var Plataforma = await _context.GetPlataformabyId(id, true);

            if (Plataforma == null)
            {
                return NotFound();
            }

            return Plataforma;
        }

        // PUT: api/Plataforma
        [HttpPut]
        public async Task<string> PutPlataforma(PlataformaDTO.Update_P Plataforma)
        {
            if (await _context.PlataformaExists(Plataforma.idPlataforma) == false)
            {
                return "Plataforma no encontrado";
            }

            await _context.UpdatePlataforma(Plataforma);
            return Globales.mensaje;
        }

        //PUT: api/Plataforma/5
        [HttpPut("{id}")]
        public async Task<string> ActivateDeactivatePlataforma(PlataformaDTO.Update_P Plataforma)
        {
            if (await _context.PlataformaExists(Plataforma.idPlataforma) == false)
            {
                return "Plataforma no encontrado";
            }

            await _context.DeactivatePlataforma(Plataforma);
            return Globales.mensaje;
        }

        // DELETE: api/Plataforma/5
        [HttpDelete("{id}")]
        public async Task<string> DeletePlataforma(int id)
        {
            if (await _context.PlataformaExists(id) == false)
            {
                return "Plataforma no encontrado";
            }
            else
            {
                await _context.DeletePlataforma(id);
            }

            return Globales.mensaje;
        }
    }
}
