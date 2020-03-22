namespace ProjectCluster.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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

            var categories = new List<(string Name, string ImageUrl)> { 
                ("Programming", "https://starkassault.files.wordpress.com/2015/06/430918.jpg"), 
                ("Cooking", "https://img1.cookinglight.timeinc.net/sites/default/files/styles/4_3_horizontal_-_1200x900/public/image/2017/04/main/roasted-chili-verde-chicken-enchiladas-1706p56.jpg?itok=Ha6DQK9E"),
                ("Gardening", "https://fthmb.tqn.com/id5y0mpf2cwR1hXGJiEwQrPn9sQ=/1600x1200/filters:fill(auto,1)/Container-Vegetables-5735ac1e3df78c6bb0bfbf63.jpg"),
                ("Music", "https://www.pixelstalk.net/wp-content/uploads/2016/09/Acoustic-Guitar-Desktop-Background.jpg"),
                //change images down
                ("Writing", "https://miro.medium.com/max/4000/1*roqF8yyhOkBXBhCBH5oWqw.jpeg"),
                ("Crafts", "https://lh3.googleusercontent.com/proxy/Ak4VRtUEcQ6R0cIV_LpZQ5rejLU6PV1GMsDuWPTpC1J7xdotWC4lhSOAsaJxwhFwVA0iYrlnGl-W6MiE2CldC6iNPnvy0O4Elz5k6Dmyi41aN5Cq9HXEIUn9CjNWHhXAWMTi"),
                ("Engineering", "https://vesterm.com/wp-content/uploads/2018/10/mechanical-engineering.jpg"),
                ("Art", "https://artistresidencythailand.com/wp-content/uploads/2019/10/slider-01-1920x960.jpg"),
                ("Science", "https://www.scienceabc.com/wp-content/uploads/2017/05/Rocket-flying-in-space.jpg"),
                //not cars
                ("Cars", "https://s1.cdn.autoevolution.com/images/gallery/BMW-3-Series--E46--3622_23.jpg"),
                //change these too
                ("Building", "https://www.homestratosphere.com/wp-content/uploads/2018/10/laying-bricks-100218-min.jpg"),
                ("Photography", "https://s23527.pcdn.co/wp-content/uploads/2019/01/photographer-1867699_1920-745x511.jpg.optimal.jpg"),
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
