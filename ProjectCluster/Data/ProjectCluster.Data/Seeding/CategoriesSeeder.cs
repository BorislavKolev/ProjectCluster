namespace ProjectCluster.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using ProjectCluster.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            // TO DO: Seed category descriptions and icon names
            var categories = new List<(string Name, string ImageUrl)>
            {
                ("Programming", "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958936/Categories/programming_lod35x.jpg"),
                ("Cooking", "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958941/Categories/cooking_gryjkx.jpg"),
                ("Gardening", "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958948/Categories/gardening_bmygxl.jpg"),
                ("Music", "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958984/Categories/music_tb5gav.jpg"),
                ("Writing", "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958950/Categories/writing_dmul23.jpg"),
                ("Crafts", "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958933/Categories/crafts_tfvgs1.jpg"),
                ("Engineering", "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958930/Categories/engineering_dzn8kv.jpg"),
                ("Art", "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958919/Categories/art_iac8id.jpg"),
                ("Science", "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958950/Categories/science_bfq8qc.jpg"),
                ("Cars", "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958937/Categories/cars_cnn2wn.jpg"),
                ("Building", "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958936/Categories/building_heohtl.jpg"),
                ("Photography", "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_370,w_590/v1584958923/Categories/photography_kmzfvk.jpg"),
            };

            foreach (var category in categories)
            {
                await dbContext.Categories.AddAsync(new Category
                {
                    Name = category.Name,
                    Description = category.Name,
                    ImageUrl = category.ImageUrl,
                });
            }

            dbContext.SaveChanges();
        }
    }
}
