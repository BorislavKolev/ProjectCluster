namespace ProjectCluster.Services.Data
{
    using System.Linq;

    using ProjectCluster.Data.Common.Repositories;
    using ProjectCluster.Data.Models;
    using ProjectCluster.Services.Mapping;

    public class ProfilesService : IProfilesService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public ProfilesService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public T GetById<T>(string id)
        {
            var profile = this.usersRepository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();

            return profile;
        }
    }
}
