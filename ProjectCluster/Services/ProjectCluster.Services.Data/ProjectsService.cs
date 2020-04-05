namespace ProjectCluster.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProjectCluster.Data.Common.Repositories;
    using ProjectCluster.Data.Models;
    using ProjectCluster.Data.Models.Enums;
    using ProjectCluster.Web.ViewModels.Projects;

    public class ProjectsService : IProjectsService
    {
        private readonly IDeletableEntityRepository<Project> projectsRepository;
        private readonly IDeletableEntityRepository<ProjectPicture> projectPicturesRepository;

        public ProjectsService(IDeletableEntityRepository<Project> projectsRepository, IDeletableEntityRepository<ProjectPicture> projectPicturesRepository)
        {
            this.projectsRepository = projectsRepository;
            this.projectPicturesRepository = projectPicturesRepository;
        }

        public async Task<int> CreateAsync(ProjectCreateInputModel input, string userId, List<string> imageUrls)
        {
            var project = new Project
            {
                CategoryId = input.CategoryId,
                Content = input.Content,
                Title = input.Title,
                ProjectStatus = (ProjectStatus)Enum.Parse(typeof(ProjectStatus), input.ProjectStatus),
                Progress = input.ProjectStatus == "Finished" ? 100 : input.Progress,
                UserId = userId,
            };

            await this.projectsRepository.AddAsync(project);
            await this.projectsRepository.SaveChangesAsync();

            foreach (var url in imageUrls)
            {
                var projectPicture = new ProjectPicture
                {
                    PictureUrl = url,
                    ProjectId = project.Id,
                };

                await this.projectPicturesRepository.AddAsync(projectPicture);
                await this.projectPicturesRepository.SaveChangesAsync();
            }

            return project.Id;
        }
    }
}
