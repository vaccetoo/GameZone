using System.ComponentModel.DataAnnotations;
using static GameZone.Common.Constants.ValidationConstants;

namespace GameZone.Data.Models
{
    public class Genre
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<Game> Games { get; set; } = new List<Game>();
    }
}