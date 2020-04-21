namespace ProjectCluster.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Moq;
    using ProjectCluster.Data;
    using ProjectCluster.Data.Common.Repositories;
    using ProjectCluster.Data.Models;
    using ProjectCluster.Data.Repositories;
    using ProjectCluster.Services.Data;
    using ProjectCluster.Services.Mapping;
    using Xunit;

    public class CategoriesServiceTests
    {
        private EfDeletableEntityRepository<Category> repository;
        private CategoriesService service;
        private Category testCategory1;
        private Category testCategory2;
        private Category testCategory3;

        public CategoriesServiceTests()
        {
            this.testCategory1 = new Category
            {
                Name = "Cars",
                Description = "Car stuff",
                IconName = "fas fa-car",
                ImageUrl = "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958937/Categories/cars_cnn2wn.jpg",
            };
            this.testCategory2 = new Category
            {
                Name = "Cooking",
                Description = "Cooking stuff",
                IconName = "fas fa-utensils",
                ImageUrl = "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958941/Categories/cooking_gryjkx.jpg",
            };
            this.testCategory3 = new Category
            {
                Name = "Art",
                Description = "Art stuff",
                IconName = "fas fa-palette",
                ImageUrl = "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958919/Categories/art_iac8id.jpg",
            };
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllCategories()
        {
            this.Initialize();
            AutoMapperConfig.RegisterMappings(typeof(MappedCategory).Assembly);
            await this.repository.AddAsync(this.testCategory1);
            await this.repository.AddAsync(this.testCategory2);
            await this.repository.AddAsync(this.testCategory3);
            await this.repository.SaveChangesAsync();
            var mappedCategory1 = new MappedCategory
            {
                Name = "Cars",
                Description = "Car stuff",
                IconName = "fas fa-car",
                ImageUrl = "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958937/Categories/cars_cnn2wn.jpg",
            };
            var mappedCategory2 = new MappedCategory
            {
                Name = "Cooking",
                Description = "Cooking stuff",
                IconName = "fas fa-utensils",
                ImageUrl = "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958941/Categories/cooking_gryjkx.jpg",
            };
            var mappedCategory3 = new MappedCategory
            {
                Name = "Art",
                Description = "Art stuff",
                IconName = "fas fa-palette",
                ImageUrl = "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958919/Categories/art_iac8id.jpg",
            };
            var expectedList = new List<MappedCategory> { mappedCategory1, mappedCategory2, mappedCategory3 };
            expectedList = expectedList.OrderBy(x => x.Name).ToList();

            var actualList = this.service.GetAll<MappedCategory>();

            for (int i = 0; i <= 2; i++)
            {
                Assert.Equal(expectedList.ElementAt(i).Name, actualList.ElementAt(i).Name);
            }
        }

        [Fact]
        public async Task GetByName_ShouldReturnRightCategory()
        {
            this.Initialize();
            AutoMapperConfig.RegisterMappings(typeof(MappedCategory).Assembly);
            await this.repository.AddAsync(this.testCategory1);
            await this.repository.AddAsync(this.testCategory2);
            await this.repository.AddAsync(this.testCategory3);
            await this.repository.SaveChangesAsync();
            var expectedCategoryName = "Art";

            var actualCategory = this.service.GetByName<MappedCategory>("Art");

            Assert.Equal(expectedCategoryName, actualCategory.Name);
        }

        internal void Initialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var dbContext = new ApplicationDbContext(options.Options);
            this.repository = new EfDeletableEntityRepository<Category>(dbContext);
            this.service = new CategoriesService(this.repository);
        }

        public class MappedCategory : IMapFrom<Category>
        {
            public string Name { get; set; }

            public string Description { get; set; }

            public string ImageUrl { get; set; }

            public string IconName { get; set; }
        }
    }
}
