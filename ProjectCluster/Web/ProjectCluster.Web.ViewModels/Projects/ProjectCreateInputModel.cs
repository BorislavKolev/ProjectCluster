namespace ProjectCluster.Web.ViewModels.Projects
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    using static ProjectCluster.Data.Common.ModelValidation.Project;

    public class ProjectCreateInputModel
    {
        [Required(ErrorMessage = EmptyTitleError)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = TitleLengthError)]
        public string Title { get; set; }

        [Required(ErrorMessage = EmptyContentError)]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength, ErrorMessage = ContentLengthError)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required(ErrorMessage = EmptyPicturesError)]
        [Display(Name = PicturesDisplayName)]
        public ICollection<IFormFile> Pictures { get; set; }

        [Required(ErrorMessage = EmptyCategoryError)]
        [Display(Name = CategoryIdDisplayName)]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = EmptyProjectStatusError)]
        [Display(Name = ProjectStatusDisplayName)]
        public string ProjectStatus { get; set; }

        [Required(ErrorMessage = EmptyProgressError)]
        [Display(Name = ProgressDisplayName)]
        public double Progress { get; set; }

        public IEnumerable<CategoryDropdownViewModel> Categories { get; set; }
    }
}
