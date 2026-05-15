using CIDM_3312_Final_Project.Data;
using CIDM_3312_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CIDM_3312_Final_Project.Pages.Reviews
{
    public class EditModel : PageModel
    {
        private readonly GameVaultContext _context;

        public EditModel(GameVaultContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review { get; set; } = new();

        public SelectList GameOptions { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            Review = review;
            GameOptions = new SelectList(_context.Games.OrderBy(g => g.Title), "GameId", "Title");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                GameOptions = new SelectList(_context.Games.OrderBy(g => g.Title), "GameId", "Title");
                return Page();
            }

            _context.Attach(Review).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
