namespace ProjectCluster.Web.ViewModels.Home
{
    using ProjectCluster.Data.Models;
    using ProjectCluster.Services.Mapping;

    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string CategoryUrl => $"/Categories/{this.Name.Replace(' ', '-')}";
    }
}
