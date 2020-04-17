namespace ProjectCluster.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using static ProjectCluster.Data.Common.ModelValidation.Comment;

    public class CreateCommentInputModel
    {
        [Required(ErrorMessage = EmptyProjectIdError)]
        public int ProjectId { get; set; }

        public int ParentId { get; set; }

        [Required(ErrorMessage = ContentError)]
        [DataType(DataType.MultilineText)]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength, ErrorMessage = ContentError)]
        public string Content { get; set; }
    }
}
