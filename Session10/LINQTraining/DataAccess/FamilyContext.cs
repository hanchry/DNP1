using System;
using Microsoft.EntityFrameworkCore;
using Models;

namespace LINQTraining.DataAccess
{
    public class FamilyContext : DbContext
    {
        // Defining various tables
        public DbSet<Family> Families { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\hanch\Desktop\school\Exercises\DNP\Session10\LINQTraining\Family.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Family>()
                .HasKey(fam => new {fam.StreetName, fam.HouseNumber});
        }
    }
}