namespace ProjectCluster.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ProjectCluster.Data.Common.Models;

    using static ProjectCluster.Data.Common.DataValidation.Category;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Projects = new HashSet<Project>();
        }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string IconName { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
