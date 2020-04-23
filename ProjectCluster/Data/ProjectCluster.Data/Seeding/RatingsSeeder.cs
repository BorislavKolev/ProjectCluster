namespace ProjectCluster.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using ProjectCluster.Data.Models;

    public class RatingsSeeder : ISeeder
    {
        static Random random = new Random();

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (dbContext.Ratings.Any())
            {
                return;
            }

            var ratings = new List<Rating>();
            var userIds = userManager.Users.Where(x => x.UserName != "Admin").Select(x => x.Id).ToList();

            foreach (var project in dbContext.Projects)
            {
                var rating1 = new Rating
                {
                    ProjectId = project.Id,
                    UserId = userIds[random.Next(userIds.Count())],
                    Rate = random.Next(1, 6),
                };
                var rating2 = new Rating
                {
                    ProjectId = project.Id,
                    UserId = userIds[random.Next(userIds.Count())],
                    Rate = random.Next(1, 6),
                };
                var rating3 = new Rating
                {
                    ProjectId = project.Id,
                    UserId = userIds[random.Next(userIds.Count())],
                    Rate = random.Next(1, 6),
                };

                ratings.Add(rating1);
                ratings.Add(rating2);
                ratings.Add(rating3);
            }

            foreach (var rating in ratings)
            {
                await dbContext.Ratings.AddAsync(rating);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
