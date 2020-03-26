namespace ProjectCluster.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ProjectCluster.Common;
    using ProjectCluster.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
