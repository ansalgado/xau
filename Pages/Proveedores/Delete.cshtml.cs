using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using xau.Models;

namespace xau.Pages.Proveedores
{
    public class DeleteModel : PageModel
    {
        private readonly xau.Models.XauContext _context;

        public DeleteModel(xau.Models.XauContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Proveedor Proveedor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Proveedor = await _context.Proveedor.FirstOrDefaultAsync(m => m.ID == id);

            if (Proveedor == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Proveedor = await _context.Proveedor.FindAsync(id);

            if (Proveedor != null)
            {
                _context.Proveedor.Remove(Proveedor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
