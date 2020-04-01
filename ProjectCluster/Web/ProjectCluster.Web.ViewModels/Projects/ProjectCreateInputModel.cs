namespace ProjectCluster.Web.ViewModels.Projects
{
    using ProjectCluster.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProjectCreateInputModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public ProjectStatus ProjectStatus { get; set; }

        public double Progress { get; set; }
    }
}
