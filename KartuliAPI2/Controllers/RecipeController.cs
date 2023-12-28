using KartuliAPI2.Constants;
using KartuliAPI2.Models;
using KartuliAPI2.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KartuliAPI2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController(IRecipeService recipeService) : ControllerBase
    {

        private readonly IRecipeService _recipeService = recipeService;

        [HttpGet("recipes")]
        [Authorize(Policy = RoleConstants.User)]
        public async Task<List<RecipeModel>> GetAll() => await _recipeService.GetRecipes();


        [HttpGet("recipe/{id}")]
        [Authorize(Policy = RoleConstants.User)]
        public async Task<RecipeModel> Get([FromRoute]Guid id) => await _recipeService.GetRecipeById(id);

        [HttpPost("create")]
        [Authorize(Policy = RoleConstants.User)]
        public async Task<RecipeModel> Create([FromBody]RecipeModel recipemodel) => await _recipeService.Create(recipemodel);

        [HttpPut("update")]
        [Authorize(Policy = RoleConstants.User)]
        public async Task<RecipeModel> Update([FromBody] RecipeModel recipemodel) => await _recipeService.Update(recipemodel);

        [HttpDelete("delete/{id}")]
        [Authorize(Policy = RoleConstants.User)]
        public async Task Delete([FromRoute] Guid id) => await _recipeService.Delete(id);


    }
} 
