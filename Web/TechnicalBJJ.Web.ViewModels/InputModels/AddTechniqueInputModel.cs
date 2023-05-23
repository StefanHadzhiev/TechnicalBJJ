using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TechnicalBJJ.Common.Enumerations;


namespace TechnicalBJJ.Web.ViewModels.InputModels
{
    public class AddTechniqueInputModel
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Display(Name="Is using a GI necessary for this technique?")]
        public bool GiRequired { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MinLength(20, ErrorMessage = "The minimum number of characters for the Description field is 20.")]
        public string Description { get; set; }

        [DefaultValue(0)]
        [Display(Name = "Belt Proficiency")]
        public BeltProficiency BeltProficiency { get; set; }

        [Display(Name = "Starting Position")]
        public string StartingPositionId { get; set; }

        [DefaultValue(0)]
        public Difficulty Difficulty { get; set; }

        public IEnumerable<StepInputModel> Steps { get; set; }

        public IEnumerable<KeyValuePair<string, string>> StartingPositionsItems { get; set; }
    }
}
