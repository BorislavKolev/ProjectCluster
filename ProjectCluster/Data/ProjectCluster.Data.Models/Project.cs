namespace ProjectCluster.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ProjectCluster.Data.Common.Models;
    using ProjectCluster.Data.Models.Enums;

    using static ProjectCluster.Data.Common.DataValidation.Project;

    public class Project : BaseDeletableModel<int>
    {
        public Project()
        {
            this.Comments = new HashSet<Comment>();
            this.ProjectPictures = new HashSet<ProjectPicture>();
            this.Ratings = new HashSet<Rating>();
        }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public ProjectStatus ProjectStatus { get; set; }

        [Required]
        [Range(ProgressMinValue, ProgressMaxValue)]
        public double Progress { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<ProjectPicture> ProjectPictures { get; set; }

        public ICollection<Rating> Ratings { get; set; }
    }
}
