using System.ComponentModel.DataAnnotations;

namespace CIDM_3312_Final_Project.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        [Display(Name = "Game")]
        [Required]
        public int GameId { get; set; }

        [Display(Name = "Reviewer Name")]
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string? ReviewerName { get; set; }

        [Range(1, 10)]
        public int Score { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 5)]
        public string? Comment { get; set; }

        [Display(Name = "Date Posted")]
        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; } = DateTime.Today;

        public Game? Game { get; set; }
    }
}
