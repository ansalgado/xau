using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using xau.Models;

namespace xau.Pages.Entregas
{
    public class DetailsModel : PageModel
    {
        private readonly xau.Models.XauContext _context;

        public DetailsModel(xau.Models.XauContext context)
        {
            _context = context;
        }

        public Entrega Entrega { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entrega = await _context.Entrega.FirstOrDefaultAsync(m => m.ID == id);
            Entrega.Recolector = await _context.Recolector.FirstOrDefaultAsync(r => r.ID == Entrega.RecolectorID);
            Entrega.Proveedor = await _context.Proveedor.FirstOrDefaultAsync(p => p.ID == Entrega.ProveedorID);

            if (Entrega == null)
            {
                return NotFound();
            }
            return Page();
        }
        
    }
}
