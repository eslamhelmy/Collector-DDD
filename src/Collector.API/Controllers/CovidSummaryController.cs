
using Collector.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Collector.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CovidSummaryController : ControllerBase
    {
        private readonly ICovidSummaryService _covidSummaryService;

        public CovidSummaryController(ICovidSummaryService covidSummaryService)
        {
            _covidSummaryService = covidSummaryService;
        }

        [HttpGet("Get")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetSummary()
        {
                var result = await _covidSummaryService.GetSummaryAsync();
                return Ok(result);
        }
    }
}
