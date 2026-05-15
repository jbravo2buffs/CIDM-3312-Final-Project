using CIDM_3312_Final_Project.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CIDM_3312_Final_Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly GameVaultContext _context;

        public IndexModel(GameVaultContext context)
        {
            _context = context;
        }

        public int GameCount { get; set; }
        public int PlatformCount { get; set; }
        public int ReviewCount { get; set; }
        public double AverageScore { get; set; }

        public async Task OnGetAsync()
        {
            GameCount = await _context.Games.CountAsync();
            PlatformCount = await _context.Platforms.CountAsync();
            ReviewCount = await _context.Reviews.CountAsync();

            if (ReviewCount > 0)
            {
                AverageScore = await _context.Reviews.AverageAsync(r => r.Score);
            }
        }
    }
}
