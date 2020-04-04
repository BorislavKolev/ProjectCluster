namespace ProjectCluster.Web.ViewModels.Projects
{
    using ProjectCluster.Data.Models;
    using ProjectCluster.Services.Mapping;

    public class CategoryDropdownViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}