using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalBJJ.Web.ViewModels.Technique
{
    public class TechniqueListViewModel
    {
        public TechniqueListViewModel()
        {
            this.Techniques = new HashSet<TechniqueInListViewModel>();
        }

        public ICollection<TechniqueInListViewModel> Techniques { get; set; }

        public int PageNumber { get; set; }
    }
}
