using KartuliAPI2.Entities;
using KartuliAPI2.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace KartuliAPI2
{
    public class KartuliAPI2DbContext(DbContextOptions<KartuliAPI2DbContext> options, IHttpContextAccessor httpContextAccessor) : IdentityDbContext<
        UserEntity,
        RoleEntity,
        Guid>(options)
    {
        private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;

        #region tables
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<WineEntity> Wines { get; set; }
        public DbSet<RecipeEntity> Recipes { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(
                    Assembly.GetExecutingAssembly(),
                    t => t.GetInterfaces().Any(i =>
                i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));
        }
    }
}
