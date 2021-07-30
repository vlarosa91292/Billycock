using Billycock.Repositories.Interfaces;
using Billycock.Repositories.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billycock.Controllers
{
    [Route("/Bd")]
    [ApiController]
    public class BdController : ControllerBase
    {
        private readonly IBaseDatosConexion _context;

        public BdController(IBaseDatosConexion context)
        {
            _context = context;
        }

        // GET: api/BD
        [HttpGet("GetBd")]
        public BD GetUsuarios(string bd)
        {
            return _context.GetConnectionString(bd);
        }
    }
}
