using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace xau.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new XauContext(
                serviceProvider.GetRequiredService<DbContextOptions<XauContext>>()))
            {
                // Check if the DB has been seeded
                if (context.Proveedor.Any())
                {
                    return; // DB has been seeded
                }

                // Seed the Proveedores
                context.Proveedor.AddRange(
                    new Proveedor { Nombre = "Proveedor A", Email = "provA@test.com", Telefono = "123456" },
                    new Proveedor { Nombre = "Proveedor B", Email = "provB@test.com", Telefono = "098765" },
                    new Proveedor { Nombre = "Proveedor C", Email = "provB@test.com", Telefono = "564738" }
                );
                context.SaveChanges();

                // Seed the Recolectores
                context.Recolector.AddRange(
                    new Recolector { Nombre = "Recolector Uno", Email = "Recol1@test.com", Telefono = "135791"},
                    new Recolector { Nombre = "Recolector Dos", Email = "Recol2@test.com", Telefono = "246802"},
                    new Recolector { Nombre = "Recolector Tres", Email = "Recol3@test.com", Telefono = "098765"}
                );
                context.SaveChanges();

                // Seed the Entregas
                context.Entrega.AddRange(
                    new Entrega { Fecha = DateTime.Now.AddDays(-2), Peso = 360, ProveedorID = 1, RecolectorID = 1 },
                    new Entrega { Fecha = DateTime.Now.AddDays(-1), Peso = 590, ProveedorID = 1, RecolectorID = 1 },
                    new Entrega { Fecha = DateTime.Now.AddDays(-2), Peso = 1200, ProveedorID = 2, RecolectorID = 1 },
                    new Entrega { Fecha = DateTime.Now.AddDays(-1), Peso = 630, ProveedorID = 2, RecolectorID = 1 },
                    new Entrega { Fecha = DateTime.Now, Peso = 450, ProveedorID = 3, RecolectorID = 2 }
                );
                context.SaveChanges();

            }
        }
    }
}
