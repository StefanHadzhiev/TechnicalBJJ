﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        private readonly IDeletableEntityRepository<Step> stepsRepository;

        public TechniqueService(
            IDeletableEntityRepository<Technique> techniquesRepository, 
            IDeletableEntityRepository<StartingPosition> startingPositionRepository,
            IDeletableEntityRepository<Step> stepsRepository)
        {
            this.techniquesRepository = techniquesRepository;
            this.startingPositionRepository = startingPositionRepository;
            this.stepsRepository = stepsRepository;
        }

        public async Task AddAsync(AddTechniqueInputModel model, string userId)
        {
            var technique = new Technique();
            technique.Name = model.Name;
            technique.GiRequired = model.GiRequired;
            technique.Description = model.Description;
            technique.PublishDate = DateTime.UtcNow;
            technique.BeltProficiency = model.BeltProficiency;
            technique.Difficulty = model.Difficulty;
            technique.StartingPositionId = model.StartingPositionId;
            technique.UserId = userId;

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

                var steps = this.stepsRepository.All()
                    .Where(s => s.TechniqueId == techniqueEntity.Id)
                    .OrderBy(s => s.Number)
                    .ToList();

                techniqueEntity.Steps = steps;
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
                    stepViewModel.Number = step.Number;
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

        public List<TechniqueDto> GetAllTechniques(int page, int itemsPerPage = 12)
        {
            var techniques = this.techniquesRepository.AllAsNoTracking()
                                                      .OrderByDescending(x => x.Id)
                                                      .Skip((page - 1) * itemsPerPage)
                                                      .Take(itemsPerPage)
                                                      .Select(x => new TechniqueInListViewModel()
                                                      {
                                                          Id = x.Id,
                                                          Name = x.Name,
                                                          StartingPositionName = x.StartingPosition.Name,
                                                          PublishDate = x.PublishDate,
                                                      })
                                                      .ToList();
            List<TechniqueDto> somelist = new List<TechniqueDto>();
            return somelist;
            // item 1-12 => page 1
            // item 13-24 => page 2
            // item 25-36 => page 3
        }
    }
}
