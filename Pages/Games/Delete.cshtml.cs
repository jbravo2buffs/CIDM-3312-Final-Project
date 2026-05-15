using CIDM_3312_Final_Project.Data;
using CIDM_3312_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CIDM_3312_Final_Project.Pages.Games
{
    public class DeleteModel : PageModel
    {
        private readonly GameVaultContext _context;

        public DeleteModel(GameVaultContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Game Game { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var game = await _context.Games.Include(g => g.Platform).FirstOrDefaultAsync(g => g.GameId == id);
            if (game == null)
            {
                return NotFound();
            }

            Game = game;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var game = await _context.Games.FindAsync(Game.GameId);
            if (game != null)
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
