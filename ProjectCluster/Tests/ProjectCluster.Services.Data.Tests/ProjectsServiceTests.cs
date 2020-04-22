namespace ProjectCluster.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ProjectCluster.Data;
    using ProjectCluster.Data.Models;
    using ProjectCluster.Data.Models.Enums;
    using ProjectCluster.Data.Repositories;
    using ProjectCluster.Services.Data;
    using ProjectCluster.Services.Mapping;
    using Xunit;

    public class ProjectsServiceTests : IDisposable
    {
        private ApplicationDbContext dbContext;
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
                CategoryId = 1,
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

        public void Dispose()
        {
            this.dbContext.Dispose();
            this.projectsRepository.Dispose();
            this.projectPicturesRepository.Dispose();
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
            this.Dispose();
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
            this.Dispose();
        }

        [Fact]
        public async Task GetByCategoryId_ShouldReturnAllProjectsFromCategory()
        {
            this.Initialize();
            AutoMapperConfig.RegisterMappings(typeof(MappedProject).Assembly);
            await this.projectsRepository.AddAsync(this.testProject1);
            await this.projectsRepository.AddAsync(this.testProject2);
            await this.projectsRepository.AddAsync(this.testProject3);
            await this.projectsRepository.SaveChangesAsync();

            var resultCategories = this.service.GetByCategoryId<MappedProject>(1);

            Assert.Equal(2, resultCategories.Count());
            this.Dispose();
        }

        [Fact]
        public async Task GetById_ShouldReturnRightProject()
        {
            this.Initialize();
            AutoMapperConfig.RegisterMappings(typeof(MappedProject).Assembly);
            await this.projectsRepository.AddAsync(this.testProject1);
            await this.projectsRepository.AddAsync(this.testProject2);
            await this.projectsRepository.AddAsync(this.testProject3);
            await this.projectsRepository.SaveChangesAsync();

            var resultProject = this.service.GetById<MappedProject>(1);

            Assert.Equal(this.testProject1.Content, resultProject.Content);
            this.Dispose();
        }

        [Fact]
        public async Task GetPictureUrls_ShouldReturnRightPictureUrls()
        {
            this.Initialize();
            var testPictureProjectEntity1 = new ProjectPicture { ProjectId = 1, PictureUrl = "SomePictureUrl" };
            var testPictureProjectEntity2 = new ProjectPicture { ProjectId = 1, PictureUrl = "SomeOtherPictureUrl" };
            var testPictureProjectEntity3 = new ProjectPicture { ProjectId = 2, PictureUrl = "YetAnotherPictureUrl" };
            await this.projectPicturesRepository.AddAsync(testPictureProjectEntity1);
            await this.projectPicturesRepository.AddAsync(testPictureProjectEntity2);
            await this.projectPicturesRepository.AddAsync(testPictureProjectEntity3);
            await this.projectPicturesRepository.SaveChangesAsync();

            var resultPictureUrls = this.service.GetPictureUrls(1);

            Assert.Equal(testPictureProjectEntity1.PictureUrl, resultPictureUrls.ElementAt(0));
            Assert.Equal(testPictureProjectEntity2.PictureUrl, resultPictureUrls.ElementAt(1));
            this.Dispose();
        }

        [Fact]
        public async Task GetProjectsCountByCategoryId_ShouldReturnRightProjectCount()
        {
            this.Initialize();
            await this.projectsRepository.AddAsync(this.testProject1);
            await this.projectsRepository.AddAsync(this.testProject2);
            await this.projectsRepository.AddAsync(this.testProject3);
            await this.projectsRepository.SaveChangesAsync();

            var resultCount = this.service.GetProjectsCountByCategoryId(1);

            Assert.Equal(2, resultCount);
            this.Dispose();
        }

        internal void Initialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            this.dbContext = new ApplicationDbContext(options.Options);
            this.projectsRepository = new EfDeletableEntityRepository<Project>(this.dbContext);
            this.projectPicturesRepository = new EfDeletableEntityRepository<ProjectPicture>(this.dbContext);
            this.service = new ProjectsService(this.projectsRepository, this.projectPicturesRepository);
        }

        public class MappedProject : IMapFrom<Project>
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
