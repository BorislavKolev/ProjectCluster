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

    public class ProjectsServiceTests
    {
        private EfDeletableEntityRepository<Project> projectsRepository;
        private EfDeletableEntityRepository<ProjectPicture> projectPicturesRepository;
        private ProjectsService service;
        private Project testProject1;
        private Project testProject2;
        private Project testProject3;

        public ProjectsServiceTests()
        {
            this.testProject1 = new Project
            {
                CategoryId = 1,
                UserId = "someUserId",
                Title = "Pancakes",
                Content = "Pancakes are delicious",
                ProjectStatus = ProjectStatus.Finished,
                Progress = 100,
            };
            this.testProject2 = new Project
            {
                CategoryId = 2,
                UserId = "someOtherUserId",
                Title = "Olives",
                Content = "Olives are delicious",
                ProjectStatus = ProjectStatus.InProgress,
                Progress = 50,
            };
            this.testProject3 = new Project
            {
                CategoryId = 3,
                UserId = "yetAnotherUserId",
                Title = "Coffee",
                Content = "Coffee is delicious",
                ProjectStatus = ProjectStatus.Finished,
                Progress = 100,
            };
        }

        [Fact]
        public async Task CreateAsync_ShouldWork()
        {
            this.Initialize();
            var testImageUrls = new List<string>();
            testImageUrls.Add("https://res.cloudinary.com/sharwinchester/image/upload/v1586893821/idm9thg37sphmhrrrtqa.jpg");
            testImageUrls.Add("https://res.cloudinary.com/sharwinchester/image/upload/v1586893821/idm9thg37tphmhrrrtqa.jpg");

            await this.service.CreateAsync(this.testProject1.CategoryId, this.testProject1.Content, this.testProject1.Title, this.testProject1.ProjectStatus.ToString(), this.testProject1.Progress, this.testProject1.UserId, testImageUrls);
            var actualProject = this.projectsRepository.All().First();

            Assert.Equal(this.testProject1.Content, actualProject.Content);
        }

        [Fact]
        public async Task CreateAsync_ShouldCreateNewProjectPictureInstance()
        {
            this.Initialize();
            var testImageUrls = new List<string>();
            testImageUrls.Add("https://res.cloudinary.com/sharwinchester/image/upload/v1586893821/idm9thg37sphmhrrrtqa.jpg");
            testImageUrls.Add("https://res.cloudinary.com/sharwinchester/image/upload/v1586893821/idm9thg37tphmhrrrtqa.jpg");

            await this.service.CreateAsync(this.testProject1.CategoryId, this.testProject1.Content, this.testProject1.Title, this.testProject1.ProjectStatus.ToString(), this.testProject1.Progress, this.testProject1.UserId, testImageUrls);

            Assert.Equal(2, this.projectPicturesRepository.All().Count());
        }

        internal void Initialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var dbContext = new ApplicationDbContext(options.Options);
            this.projectsRepository = new EfDeletableEntityRepository<Project>(dbContext);
            this.projectPicturesRepository = new EfDeletableEntityRepository<ProjectPicture>(dbContext);
            this.service = new ProjectsService(this.projectsRepository, this.projectPicturesRepository);
        }

        public class MappedProjects : IMapFrom<Project>
        {
            public string Title { get; set; }

            public string Content { get; set; }

            public ProjectStatus ProjectStatus { get; set; }

            public double Progress { get; set; }

            public int CategoryId { get; set; }

            public string UserId { get; set; }
        }
    }
}
