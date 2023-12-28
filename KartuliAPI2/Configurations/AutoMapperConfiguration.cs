using AutoMapper;
using KartuliAPI2.Entities;
using KartuliAPI2.Models;
using System.Runtime.CompilerServices;

namespace KartuliAPI2.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton(GetMapper());
        }

        public static IMapper GetMapper()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<WineEntity, WineModel>();
                mc.CreateMap<RecipeEntity, RecipeModel>();

            });

            return mapperConfig.CreateMapper();
        }
    }
}
