using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalBJJ.Services.Data.DTOs;
using TechnicalBJJ.Web.ViewModels.InputModels;
using TechnicalBJJ.Web.ViewModels.Technique;

namespace TechnicalBJJ.Services.Data
{
    public interface ITechniqueService
    {
        Task AddAsync(AddTechniqueInputModel model);

        List<TechniqueDto> GetAllTechniques();
    }
}
