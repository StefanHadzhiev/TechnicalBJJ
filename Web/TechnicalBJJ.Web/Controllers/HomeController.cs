namespace TechnicalBJJ.Web.Controllers
{
    using System.Diagnostics;

    using TechnicalBJJ.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using TechnicalBJJ.Data;
    using System.Linq;
    using TechnicalBJJ.Data.Common.Repositories;
    using TechnicalBJJ.Data.Models;
    using TechnicalBJJ.Services.Data;
    using AutoMapper;

    public class HomeController : BaseController
    {
        private readonly IGetCountsService getCountsService;

        // Implement automapper
        public HomeController(IGetCountsService getCountsService)
        {
            this.getCountsService = getCountsService;
        }

        public IActionResult Index()
        {
            var counts = this.getCountsService.GetCount();
            var viewModel = new IndexViewModel()
            {
                TechniquesCount = counts.TechniquesCount,
                StartingPositionsCount = counts.StartingPositionsCount,
                StepsCount = counts.StepsCount,
                ImagesCount = counts.ImagesCount,
            };
            return this.View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
