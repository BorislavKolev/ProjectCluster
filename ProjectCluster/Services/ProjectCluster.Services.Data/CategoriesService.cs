namespace ProjectCluster.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using ProjectCluster.Data.Common.Repositories;
    using ProjectCluster.Data.Models;
    using ProjectCluster.Services.Mapping;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Category> query = this.categoriesRepository.All().OrderBy(x => x.Name);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetByName<T>(string name, int? take = null, int skip = 0)
        {
            var category = this.categoriesRepository
                .All()
                .Where(x => x.Name == name)
                .To<T>()
                .FirstOrDefault();

            return category;
        }
    }
}
