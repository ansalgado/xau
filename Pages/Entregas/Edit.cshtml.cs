using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using xau.Models;

namespace xau.Pages.Entregas
{
    public class EditModel : PageModel
    {
        private readonly xau.Models.XauContext _context;

        public EditModel(xau.Models.XauContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Entrega Entrega { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entrega = await _context.Entrega.FirstOrDefaultAsync(m => m.ID == id);

            if (Entrega == null)
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

            _context.Attach(Entrega).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntregaExists(Entrega.ID))
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

        private bool EntregaExists(int id)
        {
            return _context.Entrega.Any(e => e.ID == id);
        }
    }
}
