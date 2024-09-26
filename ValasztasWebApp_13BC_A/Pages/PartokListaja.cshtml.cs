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
    public class PartokListajaModel : PageModel
    {
        private readonly ValasztasWebApp_13BC_A.Models.ValasztasDbContext _context;

        public PartokListajaModel(ValasztasWebApp_13BC_A.Models.ValasztasDbContext context)
        {
            _context = context;
        }

        public IList<Part> Part { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Part = await _context.Partok.ToListAsync();
        }
    }
}
