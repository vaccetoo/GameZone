namespace GameZone.Common.Constants
{
    public static class ValidationConstants
    {
        // Game validation constants
        public const int GameTitleMinLength = 2;
        public const int GameTitleMaxLength = 50;

        public const int GameDescriptionMinLength = 10;  
        public const int GameDescriptionMaxLength = 500;

        // Genre validation constants
        public const int GenreNameMinLength = 3;   
        public const int GenreNameMaxLength = 25;

        // Common validation constants
        public const string DateTimeFormat = "yyyy-MM-dd";
    }
}
