using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TiendaCarnes.Entidades;

namespace TiendaCarnes
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TiendaProductoProvedoores>().HasKey(al => new { al.TiendaId, al.ProductodeProvedooresId });
        }

        public DbSet<ProductodeProvedoores> ProductodeProvedoores { get; set; }
        public DbSet<Tienda> Tienda { get; set; }
        public DbSet<TiendaProductoProvedoores> TiendaProductoProvedoores { get; set; }
    }
}
