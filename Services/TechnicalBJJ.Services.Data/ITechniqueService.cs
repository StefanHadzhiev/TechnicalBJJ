using Microsoft.AspNetCore.Mvc;
using TechnicalBJJ.Web.ViewModels.InputModels;

namespace TechnicalBJJ.Services.Data
{
    public interface ITechniqueService
    {
        IActionResult Add(AddTechniqueInputModel model);
    }
}
