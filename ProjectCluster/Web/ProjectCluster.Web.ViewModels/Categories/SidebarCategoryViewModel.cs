using ProjectCluster.Data.Models;
using ProjectCluster.Services.Mapping;

namespace ProjectCluster.Web.ViewModels.Categories
{
    public class SidebarCategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public string IconName { get; set; }

        public int ProjectsCount { get; set; }

        public string CategoryUrl => $"/Categories/{this.Name.Replace(' ', '-')}";
    }
}