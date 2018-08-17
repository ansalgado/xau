using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using xau.Models;

namespace xau.Pages.Entregas
{
    public class CreateModel : PageModel
    {
        private readonly xau.Models.XauContext _context;

        public CreateModel(xau.Models.XauContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Entrega Entrega { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Entrega.Add(Entrega);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}