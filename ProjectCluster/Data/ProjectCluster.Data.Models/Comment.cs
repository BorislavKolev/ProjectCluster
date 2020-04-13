namespace ProjectCluster.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using ProjectCluster.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        [Required]
        public string Content { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }
    }
}
