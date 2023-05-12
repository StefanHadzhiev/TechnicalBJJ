using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalBJJ.Web.ViewModels.InputModels;

namespace TechnicalBJJ.Services.Data
{
    public interface ITechniqueService
    {
        public IActionResult Add(TechniqueInputModel model);
    }
}
