namespace ProjectCluster.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using ProjectCluster.Data.Common.Repositories;
    using ProjectCluster.Data.Models;
    using ProjectCluster.Services.Data;
    using ProjectCluster.Web.ViewModels.Profiles;

    public class ProfilesController : BaseController
    {
        private readonly IProfilesService profilesService;
        private readonly IRatingsService ratingsService;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public ProfilesController(IProfilesService profilesService, IRatingsService ratingsService, IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.profilesService = profilesService;
            this.ratingsService = ratingsService;
            this.userRepository = userRepository;
        }

        public IActionResult ByUsername(string username)
        {
            string userId = string.Empty;
            try
            {
                userId = this.userRepository.All().FirstOrDefault(x => x.UserName == username).Id;
            }
            catch (System.Exception)
            {
                return this.RedirectToAction("HttpError", new { statusCode = 404 });
            }

            var viewModel = this.profilesService.GetById<ProfileViewModel>(userId);
            viewModel.UserAverageRating = this.ratingsService.GetUserAverageRating(userId);
            if (viewModel.AvatarUrl.StartsWith("https"))
            {
                viewModel.AvatarUrl = viewModel.AvatarUrl.Insert(55, "c_fill,h_250,w_250/");
            }
            else
            {
                viewModel.AvatarUrl = viewModel.AvatarUrl.Insert(54, "c_fill,h_250,w_250/");
            }

            foreach (var project in viewModel.Projects)
            {
                project.Rating = this.ratingsService.GetRating(project.Id);
            }

            return this.View(viewModel);
        }
    }
}
