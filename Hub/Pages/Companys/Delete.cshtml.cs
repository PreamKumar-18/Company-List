using Hub.Data;
using Hub.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Hub.Pages.Companys
{
    [BindProperties]
    public class DeleteModel : PageModel
    {

        private readonly ApplicationDbContext _dbContext;

        public DeleteModel(ApplicationDbContext dbContext)
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
            var objFromDb = _dbContext.Companies.FirstOrDefault(x =>x.Id == Company.Id);

            if(objFromDb != null)
            {
                _dbContext.Remove(objFromDb);
                _dbContext.SaveChanges();



                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
