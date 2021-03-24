using Microsoft.AspNetCore.Mvc;
using prematix.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prematix.Web.Controllers.API
{
    [Route("api/[Controller]")]

    public class PediatrasController : Controller
    {
        private readonly IPediatraRepository pediatraRepository;

        public PediatrasController(IPediatraRepository pediatraRepository)
        {
            this.pediatraRepository = pediatraRepository;
        }

        [HttpGet]
        public IActionResult GetPediatras()
        {

            return Ok(this.pediatraRepository.GetAll());
        }
    }
}
