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
    public class WeatherForecastController : ControllerBase
    {
    [HttpGet]
        public string Get()
        {
            System.Console.WriteLine($"AAAAAAAAAAAAAAAAA  ");
          Parser.Pars();
            return "Спасибо";
        }
    }
}
