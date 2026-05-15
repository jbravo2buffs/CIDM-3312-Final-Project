using CIDM_3312_Final_Project.Data;
using CIDM_3312_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CIDM_3312_Final_Project.Pages.Platforms
{
    public class DetailsModel : PageModel
    {
        private readonly GameVaultContext _context;

        public DetailsModel(GameVaultContext context)
        {
            _context = context;
        }

        public Platform Platform { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var platform = await _context.Platforms
                .Include(p => p.Games)
                .FirstOrDefaultAsync(p => p.PlatformId == id);

            if (platform == null)
            {
                return NotFound();
            }

            Platform = platform;
            Platform.Games = Platform.Games.OrderBy(g => g.Title).ToList();

            return Page();
        }
    }
}
