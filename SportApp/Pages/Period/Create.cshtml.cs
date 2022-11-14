using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportApp.Models;

namespace SportApp.Pages.Period
{
    public class CreateModel : PageModel
    {
        SportDBContext _context;

        public CreateModel()
        {
            _context = new SportDBContext();
            _context.Database.EnsureCreated();
        }

        [BindProperty]
        public Models.Period period { get; set; }

        public void OnGet()
        {
            ViewData["Group"] = new SelectList(_context.Groups, "Id", "Name");
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _context.Periods.AddAsync(period);
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}
