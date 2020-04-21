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

    public class CommentsServiceTests
    {
        private EfDeletableEntityRepository<Comment> repository;
        private CommentsService service;
        private Comment testComment1;
        private Comment testComment2;
        private Comment testComment3;

        public CommentsServiceTests()
        {
            this.testComment1 = new Comment
            {
                UserId = "someId",
                ProjectId = 1,
                Content = "Pizza is delicious.",
            };
            this.testComment2 = new Comment
            {
                UserId = "someOtherId",
                ProjectId = 2,
                Content = "Pancakes are delicious.",
            };
            this.testComment3 = new Comment
            {
                UserId = "yetAnotherId",
                ProjectId = 3,
                Content = "Tarator is delicious.",
            };
        }

        [Fact]
        public async Task CreateCommentAsync_ShouldCreateRightComment()
        {
            this.Initialize();

            await this.service.CreateAsync(this.testComment1.ProjectId, this.testComment1.UserId, this.testComment1.Content);
            var actualComment = this.repository.All().First();

            Assert.Equal(this.testComment1.Content, actualComment.Content);
        }

        [Fact]
        public async Task IsInProject_ShouldWork()
        {
            this.Initialize();
            await this.repository.AddAsync(this.testComment1);
            await this.repository.SaveChangesAsync();
            var commentId = this.repository.All().Select(x => x.Id).FirstOrDefault();

            bool result = this.service.IsInProjectId(commentId, this.testComment1.ProjectId);

            Assert.True(result);
        }

        internal void Initialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var dbContext = new ApplicationDbContext(options.Options);
            this.repository = new EfDeletableEntityRepository<Comment>(dbContext);
            this.service = new CommentsService(this.repository);
        }
    }
}
