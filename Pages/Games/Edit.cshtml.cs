using CIDM_3312_Final_Project.Data;
using CIDM_3312_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CIDM_3312_Final_Project.Pages.Games
{
    public class EditModel : PageModel
    {
        private readonly GameVaultContext _context;

        public EditModel(GameVaultContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Game Game { get; set; } = new();

        public SelectList PlatformOptions { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            Game = game;
            PlatformOptions = new SelectList(_context.Platforms.OrderBy(p => p.Name), "PlatformId", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PlatformOptions = new SelectList(_context.Platforms.OrderBy(p => p.Name), "PlatformId", "Name");
                return Page();
            }

            _context.Attach(Game).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
