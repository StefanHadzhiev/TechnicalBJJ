using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalBJJ.Common.Enumerations;
using TechnicalBJJ.Web.ViewModels.StartingPosition;
using TechnicalBJJ.Web.ViewModels.Step;

namespace TechnicalBJJ.Services.Data.DTOs
{
    public class TechniqueDto
    {
        public string Name { get; set; }

        public bool GiRequired { get; set; }

        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        public BeltProficiency BeltProficiency { get; set; }

        public Difficulty Difficulty { get; set; }

        public StartingPositionDto StartingPosition { get; set; }

        public ICollection<StepDto> Steps { get; set; }

        // Images...
    }
}
