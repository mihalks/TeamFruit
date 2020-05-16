using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace studentOrganizer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RaspController : ControllerBase
    {
    [HttpGet]
        public IActionResult Get([FromQuery] string gr)
        {
            System.Console.WriteLine($"AAAAAAAAAAAAAAAAA {gr} ");
          Parser.Pars();
            //return  Ok("Spasibo");
            return Content("{\"firstName\": \"John\"}");
        }


    }
}
