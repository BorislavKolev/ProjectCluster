namespace ProjectCluster.Web.Controllers
{
    using System;

    using Microsoft.AspNetCore.Mvc;
    using ProjectCluster.Services.Data;
    using ProjectCluster.Web.ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private const int ItemsPerPage = 5;

        private readonly ICategoriesService categoriesService;
        private readonly IProjectsService projectsService;

        public CategoriesController(ICategoriesService categoriesService, IProjectsService projectsService)
        {
            this.categoriesService = categoriesService;
            this.projectsService = projectsService;
        }

        public IActionResult ByName(string name, int page = 1)
        {
            var viewModel = this.categoriesService.GetByName<CategoryViewModel>(name);
            var sidebarCategories = this.categoriesService.GetAll<SidebarCategoryViewModel>();
            var count = this.projectsService.GetProjectsCountByCaregoryId(viewModel.Id);

            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);
            viewModel.ListedProjects = this.projectsService.GetByCategoryId<ProjectsInCategoryViewModel>(viewModel.Id, ItemsPerPage, (page - 1) * ItemsPerPage); 
            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.SidebarCategories = sidebarCategories;
            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }
    }
}
