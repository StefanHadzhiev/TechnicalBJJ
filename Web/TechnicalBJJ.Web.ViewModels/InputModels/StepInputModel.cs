using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalBJJ.Web.ViewModels.InputModels
{
    public class StepInputModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "The minimum number of characters for this field is 3.")]
        public string Description { get; set; }
    }
}
