namespace ProjectCluster.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ProjectCluster.Data.Models;
    using ProjectCluster.Services.Data;
    using ProjectCluster.Web.ViewModels.Projects;
    using ProjectCluster.Web.ViewModels.Rating;

    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingsService ratingsService;
        private readonly UserManager<ApplicationUser> userManager;

        public RatingsController(IRatingsService ratingsService, UserManager<ApplicationUser> userManager)
        {
            this.ratingsService = ratingsService;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult<RatingResponseModel>> Post(RatingInputModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            var ratingResponseModel = new RatingResponseModel();

            if (userId == null)
            {
                ratingResponseModel.AuthenticationErrorMessage = "Please log in in order to vote.";
                ratingResponseModel.Rating = this.ratingsService.GetRating(input.ProjectId);

                return ratingResponseModel;
            }

            if (input.Rate < 1 || input.Rate > 5)
            {
                ratingResponseModel.Rating = this.ratingsService.GetRating(input.ProjectId);

                return ratingResponseModel;
            }

            await this.ratingsService.RateAsync(input.ProjectId, userId, input.Rate);
            ratingResponseModel.Rating = this.ratingsService.GetRating(input.ProjectId);

            return ratingResponseModel;
        }
    }
}
