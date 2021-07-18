using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Billycock.Models;
using Billycock.Repositories.Interfaces;
using Billycock.DTO;

namespace Api_Billycock.Controllers
{
    [Route("/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly  IUsuarioRepository _context;

        public UsuarioController(IUsuarioRepository context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet("ViewUsers")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.GetUsuarios("API");
        }

        // GET: api/Usuario/5
        [HttpPost("ViewUser")]
        public async Task<ActionResult<Usuario>> GetUsuario([FromBody] Usuario usuario)
        {
            var user = new Usuario();
            if (usuario.idUsuario != 0)
            {
                user = await _context.GetUsuariobyId(usuario.idUsuario, "API");
            }
            else
            {
                user = await _context.GetUsuariobyName(usuario.descripcion, "API");
            }

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Usuario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("UpdateUser")]
        public async Task<ActionResult<string>> PutUsuario([FromBody] Usuario usuario)
        {
            if (usuario.idUsuario != usuario.idUsuario)
            {
                return BadRequest();
            }

            try
            {
                return await _context.UpdateUsuario(usuario, "API");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.UsuarioExists(usuario.idUsuario))
                {
                    return NotFound();
                }
                else
                {
                    return NoContent();
                }
            }

        }

        // POST: api/Usuario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("AddUser")]
        public async Task<ActionResult<string>> PostUsuario([FromBody] UsuarioDTO usuario)
        {
            return await _context.InsertUsuario(usuario);
        }

        // DELETE: api/Usuario/5
        [HttpPost("DeleteUser")]
        public async Task<ActionResult<string>> DeleteUsuario([FromBody] Usuario usuario)
        {
            var user = await _context.GetUsuariobyId(usuario.idUsuario, "API");
            if (user == null)
            {
                return NotFound();
            }

            return await _context.DeleteUsuario(usuario, "API");
        }
    }
}
