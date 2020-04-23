namespace ProjectCluster.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using ProjectCluster.Data.Models;

    public class CommentsSeeder : ISeeder
    {
        static Random random = new Random();

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (dbContext.Comments.Any())
            {
                return;
            }

            var comments = new List<Comment>();
            var userIds = userManager.Users.Where(x => x.UserName != "Admin").Select(x => x.Id).ToList();

            foreach (var project in dbContext.Projects)
            {
                var comment1 = new Comment
                {
                    ProjectId = project.Id,
                    UserId = userIds[random.Next(userIds.Count())],
                    Content = "Thats an amazing project!",
                };
                var comment2 = new Comment
                {
                    ProjectId = project.Id,
                    UserId = userIds[random.Next(userIds.Count())],
                    Content = "Looks awesome!",
                };
                var comment3 = new Comment
                {
                    ProjectId = project.Id,
                    UserId = userIds[random.Next(userIds.Count())],
                    Content = "Great work!",
                };

                comments.Add(comment1);
                comments.Add(comment2);
                comments.Add(comment3);
            }

            foreach (var comment in comments)
            {
                await dbContext.Comments.AddAsync(comment);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
