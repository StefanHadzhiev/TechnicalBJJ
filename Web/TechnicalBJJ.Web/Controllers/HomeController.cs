namespace TechnicalBJJ.Web.Controllers
{
    using System.Diagnostics;

    using TechnicalBJJ.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using TechnicalBJJ.Data;
    using System.Linq;

    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var indexViewModel = new IndexViewModel()
            {
                TechniquesCount = this.dbContext.Techniques.Count(),
                StartingPositionsCount = this.dbContext.StartingPositions.Count(),
                StepsCount = this.dbContext.Steps.Count(),
                ImagesCount = this.dbContext.Images.Count(),
            };

            return this.View(indexViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
