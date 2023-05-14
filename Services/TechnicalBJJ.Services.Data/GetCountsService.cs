using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalBJJ.Data.Common.Repositories;
using TechnicalBJJ.Data.Models;
using TechnicalBJJ.Services.Data.DTOs;
using TechnicalBJJ.Web.ViewModels;

namespace TechnicalBJJ.Services.Data
{
    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Technique> techniquesRepository;
        private readonly IDeletableEntityRepository<StartingPosition> startingPositionRepository;
        private readonly IDeletableEntityRepository<Step> stepsRepository;
        private readonly IDeletableEntityRepository<Image> imagesRepository;

        public GetCountsService(
            IDeletableEntityRepository<Technique> techniquesRepository,
            IDeletableEntityRepository<StartingPosition> startingPositionsRepository,
            IDeletableEntityRepository<Step> stepsRepository,
            IDeletableEntityRepository<Image> imagesRepository)
        {
            this.techniquesRepository = techniquesRepository;
            this.startingPositionRepository = startingPositionsRepository;
            this.stepsRepository = stepsRepository;
            this.imagesRepository = imagesRepository;
        }

        public CountsDto GetCount()
        {
            var viewModel = new CountsDto()
            {
                TechniquesCount = this.techniquesRepository.All().Count(),
                StartingPositionsCount = this.startingPositionRepository.All().Count(),
                StepsCount = this.stepsRepository.All().Count(),
                ImagesCount = this.imagesRepository.All().Count(),
            };

            return viewModel;
        }
    }
}
