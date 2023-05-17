using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalBJJ.Services.Data.DTOs;
using TechnicalBJJ.Web.ViewModels.InputModels;

namespace TechnicalBJJ.Services.Data
{
    public interface ITechniqueService
    {
        Task AddAsync(AddTechniqueInputModel model);
    }
}
