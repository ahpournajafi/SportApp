using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportApp.Models;

namespace SportApp.Pages.Person
{



    public class IndexModel : PageModel
    {

        SportDBContext _context;

        public IndexModel()
        {
            _context = new SportDBContext();
            _context.Database.EnsureCreated();
        }

        
        public List<Models.Person> people { get; set; }


        public async Task OnGet()
        {
        }

        public async Task<JsonResult> OnGetJson(int groupId, int subgroupId)
        {
            var _people = await _context.People.Where(a => a.GroupId.Equals(groupId) && a.SubgroupId.Equals(subgroupId)).Select(a => new PersonDto { Id = a.Id, Fname = a.Fname, Lname = a.Lname, NationCode = a.Uniquecode}).ToListAsync();
            return new JsonResult(new { data = _people });
        }

        public class PersonDto
        {
            public long Id { get; set; }
            public string Fname { get; set; }
            public string Lname { get; set; }
            public string NationCode { get; set; }
        }
    }
}
