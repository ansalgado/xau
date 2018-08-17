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
    public class IndexModel : PageModel
    {
        private readonly xau.Models.XauContext _context;

        public IndexModel(xau.Models.XauContext context)
        {
            _context = context;
        }

        #region Properties

        public IList<Entrega> Entrega { get; set; }
        public IList<Proveedor> Proveedor { get; set; }
        public IList<Recolector> Recolector { get; set; }

        public SelectList Proveedores { get; set; }
        public string FiltroProveedor { get; set; }

        #endregion Properties

        public async Task OnGetAsync(string filtroProveedor)
        {
            // Use LINQ to get the list of Proveedores
            IQueryable<string> proveedorQuery = from p in _context.Proveedor
                                                orderby p.Nombre
                                                select p.Nombre;
            // Populate the drop down list
            Proveedores = new SelectList(await proveedorQuery.Distinct().ToListAsync());

            // Define the queries
            var entregas = from ent in _context.Entrega
                           select ent;

            var proveedores = from prov in _context.Proveedor
                              select prov;

            var recolectores = from rec in _context.Recolector
                               select rec;

            // Populate the look-up tables
            Proveedor = await proveedores.ToListAsync();
            Recolector = await recolectores.ToListAsync();

            if (!String.IsNullOrEmpty(filtroProveedor))
            {
                entregas = entregas.Where(e => e.Proveedor.Nombre.Equals(filtroProveedor));
            }

            Entrega = await entregas.ToListAsync();
        }
    }
}
