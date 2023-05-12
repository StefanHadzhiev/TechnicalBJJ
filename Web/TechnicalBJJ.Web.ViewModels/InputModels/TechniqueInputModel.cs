using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalBJJ.Common.Enumerations;
using TechnicalBJJ.Data.Models;

namespace TechnicalBJJ.Web.ViewModels.InputModels
{
    public class TechniqueInputModel
    {
        public TechniqueInputModel()
        {
            this.Steps = new HashSet<Step>();
        }

        public string Name { get; set; }

        public bool GiRequired { get; set; }

        public string Description { get; set; }

        public BeltProficiency BeltProficiency { get; set; }

        public StartingPosition StartingPosition { get; set; }

        public Difficulty Difficulty { get; set; }

        public ICollection<Step> Steps { get; set; }
    }
}
