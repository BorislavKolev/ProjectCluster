namespace ProjectCluster.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ProjectCluster.Data;
    using ProjectCluster.Data.Models;
    using ProjectCluster.Data.Repositories;
    using ProjectCluster.Services.Data;
    using Xunit;

    public class CommentsServiceTests : IDisposable
    {
        private ApplicationDbContext dbContext;
        private EfDeletableEntityRepository<Comment> repository;
        private CommentsService service;
        private Comment testComment1;

        public CommentsServiceTests()
        {
            this.testComment1 = new Comment
            {
                UserId = "someId",
                ProjectId = 1,
                Content = "Pizza is delicious.",
            };
        }

        public void Dispose()
        {
            this.dbContext.Dispose();
            this.repository.Dispose();
        }

        [Fact]
        public async Task CreateCommentAsync_ShouldCreateRightComment()
        {
            this.Initialize();

            await this.service.CreateAsync(this.testComment1.ProjectId, this.testComment1.UserId, this.testComment1.Content);
            var actualComment = this.repository.All().First();

            Assert.Equal(this.testComment1.Content, actualComment.Content);
            this.Dispose();
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
            this.Dispose();
        }

        internal void Initialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            this.dbContext = new ApplicationDbContext(options.Options);
            this.repository = new EfDeletableEntityRepository<Comment>(this.dbContext);
            this.service = new CommentsService(this.repository);
        }
    }
}
