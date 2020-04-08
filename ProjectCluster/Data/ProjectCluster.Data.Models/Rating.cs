namespace ProjectCluster.Data
{
    using System.ComponentModel.DataAnnotations;

    using ProjectCluster.Data.Common.Models;
    using ProjectCluster.Data.Models;

    public class Rating : BaseModel<int>
    {
        public double Rate { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
