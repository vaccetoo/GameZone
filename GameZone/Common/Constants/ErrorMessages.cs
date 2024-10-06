using static GameZone.Common.Constants.ValidationConstants;

namespace GameZone.Common.Constants
    
{
    public static class ErrorMessages
    {
        // GameViewModel error messages
        public const string RequiredErrorMessage = "The {0} field is required !";
        public const string StringLengthErrorMessage = "The {0} field must be between {2} and {1} symbols !";

        // Invalid date error message
        public const string InvalidDateErrorMessage = $"Invalid date format ! Format must be : {DateTimeFormat}";
    }
}
