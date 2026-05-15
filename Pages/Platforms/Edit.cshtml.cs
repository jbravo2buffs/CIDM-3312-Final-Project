using CIDM_3312_Final_Project.Data;
using CIDM_3312_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CIDM_3312_Final_Project.Pages.Platforms
{
    public class EditModel : PageModel
    {
        private readonly GameVaultContext _context;

        public EditModel(GameVaultContext context)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Platform).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
