using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalBJJ.Web.ViewModels;

namespace TechnicalBJJ.Services.Data
{
    public interface IGetCountsService
    {
        //1.Use the view model

        IndexViewModel GetCount();
    }
}
