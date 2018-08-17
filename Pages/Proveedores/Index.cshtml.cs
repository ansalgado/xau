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
    public class IndexModel : PageModel
    {
        private readonly xau.Models.XauContext _context;

        public IndexModel(xau.Models.XauContext context)
        {
            _context = context;
        }

        public IList<Proveedor> Proveedor { get;set; }

        public async Task OnGetAsync()
        {
            Proveedor = await _context.Proveedor.ToListAsync();
        }
    }
}
