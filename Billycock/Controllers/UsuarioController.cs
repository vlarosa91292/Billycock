using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Billycock.Data;
using Billycock.Models;
using Billycock.Repositories.Interfaces;
using Billycock.DTO;

namespace Billycock.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuarios()
        {
            return await _context.GetUsuarios();
        }

        // GET: api/Usuario/5
        [HttpPost("ViewUser")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario([FromBody] Usuario usuario)
        {
            var user= new UsuarioDTO();
            if (usuario.idUsuario != 0)
            {
                user = await _context.GetUsuariobyId(usuario.idUsuario);
            }
            else
            {
                user = await _context.GetUsuariobyName(usuario.descripcion);
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
        public async Task<ActionResult<string>> PutUsuario([FromBody] UsuarioDTO usuario)
        {
            if (usuario.idUsuario != usuario.idUsuario)
            {
                return BadRequest();
            }

            try
            {
                return await _context.UpdateUsuario(usuario);
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
            var user = await _context.GetUsuariobyId(usuario.idUsuario);
            if (user == null)
            {
                return NotFound();
            }

            return await _context.DeleteUsuario(usuario);
        }
    }
}
