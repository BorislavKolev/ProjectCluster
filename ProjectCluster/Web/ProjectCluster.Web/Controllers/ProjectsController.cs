namespace ProjectCluster.Web.Controllers
{
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ProjectCluster.Data.CloudinaryHelper;
    using ProjectCluster.Data.Models;
    using ProjectCluster.Services.Data;
    using ProjectCluster.Web.ViewModels.Categories;
    using ProjectCluster.Web.ViewModels.Projects;

    public class ProjectsController : Controller
    {
        private readonly IProjectsService projectsService;
        private readonly ICategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly Cloudinary cloudinary;

        public ProjectsController(IProjectsService projectsService, ICategoriesService categoriesService, UserManager<ApplicationUser> userManager, Cloudinary cloudinary)
        {
            this.projectsService = projectsService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
            this.cloudinary = cloudinary;
        }

        public IActionResult ById(int id)
        {
            var projectViewModel = this.projectsService.GetById<ProjectViewModel>(id);
            if (projectViewModel == null)
            {
                return this.NotFound();
            }

            var sidebarCategories = this.categoriesService.GetAll<SidebarCategoryViewModel>();
            var urls = this.projectsService.GetPictureUrls(projectViewModel.Id);

            projectViewModel.SidebarCategories = sidebarCategories;
            projectViewModel.Urls = urls;

            return this.View(projectViewModel);
        }

        [Authorize]
        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAll<CategoryDropdownViewModel>();
            var viewModel = new ProjectCreateInputModel
            {
                Categories = categories,
            };

            return this.View(viewModel);
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

            var imageUrls = await CloudinaryExtension.UploadMultipleAsync(this.cloudinary, input.Pictures);

            int projectId = await this.projectsService.CreateAsync(input, user.Id, imageUrls);

            return this.RedirectToAction("ById", new { id = projectId });
        }
    }
}
