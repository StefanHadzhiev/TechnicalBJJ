namespace TechnicalBJJ.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TechnicalBJJ.Services.Data;
    using TechnicalBJJ.Web.ViewModels.InputModels;
    using TechnicalBJJ.Web.ViewModels.StartingPosition;
    using TechnicalBJJ.Web.ViewModels.Step;
    using TechnicalBJJ.Web.ViewModels.Technique;

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
        public async Task<IActionResult> Add(AddTechniqueInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var viewModel = new AddTechniqueInputModel();
                viewModel.StartingPositionsItems = this.startingPositionsService.GetStartingPositionsAsKeyValuePairs();
                return this.View(viewModel);
            }

            await this.techniqueService.AddAsync(input);
            return this.Redirect("/");
        }

        [HttpGet]
        public IActionResult AllTechniques()
        {
            var viewModel = new AllTechniquesViewModel();

            var techniqueDtos = this.techniqueService.GetAllTechniques();

            foreach (var dto in techniqueDtos)
            {
                var techniqueViewModel = new TechniqueViewModel();

                var startingPositionViewModel = new StartingPositionViewModel();
                startingPositionViewModel.Name = dto.StartingPosition.Name;

                var techniqueSteps = new List<StepViewModel>();

                foreach (var stepDto in dto.Steps)
                {
                    var stepViewModel = new StepViewModel();
                    stepViewModel.Description = stepDto.Description;

                    techniqueSteps.Add(stepViewModel);
                }

                techniqueViewModel.Name = dto.Name;
                techniqueViewModel.GiRequired = dto.GiRequired;
                techniqueViewModel.Description = dto.Description;
                techniqueViewModel.PublishDate = dto.PublishDate;
                techniqueViewModel.BeltProficiency = dto.BeltProficiency;
                techniqueViewModel.Difficulty = dto.Difficulty;
                techniqueViewModel.StartingPosition = startingPositionViewModel;
                techniqueViewModel.Steps = techniqueSteps;

                viewModel.Techniques.Add(techniqueViewModel);
            }

            return this.View(viewModel);
        }
    }
}
