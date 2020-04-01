namespace ProjectCluster.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ProjectCluster.Data.Models;
    using ProjectCluster.Services.Data;
    using ProjectCluster.Web.ViewModels.Projects;

    public class ProjectsController : Controller
    {
        private readonly IProjectsService projectsService;
        private readonly UserManager<ApplicationUser> userManager;

        public ProjectsController(IProjectsService projectsService, UserManager<ApplicationUser> userManager)
        {
            this.projectsService = projectsService;
            this.userManager = userManager;
        }

        public IActionResult ById(int id)
        {
            return this.View();
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync(ProjectCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            int projectId = await this.projectsService.CreateAsync(input, user.Id);

            return this.RedirectToAction("ById", new { id = projectId });
        }
    }
}
