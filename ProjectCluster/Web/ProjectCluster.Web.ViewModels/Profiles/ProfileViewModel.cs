namespace ProjectCluster.Web.ViewModels.Profiles
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;
    using ProjectCluster.Data.Models;
    using ProjectCluster.Services.Mapping;

    public class ProfileViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string AvatarUrl { get; set; }

        public string Description { get; set; }

        public double UserAverageRating { get; set; }

        public DateTime MemberSince { get; set; }

        public ICollection<ProjectsInProfileViewModel> Projects { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, ProfileViewModel>()
                .ForMember(
                x => x.MemberSince,
                x => x.MapFrom(u => u.CreatedOn));
        }
    }
}
