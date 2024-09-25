using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ValasztasWebApp_13BC_A.Models;

namespace ValasztasWebApp_13BC_A.Pages
{
    public class AdatokFeltolteseFajlbolModel : PageModel
    {
        private readonly IWebHostEnvironment _env;
        private readonly ValasztasDbContext _context;

        public AdatokFeltolteseFajlbolModel(IWebHostEnvironment env,
            ValasztasDbContext context)
        {
            _context = context;
            _env = env;
        }

        [BindProperty]
        public IFormFile UploadFile { get; set; }
        
               
        
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //Fájl feltöltése
            var UploadFilePath = 
                Path.Combine(_env.ContentRootPath,"uploads",UploadFile.FileName);

            using ( var stream = new FileStream(UploadFilePath, FileMode.Create))
            {
                await UploadFile.CopyToAsync(stream);
            }
            //Adatbázisba töltés
            StreamReader sr = new StreamReader(UploadFilePath);
            //....
            sr.Close();

            return Page();
        }

    }
}
