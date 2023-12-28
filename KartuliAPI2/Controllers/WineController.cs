using KartuliAPI2.Constants;
using KartuliAPI2.Models;
using KartuliAPI2.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KartuliAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineController(IWineService wineService) : ControllerBase
    {
        private readonly IWineService _wineService = wineService;

        [HttpGet("wines")]
        [Authorize(Policy = RoleConstants.User)]
        public async Task<List<WineModel>> GetAll() => await _wineService.GetWines();

        [HttpGet("wine/{id}")]
        [Authorize(Policy = RoleConstants.User)]
        public async Task<WineModel> Get([FromRoute]Guid id) => await _wineService.GetWineById(id);

        [HttpPost("create")]
        [Authorize(Policy = RoleConstants.Admin)]
        public async Task<WineModel> Create([FromBody] WineModel wineModel) => await _wineService.Create(wineModel);



        [HttpPut("update")]
        [Authorize(Policy = RoleConstants.Admin)]
        public async Task<WineModel> Update([FromBody] WineModel wineModel) => await _wineService.Update(wineModel);

        [HttpDelete("delete/{id}")]
        [Authorize(Policy = RoleConstants.Admin)]
        public async Task Delete([FromRoute] Guid id) => await _wineService.Delete(id);
    }
}
