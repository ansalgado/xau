using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using xau.Models;

namespace xau.Pages.Proveedores
{
    public class EditModel : PageModel
    {
        private readonly xau.Models.XauContext _context;

        public EditModel(xau.Models.XauContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Proveedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorExists(Proveedor.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProveedorExists(int id)
        {
            return _context.Proveedor.Any(e => e.ID == id);
        }
    }
}
