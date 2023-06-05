using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalBJJ.Web.ViewModels.Technique
{
    public class TechniqueInListViewModel
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string StartingPositionId { get; set; }

        public string StartingPositionName { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
