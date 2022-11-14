using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportApp.Models;

namespace SportApp.Pages.ExamType
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
        public Models.ExamType examType  { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _context.ExamTypes.AddAsync(examType);
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}
