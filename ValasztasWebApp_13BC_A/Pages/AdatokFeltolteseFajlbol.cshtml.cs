using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
            sr.ReadLine();
            List<Part> partok = _context.Partok.ToList();
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var elemek = line.Split();
                Jelolt ujJelolt = new Jelolt();
                ujJelolt.Kerulet = int.Parse(elemek[0]);
                ujJelolt.SzavazatokSzama = int.Parse(elemek[1]);
                ujJelolt.Nev = elemek[2] + " " + elemek[3];
                ujJelolt.PartRovidNev = elemek[4];
                if(!partok.Select(x => x.RovidNev).Contains(elemek[4]))
                {
                    _context.Partok.Add(new Part { RovidNev = elemek[4] });
                    partok.Add(new Part { RovidNev = elemek[4] });
                }
                _context.Jeloltek.Add(ujJelolt);
            }

            sr.Close();           


            _context.SaveChanges();

            return Page();
        }

    }
}
