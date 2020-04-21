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
    using ProjectCluster.Data.Repositories;
    using ProjectCluster.Services.Data;
    using ProjectCluster.Services.Mapping;
    using Xunit;

    public class ProfilesServiceTests
    {
        private EfDeletableEntityRepository<ApplicationUser> repository;
        private ProfilesService service;
        private ApplicationUser testUser1;
        private ApplicationUser testUser2;
        private ApplicationUser testUser3;

        public ProfilesServiceTests()
        {
            this.testUser1 = new ApplicationUser
            {
                Id = "userId",
                Email = "first@gmail.com",
                UserName = "FirstUser",
            };
            this.testUser2 = new ApplicationUser
            {
                Id = "anotherUserId",
                Email = "second@gmail.com",
                UserName = "SecondUser",
            };
            this.testUser3 = new ApplicationUser
            {
                Id = "yetAnotherUserId",
                Email = "third@gmail.com",
                UserName = "ThirdUser",
            };
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllCategories()
        {
            this.Initialize();
            AutoMapperConfig.RegisterMappings(typeof(MappedApplicationUser).Assembly);
            await this.repository.AddAsync(this.testUser1);
            await this.repository.AddAsync(this.testUser2);
            await this.repository.AddAsync(this.testUser3);
            await this.repository.SaveChangesAsync();
            var mappedApplicationUser1 = new MappedApplicationUser
            {
                Id = "userId",
                Email = "first@gmail.com",
                UserName = "FirstUser",
            };

            var actualProfile = this.service.GetById<MappedApplicationUser>(this.testUser1.Id);

            Assert.Equal(mappedApplicationUser1.Id, actualProfile.Id);
        }

        internal void Initialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var dbContext = new ApplicationDbContext(options.Options);
            this.repository = new EfDeletableEntityRepository<ApplicationUser>(dbContext);
            this.service = new ProfilesService(this.repository);
        }

        public class MappedApplicationUser : IMapFrom<ApplicationUser>
        {
            public string Id { get; set; }

            public string Email { get; set; }

            public string UserName { get; set; }
        }
    }
}
