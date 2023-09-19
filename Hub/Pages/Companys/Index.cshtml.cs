using Hub.Data;
using Hub.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hub.Pages.Companys
{
    [BindProperties]
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _dbContext;

         public IndexModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Company> Companies { get; set; }
        public void OnGet()
          {
            Companies = _dbContext.Companies.ToList();

        }
    }
}
