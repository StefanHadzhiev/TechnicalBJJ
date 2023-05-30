namespace TechnicalBJJ.Data.Seeding
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using TechnicalBJJ.Data.Models;

    public class ApplicationUsersSeeder : ISeeder
    {
        private readonly UserManager<ApplicationUser> userManager;

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            //if (dbContext.Users.Any(x => x.UserName == "admin@admin.com"))
            //{
            //    return;
            //}

            //// Create user and add him to role Administrator if he does not exist
            //var user = new ApplicationUser();
            //user.Email = "admin@admin.com";
            //user.UserName = "admin@admin.com";
            //user.EmailConfirmed = true;
            //user.PhoneNumber = "12123123";

            //await this.userManager.CreateAsync(user, "admin123");
        }
    }
}
