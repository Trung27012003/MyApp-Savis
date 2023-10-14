using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Api.IServices;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _userAuthentication;
        public AuthenticationController(IAuthenticationService userAuthentication)
        {
            _userAuthentication = userAuthentication;
        }
        [HttpPost("login")]

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _userAuthentication.Login(model);
            return Ok(result.Token);
        }
        [HttpGet("logout")]

        public async Task<IActionResult> LogOut()
        {
            var result = _userAuthentication.Logout();
            return Ok(result);
        }
        [HttpPost("register")]

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var result = await _userAuthentication.Register(model);
            return Ok(result);
        }

    }
}
