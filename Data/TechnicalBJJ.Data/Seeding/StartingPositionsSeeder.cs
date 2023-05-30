namespace TechnicalBJJ.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using TechnicalBJJ.Data.Models;

    public class StartingPositionsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.StartingPositions.Any())
            {
                return;
            }

            dbContext.StartingPositions.Add(new StartingPosition() { Name = "Guard" });
            dbContext.StartingPositions.Add(new StartingPosition() { Name = "Mount" });
            dbContext.StartingPositions.Add(new StartingPosition() { Name = "Side Control" });
            dbContext.StartingPositions.Add(new StartingPosition() { Name = "Knee on Belly" });
            dbContext.StartingPositions.Add(new StartingPosition() { Name = "Back" });

            await dbContext.SaveChangesAsync();
        }
    }
}
