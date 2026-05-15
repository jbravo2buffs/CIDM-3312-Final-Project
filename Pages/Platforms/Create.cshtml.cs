using CIDM_3312_Final_Project.Data;
using CIDM_3312_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIDM_3312_Final_Project.Pages.Platforms
{
    public class CreateModel : PageModel
    {
        private readonly GameVaultContext _context;

        public CreateModel(GameVaultContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Platform Platform { get; set; } = new();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Platforms.Add(Platform);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
