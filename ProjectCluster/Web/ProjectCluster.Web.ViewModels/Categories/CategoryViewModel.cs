using ProjectCluster.Data.Models;
using ProjectCluster.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCluster.Web.ViewModels.Categories
{
    class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<ProjectsInCategoryViewModel> Projects { get; set; }
    }
}
