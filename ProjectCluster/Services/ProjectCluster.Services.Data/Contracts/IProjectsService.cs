namespace ProjectCluster.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProjectCluster.Web.ViewModels.Projects;

    public interface IProjectsService
    {
        Task<int> CreateAsync(int categoryId, string content, string title, string projectStatus, double progress, string userId, List<string> imageUrls);

        T GetById<T>(int id);

        ICollection<string> GetPictureUrls(int id);

        IEnumerable<T> GetByCategoryId<T>(int categoryId, int? take = null, int skip = 0);

        int GetProjectsCountByCaregoryId(int categoryId);
    }
}
