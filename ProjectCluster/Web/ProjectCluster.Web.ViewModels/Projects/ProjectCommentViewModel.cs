namespace ProjectCluster.Web.ViewModels.Projects
{
    using System;

    using ProjectCluster.Data.Models;
    using ProjectCluster.Services.Mapping;

    public class ProjectCommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }

        public string UserAvatarUrl { get; set; }
    }
}
