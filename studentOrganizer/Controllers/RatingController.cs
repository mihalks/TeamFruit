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
    public class RatingController : ControllerBase
    {
        [HttpGet]
        public List<RatingSubject> Get([FromQuery] string studnumber, string paspnumber)
        {
            return Rating.GetRating(studnumber, paspnumber);
        }
    }
}