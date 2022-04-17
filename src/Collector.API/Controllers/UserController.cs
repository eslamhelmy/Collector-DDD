using Collector.Domain.Services;
using Collector.Mappers.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Collector.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel viewModel)
        {
            var result = await _userService.Login(viewModel);
            return Ok(result);
        }

    }
}
