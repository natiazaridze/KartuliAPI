using KartuliAPI2.Constants;
using KartuliAPI2.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KartuliAPI2.Configurations
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using IServiceScope serviceScope = serviceProvider.CreateScope();

            KartuliAPI2DbContext context = serviceScope.ServiceProvider.GetService<KartuliAPI2DbContext>();
            UserManager<UserEntity> userManager = serviceScope.ServiceProvider.GetService<UserManager<UserEntity>>();
            RoleManager<RoleEntity> roleManager = serviceScope.ServiceProvider.GetService<RoleManager<RoleEntity>>();

            context.Database.EnsureCreated();

            try
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            string adminEmail = "admin@admin.com";
            string adminPassword = "@dm1nPass";
            var adminUser = userManager.Users.FirstOrDefaultAsync(x => x.Email == adminEmail).Result;

            if (adminUser == null)
            {
                var adminUserId = Guid.NewGuid();
                adminUser = new UserEntity
                {
                    Id = adminUserId,
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    FirstName = "Admin",
                    LastName = "Admin",
                };

                var createUser = userManager.CreateAsync(adminUser, adminPassword).Result;

                if (!createUser.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, createUser.Errors.Select(x => x.Description)));
                }
            }

            //initialize roles
            var adminRole = context.Set<RoleEntity>().FirstOrDefault(x => x.Name == RoleConstants.Admin);

            if (adminRole == null)
            {
                adminRole = new RoleEntity()
                {
                    Name = RoleConstants.Admin,
                };

                var createRole = roleManager.CreateAsync(adminRole).Result;

                if (!createRole.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, createRole.Errors.Select(x => x.Description)));
                }
            }

            var userRole = context.Set<RoleEntity>().FirstOrDefault(x => x.Name == RoleConstants.User);

            if (userRole == null)
            {
                userRole = new RoleEntity()
                {
                    Name = RoleConstants.User,
                };

                var createRole = roleManager.CreateAsync(userRole).Result;

                if (!createRole.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, createRole.Errors.Select(x => x.Description)));
                }
            }

            //assign admin role to admin user
            var isadminUserInadminRole = userManager.IsInRoleAsync(adminUser, adminRole.Name).Result;

            if (!isadminUserInadminRole)
            {
                var addUserToRole = userManager.AddToRoleAsync(adminUser, adminRole.Name).Result;

                if (!addUserToRole.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, addUserToRole.Errors.Select(x => x.Description)));
                }
            }
        }
    }
}
