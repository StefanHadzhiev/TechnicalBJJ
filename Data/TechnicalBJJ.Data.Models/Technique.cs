namespace TechnicalBJJ.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TechnicalBJJ.Common.Enumerations;
    using TechnicalBJJ.Data.Common.Models;

    public class Technique : BaseDeletableModel<string>
    {
        public Technique()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Steps = new HashSet<Step>();
            this.Images = new HashSet<Image>();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public bool GiRequired { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        [Required]
        public BeltProficiency BeltProficiency { get; set; }

        [Required]
        public Difficulty Difficulty { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string StartingPositionId { get; set; }

        public virtual StartingPosition StartingPosition { get; set; }

        public ICollection<Step> Steps { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
