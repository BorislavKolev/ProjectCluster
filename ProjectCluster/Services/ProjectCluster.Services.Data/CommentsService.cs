namespace ProjectCluster.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ProjectCluster.Data.Common.Repositories;
    using ProjectCluster.Data.Models;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task CreateAsync(int projectId, string userId, string content, int? parentId = null)
        {
            var comment = new Comment
            {
                Content = content,
                ParentId = parentId,
                ProjectId = projectId,
                UserId = userId,
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public bool IsInProjectId(int commentId, int projectId)
        {
            var commentProjectId = this.commentsRepository.All().Where(x => x.Id == commentId).Select(x => x.ProjectId).FirstOrDefault();

            return commentProjectId == projectId;
        }
    }
}
