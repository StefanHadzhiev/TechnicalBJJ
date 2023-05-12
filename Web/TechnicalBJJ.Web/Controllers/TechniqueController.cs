using Microsoft.AspNetCore.Mvc;
using TechnicalBJJ.Data;

namespace TechnicalBJJ.Web.Controllers
{
    public class TechniqueController : Controller
    {
        private readonly ApplicationDbContext db;

        public TechniqueController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
    }
}
