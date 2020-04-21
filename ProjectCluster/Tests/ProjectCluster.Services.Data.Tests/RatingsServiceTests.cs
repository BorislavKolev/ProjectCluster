namespace ProjectCluster.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Moq;
    using ProjectCluster.Data;
    using ProjectCluster.Data.Common.Repositories;
    using ProjectCluster.Data.Models;
    using ProjectCluster.Data.Models.Enums;
    using ProjectCluster.Data.Repositories;
    using ProjectCluster.Services.Data;
    using ProjectCluster.Services.Mapping;
    using Xunit;

    public class RatingsServiceTests
    {
        private EfRepository<Rating> ratingsRepository;
        private EfDeletableEntityRepository<Project> projectsRepository;
        private RatingsService service;
        private Rating testRating1;
        private Rating testRating2;
        private Rating testRating3;
        private Rating testRating4;
        private Rating testRating5;
        private Rating testRating6;


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
            this.testRating6 = new Rating
            {
                UserId = "UserId6",
                ProjectId = 2,
                Rate = 5,
            };
        }

        [Fact]
        public void GetRating_ShouldReturn0IfProjectDoesntHaveRating()
        {
            this.Initialize();

            var actualRating = this.service.GetRating(1);

            Assert.Equal(0, actualRating);
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
        }

        [Fact]
        public void GetUserAverageRating_ShouldReturn0IfUserHasNoProjects()
        {
            this.Initialize();

            var actualRating = this.service.GetUserAverageRating("someUserId");

            Assert.Equal(0, actualRating);
        }

        internal void Initialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var dbContext = new ApplicationDbContext(options.Options);
            this.ratingsRepository = new EfRepository<Rating>(dbContext);
            this.projectsRepository = new EfDeletableEntityRepository<Project>(dbContext);
            this.service = new RatingsService(this.ratingsRepository, this.projectsRepository);
        }
    }
}
