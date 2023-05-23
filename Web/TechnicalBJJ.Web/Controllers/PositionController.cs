namespace TechnicalBJJ.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using TechnicalBJJ.Services.Data;
    using TechnicalBJJ.Web.ViewModels.InputModels;

    public class PositionController : Controller
    {
        private readonly IStartingPositionsService startingPositionsService;

        public PositionController(IStartingPositionsService startingPositionsService)
        {
            this.startingPositionsService = startingPositionsService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddPositionInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var inputModel = new AddPositionInputModel();
                return this.View(inputModel);
            }

            this.startingPositionsService.Add(input);
            return this.Redirect("/");
        }
    }
}
