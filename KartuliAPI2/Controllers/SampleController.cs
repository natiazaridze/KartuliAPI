using KartuliAPI2.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KartuliAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        [HttpGet("test")]
        [Authorize(Policy = RoleConstants.Admin)]
        public IActionResult SomeData() => Ok("asd");
    }
}
