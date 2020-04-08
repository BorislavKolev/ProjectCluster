namespace ProjectCluster.Services.Data
{
    using System.Threading.Tasks;

    public interface IRatingsService
    {
        Task RateAsync(int projectId, string userId, double rating);

        double GetRating(int projectId);

        double GetUserAverageRating(string userId);
    }
}
