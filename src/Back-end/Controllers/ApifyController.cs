using Ibm.Br.Cic.Internship.Covid.Be.Models;
using Ibm.Br.Cic.Internship.Covid.Be.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ibm.Br.Cic.Internship.Covid.Be.Controllers
{
    [ApiController]
    [Route("api/v1/c19api")]
    [Produces("application/json")]
    public class ApifyController : Controller
    {
        private readonly IApify _apify;
        public ApifyController(IApify apify)
        {
            this._apify = apify;
        }

        [HttpGet]
        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Get()
        {
            var result = await this._apify.GetDataAsync();
            return Ok(result);
        }
    }
}