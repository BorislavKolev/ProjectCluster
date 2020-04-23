namespace ProjectCluster.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ProjectCluster.Data.Models;

    public class ProjectPicturesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ProjectPictures.Any())
            {
                return;
            }

            var projectPictures = new List<ProjectPicture>();

            foreach (var project in dbContext.Projects)
            {
                var projectPicture1 = new ProjectPicture
                {
                    ProjectId = project.Id,
                    PictureUrl = project.ImageUrl,
                };
                var projectPicture2 = new ProjectPicture
                {
                    ProjectId = project.Id,
                    PictureUrl = "https://res.cloudinary.com/sharwinchester/image/upload/c_fill,h_600,w_1200/v1587604993/kelly-sikkema-NBkMT8duVSI-unsplash_py5fkm.jpg",
                };
                projectPictures.Add(projectPicture1);
                projectPictures.Add(projectPicture2);
            }

            foreach (var projectPicture in projectPictures)
            {
                await dbContext.ProjectPictures.AddAsync(projectPicture);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
