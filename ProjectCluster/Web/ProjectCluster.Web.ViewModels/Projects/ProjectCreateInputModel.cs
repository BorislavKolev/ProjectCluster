namespace ProjectCluster.Web.ViewModels.Projects
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProjectCreateInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Project Status")]
        public string ProjectStatus { get; set; }

        [Display(Name = "Progress Percentage")]
        public double Progress { get; set; }

        public IEnumerable<CategoryDropdownViewModel> Categories { get; set; }
    }
}
