namespace ProjectCluster.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ProjectCluster.Data;
    using ProjectCluster.Data.Common.Repositories;

    public class RatingsService : IRatingsService
    {
        private readonly IRepository<Rating> ratingsRepository;

        public RatingsService(IRepository<Rating> ratingsRepository)
        {
            this.ratingsRepository = ratingsRepository;
        }

        public double GetRating(int projectId)
        {
            var rating = this.ratingsRepository
                .All()
                .Where(x => x.ProjectId == projectId)
                .Average(x => x.Rate);

            return rating;
        }

        public double GetUserAverageRating(string userId)
        {
            var rating = this.ratingsRepository
                .All()
                .Where(x => x.UserId == userId)
                .Average(x => x.Rate);

            return rating;
        }

        public async Task RateAsync(int projectId, string userId, double rate)
        {
            var rating = this.ratingsRepository
                .All()
                .FirstOrDefault(x => x.ProjectId == projectId && x.UserId == userId);

            if (rating == null)
            {
                rating = new Rating
                {
                    ProjectId = projectId,
                    UserId = userId,
                    Rate = rate,
                };

                await this.ratingsRepository.AddAsync(rating);
            }
            else
            {
                rating.Rate = rate;
            }

            await this.ratingsRepository.SaveChangesAsync();
        }
    }
}
