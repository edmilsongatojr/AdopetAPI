using AdopetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdopetAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pet>();
            builder.Entity<Responsavel>();
            builder.Entity<Tutor>();
        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Responsavel> Responsaveis { get; set; }
        public DbSet<Tutor> Tutores { get; set; }
    }
}
