using Domain.Entities;
using Infra.Persistence.Configure;
using Microsoft.EntityFrameworkCore;

namespace Infra.Persistence
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\MSSQLSERVER01;Database=Test; Integrated Security=True")
                .EnableDetailedErrors();
        }
        
        public DbSet<Conta> Conta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ContasBD");

            modelBuilder.ApplyConfiguration(new  ContaConfigure());
        }
    }
    
}
