using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using xau.Models;

namespace xau.Pages.Entregas
{
    public class CreateModel : PageModel
    {
        private readonly xau.Models.XauContext _context;

        public SelectList Proveedores { get; set; }
        public Proveedor ProveedorSeleccionado { get; set; }
        public DateTime FechaEntrega { get; set; }

        public CreateModel(xau.Models.XauContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // Get the list of Proveedores
            var proveedores = from prov in _context.Proveedor select prov;

            // Populate the drop down list
            Proveedores = new SelectList(proveedores, "ID", "Nombre");

            FechaEntrega = DateTime.Now;

            // Get the logged in user and set it as the RecolectorActivo
            //RecolectorActivo = recolectores.FirstOrDefault(r => r.Email == HttpContext.User.Identity.Name);

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

            // Get list of Recolectores
            var recolectores = from reco in _context.Recolector select reco;

            // Set the value for the Owner and Recolector IDs
            Entrega.OwnerID = User.Claims.FirstOrDefault(c => true).Value;
            Entrega.RecolectorID = recolectores.FirstOrDefault(r => r.Email == HttpContext.User.Identity.Name).ID;
            Entrega.Fecha = FechaEntrega;

            _context.Entrega.Add(Entrega);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}