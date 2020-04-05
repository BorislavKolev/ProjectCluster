namespace ProjectCluster.Web.ViewModels.Projects
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ProjectCluster.Data.Models;
    using ProjectCluster.Data.Models.Enums;
    using ProjectCluster.Services.Mapping;
    using ProjectCluster.Web.ViewModels.Categories;

    public class ProjectViewModel : IMapFrom<Project>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public ProjectStatus ProjectStatus { get; set; }

        public double Progress { get; set; }

        public double Rating { get; set; }

        public int CategoryId { get; set; }

        public string UserUsername { get; set; }

        public int CommentsCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<string> Urls { get; set; }

        public IEnumerable<SidebarCategoryViewModel> SidebarCategories { get; set; }
    }
}
