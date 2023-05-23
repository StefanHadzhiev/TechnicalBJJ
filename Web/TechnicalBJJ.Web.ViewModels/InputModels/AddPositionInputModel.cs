using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalBJJ.Web.ViewModels.InputModels
{
    public class AddPositionInputModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "The minimum number of characters for the Name field is 3.")]
        public string Name { get; set; }
    }
}
