namespace TechnicalBJJ.Web.ViewModels.Technique
{
    using System;
    using System.Collections.Generic;

    using TechnicalBJJ.Common.Enumerations;
    using TechnicalBJJ.Web.ViewModels.StartingPosition;
    using TechnicalBJJ.Web.ViewModels.Step;

    public class TechniqueViewModel
    {
        public TechniqueViewModel()
        {
            this.Steps = new HashSet<StepViewModel>();
        }

        public string Name { get; set; }

        public bool GiRequired { get; set; }

        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        public BeltProficiency BeltProficiency { get; set; }

        public Difficulty Difficulty { get; set; }

        public StartingPositionViewModel StartingPosition { get; set; }

        public ICollection<StepViewModel> Steps { get; set; }

        // Images...
    }
}
