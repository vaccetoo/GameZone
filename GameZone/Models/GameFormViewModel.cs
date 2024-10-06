using System.ComponentModel.DataAnnotations;
using static GameZone.Common.Constants.ValidationConstants;
using static GameZone.Common.Constants.ErrorMessages;
namespace GameZone.Models
{
    public class GameFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(GameTitleMaxLength, MinimumLength = GameTitleMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Title { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(GameDescriptionMaxLength, MinimumLength = GameDescriptionMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string? ReleasedOn { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public int GenreId { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();
    }
}
