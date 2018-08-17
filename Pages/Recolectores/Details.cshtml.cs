using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using xau.Models;

namespace xau.Pages.Recolectores
{
    public class DetailsModel : PageModel
    {
        private readonly xau.Models.XauContext _context;

        public DetailsModel(xau.Models.XauContext context)
        {
            _context = context;
        }

        public Recolector Recolector { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recolector = await _context.Recolector.FirstOrDefaultAsync(m => m.ID == id);

            if (Recolector == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
