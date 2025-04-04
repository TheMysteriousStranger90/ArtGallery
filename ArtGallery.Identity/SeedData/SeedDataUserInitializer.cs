using ArtGallery.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ArtGallery.Identity.SeedData
{
    public static class SeedDataUserInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            try
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();

                await SeedRolesAsync(roleManager);
                await SeedUsersAsync(userManager);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static async Task SeedRolesAsync(RoleManager<AppRole> roleManager)
        {
            string[] roleNames = { "Administrator", "Moderator", "User" };

            foreach (var roleName in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);

                if (!roleExists)
                {
                    await roleManager.CreateAsync(new AppRole { Name = roleName });
                }
            }
        }

        private static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager)
        {
            var users = new List<(ApplicationUser User, string Password, string Role)>
            {
                // Admin user
                (
                    new ApplicationUser
                    {
                        UserName = "admin@artgallery.com",
                        Email = "admin@artgallery.com",
                        FirstName = "System",
                        LastName = "Administrator",
                        EmailConfirmed = true,
                        Created = DateTime.UtcNow
                    },
                    "Admin@123!",
                    "Administrator"
                ),

                // Moderator user
                (
                    new ApplicationUser
                    {
                        UserName = "curator@artgallery.com",
                        Email = "curator@artgallery.com",
                        FirstName = "Art",
                        LastName = "Curator",
                        EmailConfirmed = true,
                        Created = DateTime.UtcNow
                    },
                    "Curator@123!",
                    "Moderator"
                ),

                // Regular user 1
                (
                    new ApplicationUser
                    {
                        UserName = "maria@example.com",
                        Email = "maria@example.com",
                        FirstName = "Maria",
                        LastName = "Rodriguez",
                        EmailConfirmed = true,
                        Created = DateTime.UtcNow
                    },
                    "User@123!",
                    "User"
                ),

                // Regular user 2
                (
                    new ApplicationUser
                    {
                        UserName = "alex@example.com",
                        Email = "alex@example.com",
                        FirstName = "Alexander",
                        LastName = "Chen",
                        EmailConfirmed = true,
                        Created = DateTime.UtcNow
                    },
                    "User@123!",
                    "User"
                ),

                // Regular user 3
                (
                    new ApplicationUser
                    {
                        UserName = "sophia@example.com",
                        Email = "sophia@example.com",
                        FirstName = "Sophia",
                        LastName = "Petrov",
                        EmailConfirmed = true,
                        Created = DateTime.UtcNow
                    },
                    "User@123!",
                    "User"
                )
            };

            foreach (var (user, password, role) in users)
            {
                // Check if user exists
                var existingUser = await userManager.FindByEmailAsync(user.Email);

                if (existingUser == null)
                {
                    // Create the user
                    var result = await userManager.CreateAsync(user, password);

                    if (result.Succeeded)
                    {
                        // Assign role
                        await userManager.AddToRoleAsync(user, role);
                    }
                }
            }
        }
    }
}