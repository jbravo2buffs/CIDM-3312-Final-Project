using System.ComponentModel.DataAnnotations;

namespace CIDM_3312_Final_Project.Models
{
    public class Game
    {
        public int GameId { get; set; }

        [Display(Name = "Platform")]
        [Required]
        public int PlatformId { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string? Title { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 2)]
        public string? Genre { get; set; }

        [Display(Name = "Release Year")]
        [Range(1970, 2035)]
        public int ReleaseYear { get; set; }

        [Range(0, 10)]
        public decimal Rating { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string? Status { get; set; }

        public Platform? Platform { get; set; }

        public List<Review> Reviews { get; set; } = new();
    }
}
