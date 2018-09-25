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
                if (!context.Entrega.Any())
                {
                    // Seed the Proveedores
                    context.Proveedor.AddRange(
                        new Proveedor { Nombre = "Proveedor A", Email = "provA@test.com", Telefono = "123456" },
                        new Proveedor { Nombre = "Proveedor B", Email = "provB@test.com", Telefono = "098765" },
                        new Proveedor { Nombre = "Proveedor C", Email = "provB@test.com", Telefono = "564738" }
                    );
                    context.SaveChanges();
                }


                if (!context.Recolector.Any())
                {
                    // Seed the Recolectores
                    context.Recolector.AddRange(
                        new Recolector { Nombre = "Recolector Uno", Email = "Recol1@test.com", Telefono = "135791" },
                        new Recolector { Nombre = "Recolector Dos", Email = "Recol2@test.com", Telefono = "246802" },
                        new Recolector { Nombre = "Recolector Tres", Email = "Recol3@test.com", Telefono = "098765" }
                    );
                    context.SaveChanges();
                }

                if (!context.Entrega.Any())
                {
                    // Seed the Entregas
                    context.Entrega.AddRange(
                        new Entrega { Fecha = DateTime.Now.AddDays(-2), Peso = new decimal(601.3), LeyRecuperable = new decimal(921.26), ProveedorID = 4, RecolectorID = 4, status = EntregaStatus.pendiente, OwnerID = "51a76e6a-e9e3-44d7-ae20-adce78016de7" },
                        new Entrega { Fecha = DateTime.Now.AddDays(-1), Peso = new decimal(345.7), LeyRecuperable = new decimal(928.87), ProveedorID = 4, RecolectorID = 4, status = EntregaStatus.pendiente, OwnerID = "51a76e6a-e9e3-44d7-ae20-adce78016de7" },
                        new Entrega { Fecha = DateTime.Now.AddDays(-2), Peso = new decimal(155.4), LeyRecuperable = new decimal(919.6), ProveedorID = 5, RecolectorID = 4, status = EntregaStatus.pendiente, OwnerID = "51a76e6a-e9e3-44d7-ae20-adce78016de7" },
                        new Entrega { Fecha = DateTime.Now.AddDays(-1), Peso = new decimal(143.9), LeyRecuperable = new decimal(929), ProveedorID = 5, RecolectorID = 4, status = EntregaStatus.pendiente, OwnerID = "51a76e6a-e9e3-44d7-ae20-adce78016de7" },
                        new Entrega { Fecha = DateTime.Now, Peso = new decimal(502.3), LeyRecuperable = new decimal(913.7), ProveedorID = 6, RecolectorID = 4, status = EntregaStatus.pendiente, OwnerID = "51a76e6a-e9e3-44d7-ae20-adce78016de7" }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
