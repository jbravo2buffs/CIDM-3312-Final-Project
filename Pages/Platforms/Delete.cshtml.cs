using CIDM_3312_Final_Project.Data;
using CIDM_3312_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIDM_3312_Final_Project.Pages.Platforms
{
    public class DeleteModel : PageModel
    {
        private readonly GameVaultContext _context;

        public DeleteModel(GameVaultContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Platform Platform { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var platform = await _context.Platforms.FindAsync(id);
            if (platform == null)
            {
                return NotFound();
            }

            Platform = platform;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var platform = await _context.Platforms.FindAsync(Platform.PlatformId);
            if (platform != null)
            {
                _context.Platforms.Remove(platform);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
