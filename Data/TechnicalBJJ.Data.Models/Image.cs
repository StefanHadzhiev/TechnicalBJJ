namespace TechnicalBJJ.Data.Models
{
    using System;

    using TechnicalBJJ.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string UploadedById { get; set; }

        public ApplicationUser UploadedBy { get; set; }

        public string Extension { get; set; }

        public string TechniqueId { get; set; }

        public virtual Technique Technique { get; set; }
    }
}
