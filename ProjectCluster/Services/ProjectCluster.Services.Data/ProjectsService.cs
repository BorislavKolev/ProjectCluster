namespace ProjectCluster.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ProjectCluster.Data.Common.Repositories;
    using ProjectCluster.Data.Models;
    using ProjectCluster.Data.Models.Enums;
    using ProjectCluster.Services.Mapping;
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

        public async Task<int> CreateAsync(int categoryId, string content, string title, string projectStatus, double progress, string userId, List<string> imageUrls)
        {
            var project = new Project
            {
                CategoryId = categoryId,
                Content = content,
                Title = title,
                ProjectStatus = (ProjectStatus)Enum.Parse(typeof(ProjectStatus), projectStatus),
                Progress = projectStatus == "Finished" ? 100 : progress,
                UserId = userId,
                ImageUrl = imageUrls.First().Insert(54, "c_fill,h_600,w_1200/"),
            };

            await this.projectsRepository.AddAsync(project);
            await this.projectsRepository.SaveChangesAsync();

            foreach (var url in imageUrls)
            {
                var projectPicture = new ProjectPicture
                {
                    PictureUrl = url.Insert(54, "c_fill,h_600,w_1200/"),
                    ProjectId = project.Id,
                };

                await this.projectPicturesRepository.AddAsync(projectPicture);
                await this.projectPicturesRepository.SaveChangesAsync();
            }

            return project.Id;
        }

        public IEnumerable<T> GetByCategoryId<T>(int categoryId, int? take = null, int skip = 0)
        {
            var query = this.projectsRepository
                .All()
                .OrderByDescending(x => x.CreatedOn)
                .Where(x => x.CategoryId == categoryId)
                .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var project = this.projectsRepository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();

            return project;
        }

        public ICollection<string> GetPictureUrls(int id)
        {
            var pictureUrls = this.projectPicturesRepository
                .All()
                .Where(x => x.ProjectId == id)
                .Select(u => u.PictureUrl)
                .ToList();

            return pictureUrls;
        }

        public int GetProjectsCountByCaregoryId(int categoryId)
        {
            return this.projectsRepository.All().Count(x => x.CategoryId == categoryId);
        }
    }
}
