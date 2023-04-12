using AdopetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdopetAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pet>()
                .HasOne(pet => pet.Pet_Responsavel)
                .WithOne()
                .HasForeignKey<Responsavel>(responsaveis => responsaveis.Resp_Id).IsRequired(false);

        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Responsavel> Responsavels { get; set; }
    }
}
