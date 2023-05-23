using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalBJJ.Services.Data.DTOs;
using TechnicalBJJ.Web.ViewModels.InputModels;

namespace TechnicalBJJ.Services.Data
{
    public interface IStartingPositionsService
    {
        IEnumerable<KeyValuePair<string, string>> GetStartingPositionsAsKeyValuePairs();

        Task Add(AddPositionInputModel input);
    }
}
