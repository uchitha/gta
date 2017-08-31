using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace GTA
{
    public class GameContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalProperty> AnimalPropertieses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GTA;Trusted_Connection=True;");
            optionsBuilder.UseInMemoryDatabase("GTA");
        }

        public void AddAnimals(params Animal[] animals)
        {
            Animals.AddRange(animals);
        }
    }
}
