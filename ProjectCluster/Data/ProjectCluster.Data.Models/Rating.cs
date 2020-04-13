namespace ProjectCluster.Data
{
    using System.ComponentModel.DataAnnotations;

    using ProjectCluster.Data.Common.Models;
    using ProjectCluster.Data.Models;

    using static ProjectCluster.Data.Common.DataValidation.Rating;

    public class Rating : BaseModel<int>
    {
        [Required]
        [Range(RateMinValue, RateMaxValue)]
        public double Rate { get; set; }

        [Required]
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
