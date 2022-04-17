
using Collector.Domain.Services;
using Collector.Domain.ViewModels;
using Collector.Infrastructure.Services;
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
    public class CovidHistoryController : ControllerBase
    {
        private readonly ICovidHistoryService _covidistoryService;

        public CovidHistoryController(ICovidHistoryService covidistoryService)
        {
            _covidistoryService = covidistoryService;
        }

        [HttpGet("GetCovidHistory")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetUAECovidHistory(int pageIndex = 1, int pageSize = 20)
        {
                var result = await _covidistoryService.GetCovidHistoryAsync(pageIndex, pageSize);
                return Ok(result);
           }

        [HttpPost("Add")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Add(CovidHistoryCreateViewModel viewModel)
        {
                var result = await _covidistoryService.AddAsync(viewModel);
                return Ok(result);
        }

        [HttpPut("Edit")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Edit(CovidHistoryEditViewModel viewModel)
        {
                var result = await _covidistoryService.UpdateAsync(viewModel);
                return Ok(result);
        }

        [HttpDelete("Delete")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(int id)
        {
                var result = await _covidistoryService.DeleteAsync(id);
                return Ok(result);
        }



    }
}
