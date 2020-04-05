namespace ProjectCluster.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ProjectCluster.Data.Common.Models;

    public class ProjectPicture : BaseDeletableModel<int>
    {
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public string PictureUrl { get; set; }
    }
}
