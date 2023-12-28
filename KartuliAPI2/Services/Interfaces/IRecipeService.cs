using KartuliAPI2.Models;

namespace KartuliAPI2.Services.Interfaces
{
    public interface IRecipeService
    {


        Task<RecipeModel> GetRecipeById(Guid id);
        Task<List<RecipeModel>> GetRecipes();
        Task<RecipeModel> Create(RecipeModel model);
        Task<RecipeModel> Update(RecipeModel model);
        Task Delete(Guid id);

    }
}
