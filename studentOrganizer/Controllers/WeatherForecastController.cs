using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace studentOrganizer.Controllers
{
    // [ApiController]
    // [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
       [HttpPost]
public string Buy()
{
    System.Console.WriteLine($"AAAAAAAAAAAAAAAAA  ");
       Parser.GetGroupID("3/42");
                 Parser.GetSchedule("3%2F42");
    return "Спасибо";
}
    }
}
