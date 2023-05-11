namespace TechnicalBJJ.Web.Areas.Administration.Controllers
{
    using TechnicalBJJ.Common;
    using TechnicalBJJ.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
