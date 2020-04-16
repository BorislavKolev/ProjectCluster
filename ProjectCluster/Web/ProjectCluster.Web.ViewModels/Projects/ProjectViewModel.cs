namespace ProjectCluster.Web.ViewModels.Projects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AutoMapper;
    using Ganss.XSS;
    using ProjectCluster.Data.Models;
    using ProjectCluster.Data.Models.Enums;
    using ProjectCluster.Services.Mapping;
    using ProjectCluster.Web.ViewModels.Categories;

    public class ProjectViewModel : IMapFrom<Project>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public double Rating { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public ProjectStatus ProjectStatus { get; set; }

        public double Progress { get; set; }

        public int CategoryId { get; set; }

        public string UserUsername { get; set; }

        public int CommentsCount { get; set; }

        public IEnumerable<ProjectCommentViewModel> Comments { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<string> Urls { get; set; }

        public IEnumerable<SidebarCategoryViewModel> SidebarCategories { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Project, ProjectViewModel>()
                .ForMember(x => x.Rating, options =>
                {
                    options.MapFrom(p => p.Ratings.Average(s => s.Rate));
                });
        }
    }
}
