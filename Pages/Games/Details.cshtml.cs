using CIDM_3312_Final_Project.Data;
using CIDM_3312_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CIDM_3312_Final_Project.Pages.Games
{
    public class DetailsModel : PageModel
    {
        private readonly GameVaultContext _context;

        public DetailsModel(GameVaultContext context)
        {
            _context = context;
        }

        public Game Game { get; set; } = new();

        [BindProperty]
        public Review NewReview { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var game = await _context.Games
                .Include(g => g.Platform)
                .Include(g => g.Reviews)
                .FirstOrDefaultAsync(g => g.GameId == id);

            if (game == null)
            {
                return NotFound();
            }

            Game = game;
            Game.Reviews = Game.Reviews.OrderByDescending(r => r.DatePosted).ToList();

            NewReview.GameId = id;
            NewReview.DatePosted = DateTime.Today;

            return Page();
        }

        public async Task<IActionResult> OnPostAddReviewAsync(int id)
        {
            NewReview.GameId = id;

            if (!ModelState.IsValid)
            {
                return await OnGetAsync(id);
            }

            _context.Reviews.Add(NewReview);
            await _context.SaveChangesAsync();

            return RedirectToPage("Details", new { id });
        }
    }
}
