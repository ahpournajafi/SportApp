using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportApp.Models;

namespace SportApp.Pages.Group
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
        public Models.Group group { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}
