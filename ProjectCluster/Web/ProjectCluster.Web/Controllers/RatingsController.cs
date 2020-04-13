namespace ProjectCluster.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
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
            var user = await this.userManager.GetUserAsync(this.User);
            await this.ratingsService.RateAsync(input.ProjectId, user.Id, input.Rate);
            var rating = this.ratingsService.GetRating(input.ProjectId);

            return new RatingResponseModel { Rating = rating };
        }
    }
}
