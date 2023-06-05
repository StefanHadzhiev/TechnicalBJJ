namespace TechnicalBJJ.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TechnicalBJJ.Data.Models;
    using TechnicalBJJ.Services.Data;
    using TechnicalBJJ.Web.ViewModels.InputModels;
    using TechnicalBJJ.Web.ViewModels.StartingPosition;
    using TechnicalBJJ.Web.ViewModels.Step;
    using TechnicalBJJ.Web.ViewModels.Technique;

    public class TechniqueController : Controller
    {
        private readonly ITechniqueService techniqueService;
        private readonly IStartingPositionsService startingPositionsService;
        private readonly UserManager<ApplicationUser> userManager;

        public TechniqueController(
            ITechniqueService techniqueService,
            IStartingPositionsService startingPositionsService,
            UserManager<ApplicationUser> userManager)
        {
            this.techniqueService = techniqueService;
            this.startingPositionsService = startingPositionsService;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            var viewModel = new AddTechniqueInputModel();
            viewModel.StartingPositionsItems = this.startingPositionsService.GetStartingPositionsAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddTechniqueInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var viewModel = new AddTechniqueInputModel();
                viewModel.StartingPositionsItems = this.startingPositionsService.GetStartingPositionsAsKeyValuePairs();
                return this.View(viewModel);
            }

            var userId = this.userManager.GetUserId(this.User);
            await this.techniqueService.AddAsync(input, userId);
            return this.Redirect("/");
        }

        // Techniques/All/5
        [HttpGet]
        public IActionResult AllTechniques(int id)
        {
            var viewModel = new TechniqueListViewModel();
            viewModel.PageNumber = id;


            var techniqueDtos = this.techniqueService.GetAllTechniques(id);

            foreach (var dto in techniqueDtos)
            {
                var techniqueInListViewModel = new TechniqueInListViewModel();

                var startingPositionViewModel = new StartingPositionViewModel();
                startingPositionViewModel.Name = dto.StartingPosition.Name;

                var techniqueSteps = new List<StepViewModel>();

                foreach (var stepDto in dto.Steps)
                {
                    var stepViewModel = new StepViewModel();
                    stepViewModel.Number = stepDto.Number;
                    stepViewModel.Description = stepDto.Description;

                    techniqueSteps.Add(stepViewModel);
                } 

                techniqueInListViewModel.Name = dto.Name;

                viewModel.Techniques.Add(techniqueInListViewModel);
            }

            return this.View(viewModel);
        }
    }
}
