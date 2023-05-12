using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalBJJ.Data.Models;

namespace TechnicalBJJ.Data.Seeding
{
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
