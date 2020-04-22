namespace ProjectCluster.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ProjectCluster.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = new List<Category>();

            var animals = new Category
            {
                Name = "Animals",
                Description = "Animals",
                IconName = "fas fa-paw",
                ImageUrl = "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1587585871/Categories/adorable-animal-blur-cat-617278_bnd8bf.jpg",
            };
            categories.Add(animals);
            var art = new Category
            {
                Name = "Art",
                Description = "Art",
                IconName = "fas fa-palette",
                ImageUrl = "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958919/Categories/art_iac8id.jpg",
            };
            categories.Add(art);
            var cars = new Category
            {
                Name = "Cars",
                Description = "Cars",
                IconName = "fas fa-car",
                ImageUrl = "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958937/Categories/cars_cnn2wn.jpg",
            };
            categories.Add(cars);
            var diy = new Category
            {
                Name = "DIY",
                Description = "DIY",
                IconName = "fas fa-pencil-ruler",
                ImageUrl = "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958933/Categories/crafts_tfvgs1.jpg",
            };
            categories.Add(diy);
            var food = new Category
            {
                Name = "Food",
                Description = "Food",
                IconName = "fas fa-utensils",
                ImageUrl = "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958941/Categories/cooking_gryjkx.jpg",
            };
            categories.Add(food);
            var gaming = new Category
            {
                Name = "Gaming",
                Description = "Gaming",
                IconName = "fas fa-gamepad",
                ImageUrl = "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1587585851/Categories/accessory-buttons-console-control-275033_vnlchc.jpg",
            };
            categories.Add(gaming);
            var gardening = new Category
            {
                Name = "Gardening",
                Description = "Gardening",
                IconName = "fas fa-seedling",
                ImageUrl = "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958948/Categories/gardening_bmygxl.jpg",
            };
            categories.Add(gardening);
            var music = new Category
            {
                Name = "Music",
                Description = "Music",
                IconName = "fas fa-music",
                ImageUrl = "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958984/Categories/music_tb5gav.jpg",
            };
            categories.Add(music);
            var photography = new Category
            {
                Name = "Photography",
                Description = "Photography",
                IconName = "fas fa-camera",
                ImageUrl = "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958923/Categories/photography_kmzfvk.jpg",
            };
            categories.Add(photography);
            var programming = new Category
            {
                Name = "Programming",
                Description = "Programming",
                IconName = "fas fa-code",
                ImageUrl = "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958936/Categories/programming_lod35x.jpg",
            };
            categories.Add(programming);
            var videography = new Category
            {
                Name = "Videography",
                Description = "Videography",
                IconName = "fas fa-film",
                ImageUrl = "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1587585844/Categories/man-holding-clapper-board-1117132_kljk1p.jpg",
            };
            categories.Add(videography);
            var writing = new Category
            {
                Name = "Writing",
                Description = "Writing",
                IconName = "fas fa-book",
                ImageUrl = "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958950/Categories/writing_dmul23.jpg",
            };
            categories.Add(writing);

            foreach (var category in categories)
            {
                await dbContext.Categories.AddAsync(category);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
