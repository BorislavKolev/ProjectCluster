namespace ProjectCluster.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ProjectCluster.Data.Models;
    using ProjectCluster.Services.Data;
    using ProjectCluster.Web.ViewModels.Comments;

    public class CommentsController : Controller
    {
        private readonly ICommentsService commentsService;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentsController(ICommentsService commentsService, UserManager<ApplicationUser> userManager)
        {
            this.commentsService = commentsService;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("ById", "Projects", new { id = input.ProjectId });
            }

            int? parentId = input.ParentId == 0 ? (int?)null : input.ParentId;
            var user = await this.userManager.GetUserAsync(this.User);

            if (parentId.HasValue)
            {
                if (!this.commentsService.IsInProjectId(parentId.Value, input.ProjectId))
                {
                    return this.BadRequest();
                }
            }

            await this.commentsService.Create(input.ProjectId, user.Id, input.Content, parentId);

            return this.RedirectToAction("ById", "Projects", new { id = input.ProjectId });
        }
    }
}
