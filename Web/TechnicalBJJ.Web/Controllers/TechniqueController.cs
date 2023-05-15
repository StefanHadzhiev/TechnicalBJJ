namespace TechnicalBJJ.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    using TechnicalBJJ.Services.Data;
    using TechnicalBJJ.Web.ViewModels.InputModels;

    public class TechniqueController : Controller
    {
        private readonly ITechniqueService techniqueService;
        private readonly IStartingPositionsService startingPositionsService;

        public TechniqueController(
            ITechniqueService techniqueService,
            IStartingPositionsService startingPositionsService)
        {
            this.techniqueService = techniqueService;
            this.startingPositionsService = startingPositionsService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var viewModel = new AddTechniqueInputModel();
            viewModel.StartingPositionsItems = this.startingPositionsService.GetStartingPositionsAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(AddTechniqueInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var viewModel = new AddTechniqueInputModel();
                viewModel.StartingPositionsItems = this.startingPositionsService.GetStartingPositionsAsKeyValuePairs();
                return this.View(viewModel);
            }

            // Add technique to database through service
            // Redirect to technique info page
            return this.Redirect("/");
        }
    }
}
