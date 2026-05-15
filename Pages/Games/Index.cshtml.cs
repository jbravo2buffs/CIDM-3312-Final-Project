using CIDM_3312_Final_Project.Data;
using CIDM_3312_Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CIDM_3312_Final_Project.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly GameVaultContext _context;
        private const int PageSize = 10;

        public IndexModel(GameVaultContext context)
        {
            _context = context;
        }

        public List<Game> Games { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; } = "title_asc";

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int TotalPages { get; set; }

        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;

        public async Task OnGetAsync()
        {
            var gamesQuery = _context.Games
                .Include(g => g.Platform)
                .Include(g => g.Reviews)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchString))
            {
                gamesQuery = gamesQuery.Where(g =>
                    (g.Title != null && g.Title.Contains(SearchString)) ||
                    (g.Genre != null && g.Genre.Contains(SearchString)) ||
                    (g.Status != null && g.Status.Contains(SearchString)) ||
                    (g.Platform != null && g.Platform.Name != null && g.Platform.Name.Contains(SearchString)));
            }

            if (SortOrder == "title_desc")
            {
                gamesQuery = gamesQuery.OrderByDescending(g => g.Title);
            }
            else if (SortOrder == "rating_asc")
            {
                gamesQuery = gamesQuery.OrderBy(g => g.Rating);
            }
            else if (SortOrder == "rating_desc")
            {
                gamesQuery = gamesQuery.OrderByDescending(g => g.Rating);
            }
            else if (SortOrder == "year_asc")
            {
                gamesQuery = gamesQuery.OrderBy(g => g.ReleaseYear);
            }
            else if (SortOrder == "year_desc")
            {
                gamesQuery = gamesQuery.OrderByDescending(g => g.ReleaseYear);
            }
            else if (SortOrder == "status_asc")
            {
                gamesQuery = gamesQuery.OrderBy(g => g.Status);
            }
            else if (SortOrder == "status_desc")
            {
                gamesQuery = gamesQuery.OrderByDescending(g => g.Status);
            }
            else
            {
                gamesQuery = gamesQuery.OrderBy(g => g.Title);
            }

            var totalRecords = await gamesQuery.CountAsync();
            TotalPages = (int)Math.Ceiling(totalRecords / (double)PageSize);

            if (PageNumber < 1)
            {
                PageNumber = 1;
            }

            if (TotalPages > 0 && PageNumber > TotalPages)
            {
                PageNumber = TotalPages;
            }

            Games = await gamesQuery
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }
    }
}
