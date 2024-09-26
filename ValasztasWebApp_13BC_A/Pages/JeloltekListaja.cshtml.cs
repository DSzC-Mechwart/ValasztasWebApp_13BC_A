using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ValasztasWebApp_13BC_A.Models;

namespace ValasztasWebApp_13BC_A.Pages
{
    public class JeloltekListajaModel : PageModel
    {
        private readonly ValasztasWebApp_13BC_A.Models.ValasztasDbContext _context;

        public JeloltekListajaModel(ValasztasWebApp_13BC_A.Models.ValasztasDbContext context)
        {
            _context = context;
        }

        public IList<Jelolt> Jelolt { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Jelolt = await _context.Jeloltek
                .Include(j => j.Part).ToListAsync();
        }
    }
}
