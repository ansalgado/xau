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
    public class IndexModel : PageModel
    {
        private readonly xau.Models.XauContext _context;

        public IndexModel(xau.Models.XauContext context)
        {
            _context = context;
        }

        public IList<Recolector> Recolector { get;set; }

        public async Task OnGetAsync()
        {
            Recolector = await _context.Recolector.ToListAsync();
        }
    }
}
