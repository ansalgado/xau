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
    public class DeleteModel : PageModel
    {
        private readonly xau.Models.XauContext _context;

        public DeleteModel(xau.Models.XauContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Entrega = await _context.Entrega.FindAsync(id);

            if (Entrega != null)
            {
                _context.Entrega.Remove(Entrega);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
