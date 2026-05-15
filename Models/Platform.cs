using System.ComponentModel.DataAnnotations;

namespace CIDM_3312_Final_Project.Models
{
    public class Platform
    {
        public int PlatformId { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string? Name { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string? Company { get; set; }

        [Display(Name = "Console Type")]
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string? ConsoleType { get; set; }

        public List<Game> Games { get; set; } = new();
    }
}
