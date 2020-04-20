namespace ProjectCluster.Services.Data
{
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task Create(int projectId, string userId, string content, int? parentId = null);

        bool IsInProjectId(int commentId, int projectId);
    }
}
