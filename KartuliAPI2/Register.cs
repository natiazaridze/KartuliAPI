using KartuliAPI2.Repositories.Interfaces;
using KartuliAPI2.Repositories.Repositories;
using KartuliAPI2.Services.Interfaces;
using KartuliAPI2.Services.Services;

namespace KartuliAPI2
{
    public static class Register
    {
        public static void Services(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWineService, WineService>();
            services.AddScoped<IRecipeService, RecipeService>();
        }

        public static void Repositories(this IServiceCollection services)
        {
            services.AddScoped<IWineRepository, WineRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
        }
    }
}
