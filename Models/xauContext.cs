using System;
using Microsoft.EntityFrameworkCore;

namespace xau.Models
{
    public class XauContext : DbContext
    {
        public XauContext(DbContextOptions<XauContext> options) 
            : base(options)
        {
        }

        public DbSet<Entrega> Entrega { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Recolector> Recolector { get; set; }
    }
}