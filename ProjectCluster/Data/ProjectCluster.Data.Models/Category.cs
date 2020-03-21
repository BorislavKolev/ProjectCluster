namespace ProjectCluster.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ProjectCluster.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Projects = new HashSet<Project>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
