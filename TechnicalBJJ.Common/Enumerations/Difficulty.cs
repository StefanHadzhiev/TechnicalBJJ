using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalBJJ.Common.Enumerations
{
    [DefaultValue(2)]
    public enum Difficulty
    {
        [Display(Name = "Very Easy")]
        VeryEasy = 0,
        Easy = 1,
        Intermediate = 2,
        Hard = 3,
        [Display(Name = "Very Hard")]
        VeryHard = 4,
    }
}
