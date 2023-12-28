using KartuliAPI2.Models.Identity;
using KartuliAPI2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KartuliAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        [HttpPost("signup")]
        public async Task<string> Register([FromBody]SignupModel userModel) => await _userService.Signup(userModel);

        [HttpPost("login")]
        public async Task<string> Login([FromBody]LoginModel userModel) => await _userService.Login(userModel);
    }
}
