using AutoMapper;
using KartuliAPI2.Entities;
using KartuliAPI2.Models;
using KartuliAPI2.Repositories.Interfaces;
using KartuliAPI2.Services.Interfaces;
using System.Formats.Asn1;

namespace KartuliAPI2.Services.Services
{
    public class RecipeService(IRecipeRepository recipeRepository, IMapper mapper) : IRecipeService
    {

        private readonly IRecipeRepository _recipeRepository = recipeRepository;   
        private readonly IMapper _mapper = mapper;
        public async Task<RecipeModel> Create(RecipeModel model)
        {

            var recipe = new RecipeEntity
            {
                Name = model.Name,
                RecipeDescription = model.RecipeDescription,
                CreatedAt = DateTime.UtcNow,
            };


            await _recipeRepository.AddAsync(recipe);
            await _recipeRepository.SaveAsync();
            return _mapper.Map<RecipeModel>(recipe);    
        }

        public async Task Delete(Guid id)
        {
            var recipe = await _recipeRepository.GetAsync(id);
            if (recipe != null)
            {
                _recipeRepository.Delete(recipe);
                await _recipeRepository.SaveAsync();
            }
            else
            {
                throw new Exception($"Recipe with id {id} does not exist");
            }
        }

        public async Task<RecipeModel> GetRecipeById(Guid id)
        {

            var recipe = await _recipeRepository.GetAsync(id);
            if (recipe != null)
            {
                return _mapper.Map<RecipeModel>(recipe);
            }

            throw new Exception($"Recipe with id {id} does not exist");
        }


        public async Task <List<RecipeModel>> GetRecipes()
        {
            var recipe = await _recipeRepository.GetAllAsync();
            return _mapper.Map<List<RecipeModel>>(recipe);
        }
        public async Task<RecipeModel> Update(RecipeModel model)
        {
            var recipe = await _recipeRepository.GetAsync(model.Id);
                if (recipe != null)
                {
                recipe.Name = model.Name;
                recipe.RecipeDescription = model.RecipeDescription;

                _recipeRepository.Update(recipe);
                await _recipeRepository.SaveAsync();

                return _mapper.Map<RecipeModel>(recipe);
            }

            throw new Exception($"Recipe with id {model.Id} does not exist");

        }
    }
}
