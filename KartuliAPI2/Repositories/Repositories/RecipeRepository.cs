using KartuliAPI2.Entities;
using KartuliAPI2.Repositories.Interfaces;

namespace KartuliAPI2.Repositories.Repositories
{
    public class RecipeRepository(KartuliAPI2DbContext context) : GenericRepository<RecipeEntity>(context), IRecipeRepository
    {
    }
}
