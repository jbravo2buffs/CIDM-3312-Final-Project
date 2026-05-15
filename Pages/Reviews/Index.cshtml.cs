using CIDM_3312_Final_Project.Data;
using CIDM_3312_Final_Project.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CIDM_3312_Final_Project.Pages.Reviews
{
    public class IndexModel : PageModel
    {
        private readonly GameVaultContext _context;

        public IndexModel(GameVaultContext context)
        {
            _context = context;
        }

        public List<Review> Reviews { get; set; } = new();

        public async Task OnGetAsync()
        {
            Reviews = await _context.Reviews
                .Include(r => r.Game)
                .ThenInclude(g => g!.Platform)
                .OrderByDescending(r => r.DatePosted)
                .ToListAsync();
        }
    }
}
