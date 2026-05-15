using CIDM_3312_Final_Project.Data;
using CIDM_3312_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CIDM_3312_Final_Project.Pages.Games
{
    public class CreateModel : PageModel
    {
        private readonly GameVaultContext _context;

        public CreateModel(GameVaultContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Game Game { get; set; } = new();

        public SelectList PlatformOptions { get; set; } = default!;

        public void OnGet()
        {
            PlatformOptions = new SelectList(_context.Platforms.OrderBy(p => p.Name), "PlatformId", "Name");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PlatformOptions = new SelectList(_context.Platforms.OrderBy(p => p.Name), "PlatformId", "Name");
                return Page();
            }

            _context.Games.Add(Game);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
