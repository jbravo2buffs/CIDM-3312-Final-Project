using CIDM_3312_Final_Project.Data;
using CIDM_3312_Final_Project.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CIDM_3312_Final_Project.Pages.Platforms
{
    public class IndexModel : PageModel
    {
        private readonly GameVaultContext _context;

        public IndexModel(GameVaultContext context)
        {
            _context = context;
        }

        public List<Platform> Platforms { get; set; } = new();

        public async Task OnGetAsync()
        {
            Platforms = await _context.Platforms
                .Include(p => p.Games)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }
    }
}
