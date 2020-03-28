namespace ProjectCluster.Web.ViewModels.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AutoMapper;
    using ProjectCluster.Data.Models;
    using ProjectCluster.Services.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string IconName { get; set; }

        public IEnumerable<ProjectsInCategoryViewModel> Projects { get; set; }

        public IEnumerable<SidebarCategoryViewModel> SidebarCategories { get; set; }
    }
}
