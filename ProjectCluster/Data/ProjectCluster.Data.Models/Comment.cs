namespace ProjectCluster.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ProjectCluster.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public string Content { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }
    }
}
