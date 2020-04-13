namespace ProjectCluster.Data.Common
{
    public class DataValidation
    {
        public static class Category
        {
            public const int NameMaxLength = 15;
            public const int DescriptionMaxLength = 50;
        }

        public static class Project
        {
            public const int TitleMaxLength = 60;
            public const double ProgressMinValue = 0;
            public const double ProgressMaxValue = 100;
        }

        public static class Rating
        {
            public const double RateMinValue = 1;
            public const double RateMaxValue = 5;
        }
    }
}
