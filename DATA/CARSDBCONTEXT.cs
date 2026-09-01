using CARS.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CARS.DATA
{
    public class CARSDBCONTEXT : DbContext
    {
        public CARSDBCONTEXT(DbContextOptions<CARSDBCONTEXT> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>().ToTable("Categoria", schema: "dbo");
            modelBuilder.Entity<Vehiculo>().ToTable("Vehiculo", schema: "dbo");
        }
    }
}