namespace ProjectCluster.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using ProjectCluster.Data.Common.Models;

    using static ProjectCluster.Data.Common.DataValidation.Comment;

    public class Comment : BaseDeletableModel<int>
    {
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public int? ParentId { get; set; }

        public virtual Comment Parent { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }
    }
}
