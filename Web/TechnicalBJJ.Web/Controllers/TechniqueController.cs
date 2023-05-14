namespace TechnicalBJJ.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TechnicalBJJ.Data;
    using TechnicalBJJ.Services.Data;
    using TechnicalBJJ.Web.ViewModels.InputModels;

    public class TechniqueController : Controller
    {
        private readonly ITechniqueService techniqueService;

        public TechniqueController(ITechniqueService techniqueService)
        {
            this.techniqueService = techniqueService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddTechniqueInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            // Add technique to database through service
            // Redirect to technique info page
            return this.Redirect("/");
        }
    }
}
