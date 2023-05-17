using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using TechnicalBJJ.Data.Common.Models;

namespace TechnicalBJJ.Data.Models
{
    public class StartingPosition : BaseDeletableModel<string>
    {
        public StartingPosition()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
            this.Techinques = new HashSet<Technique>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Technique> Techinques { get; set; }
    }
}
