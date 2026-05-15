using CIDM_3312_Final_Project.Data;
using CIDM_3312_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CIDM_3312_Final_Project.Pages.Reviews
{
    public class DeleteModel : PageModel
    {
        private readonly GameVaultContext _context;

        public DeleteModel(GameVaultContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var review = await _context.Reviews
                .Include(r => r.Game)
                .FirstOrDefaultAsync(r => r.ReviewId == id);

            if (review == null)
            {
                return NotFound();
            }

            Review = review;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var review = await _context.Reviews.FindAsync(Review.ReviewId);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
