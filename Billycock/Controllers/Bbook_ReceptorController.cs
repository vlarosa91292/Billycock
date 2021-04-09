using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegracionBbook.Api.Models.In_Codes;
using IntegracionBbook.Api.Models.Utils;
using IntegracionBbook.Models;
using IntegracionBbook.Models.Hierarchy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Billycock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Bbook_ReceptorController : ControllerBase
    {
        [HttpGet("XD")]
        public ActionResult<ResponseBbookDTO> Get()
        {
            return new ResponseBbookDTO()
            {
                status = "OK",
                statusCode = 200,
                message = "OK",
                internalCode = "00"
            };
        }

        // GET api/values
        [HttpPost("stores")]
        public ActionResult<ResponseBbookDTO> PostStore([FromBody] DTO<Store>.Request objecto)
        {
            Response.StatusCode = 200;
            return ResponseOK();
        }

        // GET api/values
        [HttpPost("brands")]
        public ActionResult<ResponseBbookDTO> PostBrand([FromBody] DTO<Brand>.Request objecto)
        {
            Response.StatusCode = 200;
            return ResponseOK();
        }

        // GET api/values
        [HttpPost("vendors")]
        public ActionResult<ResponseBbookDTO> PostVendor([FromBody] DTO<Vendor>.Request objecto)
        {
            Response.StatusCode = 200;
            return ResponseOK();
        }

        // GET api/values
        [HttpPost("seasons")]
        public ActionResult<ResponseBbookDTO> PostSeason([FromBody] DTO<Season>.Request objecto)
        {
            Response.StatusCode = 200;
            return ResponseOK();
        }

        // GET api/values
        [HttpPost("dimensions")]
        public ActionResult<ResponseBbookDTO> PostDimension([FromBody] DTO<Dimension>.Request objecto)
        {
            Response.StatusCode = 200;
            return ResponseOK();
        }

        // GET api/values
        [HttpPost("sizes")]
        public ActionResult<ResponseBbookDTO> PostSize([FromBody] DTO<Size>.Request objecto)
        {
            Response.StatusCode = 200;
            return ResponseOK();
        }

        // GET api/values
        [HttpPost("buyers")]
        public ActionResult<ResponseBbookDTO> PostBuyer([FromBody] DTO<Buyer>.Request objecto)
        {
            Response.StatusCode = 200;
            return ResponseOK();
        }

        // GET api/values
        [HttpPost("hierarchies")]
        public ActionResult<ResponseBbookDTO> PostHierarchy([FromBody] DTO<Hierarchy>.Request objecto)
        {
            Response.StatusCode = 200;
            return ResponseOK();
        }

        // GET api/values
        [HttpPost("comex")]
        public ActionResult<ResponseBbookDTO> PostComex([FromBody] DTO<Comex>.Request objecto)
        {
            Response.StatusCode = 200;
            return ResponseOK();
        }

        // GET api/values
        [HttpPost("products")]
        public ActionResult<ResponseBbookDTO> PostProduct([FromBody] DTO<Product>.Request objecto)
        {
            Response.StatusCode = 200;
            return ResponseOK();
        }

        // GET api/values
        [HttpPost("master-po")]
        public ActionResult<ResponseBbookDTO> PostMaster_po([FromBody] DTO<Master_po>.Request objecto)
        {
            Response.StatusCode = 200;
            return ResponseOK();
        }

        // GET api/values
        [HttpPost("receiving_products")]
        public ActionResult<ResponseBbookDTO> Postreceiving_products([FromBody] DTO<Received_product>.Request objecto)
        {
            Response.StatusCode = 200;
            return ResponseOK();
        }

        // GET api/values
        [HttpPost("in-codes")]
        public ActionResult<ResponseBbookDTO> Postin_codes([FromBody] DTOUnitario<Out_Codes>.Request objecto)
        {
            Response.StatusCode = 200;
            return ResponseOK();
        }

        public ResponseBbookDTO ResponseOK()
        {
            return new ResponseBbookDTO()
            {
                status = "OK",
                statusCode = 200,
                message = "OK",
                internalCode = "00"
            };
        }
    }
}
