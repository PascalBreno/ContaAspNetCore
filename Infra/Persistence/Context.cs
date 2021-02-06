using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Persistence
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test")
                .EnableDetailedErrors();
        }
        
        public DbSet<Conta> Conta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ContasBD");
            
            modelBuilder.Entity<Conta>()
                .HasKey(x => x.ContaId);
        }
    }
    
}
