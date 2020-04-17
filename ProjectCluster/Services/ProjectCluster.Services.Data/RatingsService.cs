namespace ProjectCluster.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ProjectCluster.Data;
    using ProjectCluster.Data.Common.Repositories;
    using ProjectCluster.Data.Models;

    public class RatingsService : IRatingsService
    {
        private readonly IRepository<Rating> ratingsRepository;
        private readonly IDeletableEntityRepository<Project> projectsRepository;

        public RatingsService(IRepository<Rating> ratingsRepository, IDeletableEntityRepository<Project> projectsRepository)
        {
            this.ratingsRepository = ratingsRepository;
            this.projectsRepository = projectsRepository;
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
            double rating = 0;
            var isUserHaveProjects = this.projectsRepository.All().Any(x => x.UserId == userId);
            if (isUserHaveProjects)
            {
                var projectsByUser = this.projectsRepository.All().Where(x => x.UserId == userId).ToList();
                double projectsByUserRatingSum = 0;
                foreach (var project in projectsByUser)
                {
                    var projectAverageRating = this.GetRating(project.Id);
                    projectsByUserRatingSum += projectAverageRating;
                }

                rating = projectsByUserRatingSum / projectsByUser.Count();
            }

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
