using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalBJJ.Data.Common.Repositories;
using TechnicalBJJ.Data.Models;
using TechnicalBJJ.Services.Data.DTOs;
using TechnicalBJJ.Web.ViewModels.InputModels;
using TechnicalBJJ.Web.ViewModels.StartingPosition;
using TechnicalBJJ.Web.ViewModels.Step;
using TechnicalBJJ.Web.ViewModels.Technique;

namespace TechnicalBJJ.Services.Data
{
    public class TechniqueService : ITechniqueService
    {
        private readonly IDeletableEntityRepository<Technique> techniquesRepository;

        private readonly IDeletableEntityRepository<StartingPosition> startingPositionRepository;

        public TechniqueService(IDeletableEntityRepository<Technique> techniquesRepository, IDeletableEntityRepository<StartingPosition> startingPositionRepository)
        {
            this.techniquesRepository = techniquesRepository;
            this.startingPositionRepository = startingPositionRepository;
        }

        public async Task AddAsync(AddTechniqueInputModel model)
        {
            var technique = new Technique();
            technique.Name = model.Name;
            technique.GiRequired = model.GiRequired;
            technique.Description = model.Description;
            technique.PublishDate = DateTime.UtcNow;
            technique.BeltProficiency = model.BeltProficiency;
            technique.Difficulty = model.Difficulty;
            technique.StartingPositionId = model.StartingPositionId;

            int stepNumber = 1;
            foreach (var inputStep in model.Steps)
            {
                var step = new Step();
                step.Number = stepNumber;
                step.Description = inputStep.Description;
                step.TechniqueId = technique.Id;
                stepNumber++;
                technique.Steps.Add(step);
            }

            await this.techniquesRepository.AddAsync(technique);
            await this.techniquesRepository.SaveChangesAsync();
        }

        public List<TechniqueDto> GetAllTechniques()
        {
            var allTechniques = new List<TechniqueDto>();
            var techniqueEntities = this.techniquesRepository.All().ToList();

            foreach (var techniqueEntity in techniqueEntities)
            {
                var startingPosition = this.startingPositionRepository.All()
                    .Where(x => x.Id == techniqueEntity.StartingPositionId)
                    .FirstOrDefault();

                techniqueEntity.StartingPosition = startingPosition;
            }

            foreach (var entity in techniqueEntities)
            {
                var techniqueDto = new TechniqueDto();

                var techniqueSteps = new List<StepDto>();

                var techniqueStartingPositionDto = new StartingPositionDto();
                techniqueStartingPositionDto.Name = entity.StartingPosition.Name;

                foreach (var step in entity.Steps)
                {
                    var stepViewModel = new StepDto();
                    stepViewModel.Description = step.Description;

                    techniqueSteps.Add(stepViewModel);
                }

                techniqueDto.Name = entity.Name;
                techniqueDto.GiRequired = entity.GiRequired;
                techniqueDto.Description = entity.Description;
                techniqueDto.PublishDate = entity.PublishDate;
                techniqueDto.BeltProficiency = entity.BeltProficiency;
                techniqueDto.Difficulty = entity.Difficulty;
                techniqueDto.StartingPosition = techniqueStartingPositionDto;
                techniqueDto.Steps = techniqueSteps;

                allTechniques.Add(techniqueDto);
            }

            return allTechniques;
        }
    }
}
