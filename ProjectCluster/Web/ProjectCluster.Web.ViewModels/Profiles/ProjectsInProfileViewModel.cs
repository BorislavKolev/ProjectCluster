namespace ProjectCluster.Web.ViewModels.Profiles
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;

    using ProjectCluster.Data.Models;
    using ProjectCluster.Data.Models.Enums;
    using ProjectCluster.Services.Mapping;

    public class ProjectsInProfileViewModel : IMapFrom<Project>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Summary
        {
            get
            {
                var content = WebUtility.HtmlDecode(Regex.Replace(this.Content, @"<[^>]+>", string.Empty));
                return content.Length > 300 ? content.Substring(0, 300) + "..." : content;
            }
        }

        public ProjectStatus ProjectStatus { get; set; }

        public double Progress { get; set; }

        public string ImageUrl { get; set; }

        public string UserUsername { get; set; }

        public int CommentsCount { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
