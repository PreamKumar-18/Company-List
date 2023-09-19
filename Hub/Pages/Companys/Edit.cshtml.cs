using Hub.Data;
using Hub.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hub.Pages.Companys
{
    [BindProperties]
    public class EditModel : PageModel
    {

        private readonly ApplicationDbContext _dbContext;

        public EditModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public Company Company { get; set; }
        public void OnGet(int id)
        {
            Company = _dbContext.Companies.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                   _dbContext.Companies.Update(Company);
                    _dbContext.SaveChanges();



                return RedirectToPage("Index");

            }
            return Page();
        }
    }
}
