using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalBJJ.Data.Common.Repositories;
using TechnicalBJJ.Data.Models;
using TechnicalBJJ.Services.Data.DTOs;
using TechnicalBJJ.Web.ViewModels.InputModels;

namespace TechnicalBJJ.Services.Data
{
    public class StartingPositionsService : IStartingPositionsService
    {
        private readonly IDeletableEntityRepository<StartingPosition> startingPositionRepository;

        public StartingPositionsService(
            IDeletableEntityRepository<StartingPosition> startingPositionRepository)
        {
            this.startingPositionRepository = startingPositionRepository;
        }

        public async Task Add(AddPositionInputModel input)
        {
            var startingPosition = this.startingPositionRepository.All().FirstOrDefault(x => x.Name == input.Name);

            if (startingPosition != null)
            {
                // error - there is already a position with this name in the database
            }
            else
            {
                startingPosition = new StartingPosition() { Name = input.Name };
                await this.startingPositionRepository.AddAsync(startingPosition);
                await this.startingPositionRepository.SaveChangesAsync();
            }
        }

        public IEnumerable<KeyValuePair<string, string>> GetStartingPositionsAsKeyValuePairs()
        {
            return this.startingPositionRepository.All().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
