using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using GTA.Models;

namespace GTA
{
    public class GameContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<AnimalProperty> AnimalProperties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GTA;Trusted_Connection=True;");
            optionsBuilder.UseInMemoryDatabase("GTA");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalProperty>()
                .HasKey(bc => new { bc.AnimalId, bc.PropertyId });

            modelBuilder.Entity<AnimalProperty>()
                .HasOne(bc => bc.Animal)
                .WithMany(b => b.AnimalProperties)
                .HasForeignKey(bc => bc.AnimalId);

            modelBuilder.Entity<AnimalProperty>()
                .HasOne(bc => bc.Property)
                .WithMany(c => c.AnimalProperties)
                .HasForeignKey(bc => bc.PropertyId);
        }


        public void AddAnimals(params Animal[] animals)
        {
            Animals.AddRange(animals);
        }

        public void AddProperties(params Property[] props)
        {
            Properties.AddRange(props);
        }
    }
}
