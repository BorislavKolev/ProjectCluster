namespace ProjectCluster.Web.ViewModels.Categories
{
    using System;

    using ProjectCluster.Data.Models;
    using ProjectCluster.Data.Models.Enums;
    using ProjectCluster.Services.Mapping;

    public class ProjectsInCategoryViewModel : IMapFrom<Project>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public ProjectStatus ProjectStatus { get; set; }

        public double Progress { get; set; }

        public double Rating { get; set; }

        public string ImageUrl { get; set; }

        public string UserUsername { get; set; }

        public int CommentsCount { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
