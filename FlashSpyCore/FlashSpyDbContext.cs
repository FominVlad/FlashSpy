using FlashSpyCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlashSpyCore
{
    class FlashSpyDbContext : DbContext
    {
        public FlashSpyDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FlashSpy;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Level>().HasData(
                new List<Level> {
                    new Level { Id = 1, LevelName = "Error" },
                    new Level { Id = 2, LevelName = "Info" }
                });

            modelBuilder.Entity<Settings>().HasData(
                new List<Settings> {
                    new Settings { Id = 1, CopyFolder = @"C:\FlashSpy" }
                });
        }

        public DbSet<Level> Levels { get; set; }
        public DbSet<Settings> Settings { get; set; }
    }
}
