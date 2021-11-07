using Billycock.Data;
using Billycock.DTO;
using Billycock.Models;
using Billycock.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Api_Billycock.Program;

namespace Billycock.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _context;

        public UsuarioController(IUsuarioRepository context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO.Read_U>>> GetUsuarios()
        {
            return await _context.GetUsuarios(true);
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO.Read_U>> GetUsuario(int id)
        {
            var usuario = await _context.GetUsuariobyId(id, true);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<string> PutUsuario(UsuarioDTO.Update_U usuario)
        {
            if (await _context.UsuarioExists(usuario.idUsuario) == false)
            {
                return "Usuario no encontrado";
            }


            await _context.UpdateUsuario(usuario);
            return Globales.mensaje;
        }

        // POST: api/Usuario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<string> PostUsuario(UsuarioDTO.Create_U usuario)
        {
            await _context.CreateUsuario(usuario);
            return Globales.mensaje;
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteUsuario(int id)
        {
            var usuario = await _context.GetUsuariobyId(id, false);
            if (usuario == null)
            {
                return "Usuario no encontrado";
            }

            await _context.DeleteUsuario(usuario);
            return Globales.mensaje;
        }

        // PATCH: api/Usuario/5
        [HttpPut("{id}")]
        public async Task<string> DeactivateUsuario(int id)
        {
            var usuario = await _context.GetUsuariobyId(id, false);
            if (usuario == null)
            {
                return "Usuario no encontrado";
            }

            await _context.DeactivateUsuario(usuario);
            return Globales.mensaje;
        }
    }
}
