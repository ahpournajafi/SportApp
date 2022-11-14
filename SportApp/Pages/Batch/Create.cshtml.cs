using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportApp.Models;

namespace SportApp.Pages.Batch
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
        public Models.Batch batch { get; set; }

        public void OnGet()
        {
            ViewData["Group"] = new SelectList(_context.Groups, "Id", "Name");
            ViewData["SubGroup"] = new SelectList(_context.Subgroups, "Id", "Name");
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _context.Batches.AddAsync(batch);
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}
