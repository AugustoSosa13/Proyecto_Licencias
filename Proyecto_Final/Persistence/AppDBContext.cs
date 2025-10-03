// Puente entre C# y SQL Server

using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Models.Entities;

namespace Proyecto_Final.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SubOficialLicencia> Licencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SubOficialLicencia>()
                .Property(l => l.OrdenDelDia)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
