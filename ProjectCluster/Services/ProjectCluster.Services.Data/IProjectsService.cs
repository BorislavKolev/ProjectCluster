namespace ProjectCluster.Services.Data
{
    using System.Threading.Tasks;

    using ProjectCluster.Web.ViewModels.Projects;

    public interface IProjectsService
    {
        Task<int> CreateAsync(ProjectCreateInputModel input, string userId);
    }
}
