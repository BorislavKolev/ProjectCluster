namespace ProjectCluster.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ProjectCluster.Data.Common.Repositories;
    using ProjectCluster.Data.Models;
    using ProjectCluster.Services.Data;
    using ProjectCluster.Web.ViewModels.Profiles;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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
            var userId = this.userRepository.All().FirstOrDefault(x => x.UserName == username).Id;
            var viewModel = this.profilesService.GetById<ProfileViewModel>(userId);
            viewModel.UserAverageRating = this.ratingsService.GetUserAverageRating(userId);

            return this.View();
        }
    }
}
