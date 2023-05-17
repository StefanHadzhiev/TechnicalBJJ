using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalBJJ.Data.Common.Models;

namespace TechnicalBJJ.Data.Models
{
    public class Step : BaseDeletableModel<string>
    {
        public Step()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int Number { get; set; }

        [Required]
        [MaxLength(400)]
        public string Description { get; set; }

        public string TechniqueId { get; set; }

        public virtual Technique Technique { get; set; }
    }
}
