namespace ProjectCluster.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using ProjectCluster.Services.Data;
    using ProjectCluster.Web.ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult ByName(string name)
        {
            var viewModel = this.categoriesService.GetByName<CategoryViewModel>(name);
            var sidebarCategories = this.categoriesService.GetAll<SidebarCategoryViewModel>();

            viewModel.SidebarCategories = sidebarCategories;

            return this.View(viewModel);
        }
    }
}
