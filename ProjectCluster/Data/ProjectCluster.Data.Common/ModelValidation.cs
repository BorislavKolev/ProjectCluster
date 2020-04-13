namespace ProjectCluster.Data.Common
{
    public class ModelValidation
    {
        public static class Project
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 60;

            public const int ContentMinLength = 50;
            public const int ContentMaxLength = int.MaxValue;

            public const string PicturesDisplayName = "Pictures";

            public const string CategoryIdDisplayName = "Category";

            public const string ProjectStatusDisplayName = "Project Status";

            public const string ProgressDisplayName = "Progress Percentage";

            public const string EmptyTitleError = "Please enter project title.";
            public const string TitleLengthError = "Title should be between 10 and 60 symbols.";

            public const string EmptyContentError = "Please enter project description";
            public const string ContentLengthError = "Project description should be at least 50 symbols long.";

            public const string EmptyPicturesError = "Please add at least one picture.";

            public const string EmptyCategoryError = "Please choose a category.";

            public const string EmptyProjectStatusError = "Please choose project status.";

            public const string EmptyProgressError = "Please enter project progress";
        }
    }
}
