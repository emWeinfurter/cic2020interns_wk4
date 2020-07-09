using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ibm.Br.Cic.Internship.Covid.Be.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace Ibm.Br.Cic.Internship.Covid.Be.Controllers
{    
    [ApiController]
    [Route("api/v2/c19api")]
    [Produces("application/json")]    
    public class Covid19ApiController : ControllerBase
    {
        //Task: Implement API
        private readonly ICovid19Api _covid;
        public Covid19ApiController(ICovid19Api covid)
        {
            this._covid = covid;
        }

        [HttpGet]
        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Get()
        {
            var result = await this._covid.GetData();
            return Ok(result);
        }
    }
}