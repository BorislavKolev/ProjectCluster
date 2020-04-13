namespace ProjectCluster.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using ProjectCluster.Data.Common.Models;

    public class ProjectPicture : BaseDeletableModel<int>
    {
        [Required]
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        [Required]
        public string PictureUrl { get; set; }
    }
}
