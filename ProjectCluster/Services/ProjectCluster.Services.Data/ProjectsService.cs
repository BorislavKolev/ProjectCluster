﻿namespace ProjectCluster.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using ProjectCluster.Data.Common.Repositories;
    using ProjectCluster.Data.Models;
    using ProjectCluster.Data.Models.Enums;
    using ProjectCluster.Web.ViewModels.Projects;

    public class ProjectsService : IProjectsService
    {
        private readonly IDeletableEntityRepository<Project> projectsRepository;

        public ProjectsService(IDeletableEntityRepository<Project> projectsRepository)
        {
            this.projectsRepository = projectsRepository;
        }

        public async Task<int> CreateAsync(ProjectCreateInputModel input, string userId)
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

            return project.Id;
        }
    }
}
