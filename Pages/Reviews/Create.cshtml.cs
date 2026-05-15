using CIDM_3312_Final_Project.Data;
using CIDM_3312_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CIDM_3312_Final_Project.Pages.Reviews
{
    public class CreateModel : PageModel
    {
        private readonly GameVaultContext _context;

        public CreateModel(GameVaultContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review { get; set; } = new() { DatePosted = DateTime.Today };

        public SelectList GameOptions { get; set; } = default!;

        public void OnGet()
        {
            GameOptions = new SelectList(_context.Games.OrderBy(g => g.Title), "GameId", "Title");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                GameOptions = new SelectList(_context.Games.OrderBy(g => g.Title), "GameId", "Title");
                return Page();
            }

            _context.Reviews.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
