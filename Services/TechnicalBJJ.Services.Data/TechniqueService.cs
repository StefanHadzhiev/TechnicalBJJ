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

namespace TechnicalBJJ.Services.Data
{
    public class TechniqueService : ITechniqueService
    {
        private readonly IDeletableEntityRepository<Technique> techniquesRepository;

        public TechniqueService(IDeletableEntityRepository<Technique> techniquesRepository)
        {
            this.techniquesRepository = techniquesRepository;
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
    }
}
