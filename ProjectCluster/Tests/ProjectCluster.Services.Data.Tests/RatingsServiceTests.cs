namespace ProjectCluster.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ProjectCluster.Data;
    using ProjectCluster.Data.Models;
    using ProjectCluster.Data.Models.Enums;
    using ProjectCluster.Data.Repositories;
    using ProjectCluster.Services.Data;
    using Xunit;

    public class RatingsServiceTests : IDisposable
    {
        private ApplicationDbContext dbContext;
        private EfRepository<Rating> ratingsRepository;
        private EfDeletableEntityRepository<Project> projectsRepository;
        private RatingsService service;
        private Rating testRating1;
        private Rating testRating2;
        private Rating testRating3;
        private Rating testRating4;
        private Rating testRating5;

        public RatingsServiceTests()
        {
            this.testRating1 = new Rating
            {
                UserId = "UserId1",
                ProjectId = 1,
                Rate = 1,
            };
            this.testRating2 = new Rating
            {
                UserId = "UserId2",
                ProjectId = 1,
                Rate = 2,
            };
            this.testRating3 = new Rating
            {
                UserId = "UserId3",
                ProjectId = 1,
                Rate = 3,
            };
            this.testRating4 = new Rating
            {
                UserId = "UserId4",
                ProjectId = 1,
                Rate = 4,
            };
            this.testRating5 = new Rating
            {
                UserId = "UserId5",
                ProjectId = 1,
                Rate = 5,
            };
        }

        public void Dispose()
        {
            this.dbContext.Dispose();
            this.ratingsRepository.Dispose();
            this.projectsRepository.Dispose();
        }

        [Fact]
        public void GetRating_ShouldReturn0IfProjectDoesntHaveRating()
        {
            this.Initialize();

            var actualRating = this.service.GetRating(1);

            Assert.Equal(0, actualRating);
            this.Dispose();
        }

        [Fact]
        public async Task GetRating_ShouldReturnRightAverageRating()
        {
            this.Initialize();
            await this.ratingsRepository.AddAsync(this.testRating2);
            await this.ratingsRepository.AddAsync(this.testRating3);
            await this.ratingsRepository.AddAsync(this.testRating4);
            await this.ratingsRepository.AddAsync(this.testRating5);
            await this.ratingsRepository.SaveChangesAsync();

            var actualRating = this.service.GetRating(1);

            Assert.Equal(3.5, actualRating);
            this.Dispose();
        }

        [Fact]
        public void GetUserAverageRating_ShouldReturn0IfUserHasNoProjects()
        {
            this.Initialize();

            var actualRating = this.service.GetUserAverageRating("someUserId");

            Assert.Equal(0, actualRating);
            this.Dispose();
        }

        [Fact]
        public async Task GetUserAverageRating_ShouldReturnRightAverageRating()
        {
            this.Initialize();
            var testProject1 = new Project
            {
                CategoryId = 1,
                UserId = "testUserId",
                Title = "Pancakes",
                Content = "Pancakes are delicious",
                ProjectStatus = ProjectStatus.Finished,
                Progress = 100,
            };
            var testProject2 = new Project
            {
                CategoryId = 2,
                UserId = "testUserId",
                Title = "Olives",
                Content = "Olives are delicious",
                ProjectStatus = ProjectStatus.InProgress,
                Progress = 50,
            };
            var testProject3 = new Project
            {
                CategoryId = 3,
                UserId = "testUserId",
                Title = "Coffee",
                Content = "Coffee is delicious",
                ProjectStatus = ProjectStatus.Finished,
                Progress = 100,
            };
            await this.projectsRepository.AddAsync(testProject1);
            await this.projectsRepository.AddAsync(testProject2);
            await this.projectsRepository.AddAsync(testProject3);
            await this.projectsRepository.SaveChangesAsync();
            var testRating1 = new Rating
            {
                ProjectId = 1,
                UserId = "ratingUserId",
                Rate = 2,
            };
            var testRating2 = new Rating
            {
                ProjectId = 2,
                UserId = "ratingUserId",
                Rate = 3,
            };
            var testRating3 = new Rating
            {
                ProjectId = 3,
                UserId = "ratingUserId",
                Rate = 4,
            };
            await this.ratingsRepository.AddAsync(testRating1);
            await this.ratingsRepository.AddAsync(testRating2);
            await this.ratingsRepository.AddAsync(testRating3);
            await this.ratingsRepository.SaveChangesAsync();

            var actualRating = this.service.GetUserAverageRating("testUserId");

            Assert.Equal(3, actualRating);
            this.Dispose();
        }

        [Fact]
        public async Task RateAsync_ShouldCreateNewRatingIfItDoesntExist()
        {
            this.Initialize();

            await this.service.RateAsync(1, "SomeUserId", 4);
            var doesRatingExist = this.ratingsRepository.All().Any();

            Assert.True(doesRatingExist);
            this.Dispose();
        }

        [Fact]
        public async Task RateAsync_ShouldUpdateRatingIfItAlreadyExists()
        {
            this.Initialize();
            await this.ratingsRepository.AddAsync(this.testRating1);
            await this.ratingsRepository.SaveChangesAsync();

            await this.service.RateAsync(this.testRating1.ProjectId, this.testRating1.UserId, 5);
            var actualRating = this.ratingsRepository.All().Where(x => x.UserId == this.testRating1.UserId && x.ProjectId == this.testRating1.ProjectId).Select(x => x.Rate).FirstOrDefault();

            Assert.Equal(5, actualRating);
            this.Dispose();
        }

        internal void Initialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            this.dbContext = new ApplicationDbContext(options.Options);
            this.ratingsRepository = new EfRepository<Rating>(this.dbContext);
            this.projectsRepository = new EfDeletableEntityRepository<Project>(this.dbContext);
            this.service = new RatingsService(this.ratingsRepository, this.projectsRepository);
        }
    }
}
