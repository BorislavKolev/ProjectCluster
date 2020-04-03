namespace ProjectCluster.Web.ViewModels.Projects
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using ProjectCluster.Data.Models.Enums;

    public class ProjectCreateInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        [Required]
        public string ProjectStatus { get; set; }

        public double Progress { get; set; }
    }
}
