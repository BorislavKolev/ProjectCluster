﻿namespace ProjectCluster.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using ProjectCluster.Services.Data;
    using ProjectCluster.Web.ViewModels;
    using ProjectCluster.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public HomeController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            var categories = this.categoriesService.GetAll<IndexCategoryViewModel>();
            viewModel.Categories = categories;

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        public IActionResult HttpError(int statusCode)
        {
            if (statusCode == 404)
            {
                return this.View("404NotFound");

            }
            else
            {
                return this.Error();
            }
        }
    }
}
