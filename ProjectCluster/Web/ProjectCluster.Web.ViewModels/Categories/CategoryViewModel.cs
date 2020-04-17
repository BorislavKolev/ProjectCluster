namespace ProjectCluster.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    using ProjectCluster.Data.Models;
    using ProjectCluster.Services.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string IconName { get; set; }

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public IEnumerable<ProjectsInProfileViewModel> ListedProjects { get; set; }

        public IEnumerable<SidebarCategoryViewModel> SidebarCategories { get; set; }
    }
}
