using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using xau.Models;

namespace xau.Pages.Recolectores
{
    public class EditModel : PageModel
    {
        private readonly xau.Models.XauContext _context;

        public EditModel(xau.Models.XauContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Recolector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecolectorExists(Recolector.ID))
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

        private bool RecolectorExists(int id)
        {
            return _context.Recolector.Any(e => e.ID == id);
        }
    }
}
