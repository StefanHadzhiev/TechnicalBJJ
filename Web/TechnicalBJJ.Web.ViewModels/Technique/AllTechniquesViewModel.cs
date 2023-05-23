using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalBJJ.Web.ViewModels.Technique
{
    public class AllTechniquesViewModel
    {
        public AllTechniquesViewModel()
        {
            this.Techniques = new HashSet<TechniqueViewModel>();
        }

        public ICollection<TechniqueViewModel> Techniques { get; set; }
    }
}
