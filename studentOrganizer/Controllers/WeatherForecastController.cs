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
    public class chatController : ControllerBase
    {
    [HttpGet]
        public string Get(string gr)
        {
            System.Console.WriteLine($"AAAAAAAAAAAAAAAAA {gr} ");
      //    Parser.Pars();
            return "Спасибо";
        }
    }
}
