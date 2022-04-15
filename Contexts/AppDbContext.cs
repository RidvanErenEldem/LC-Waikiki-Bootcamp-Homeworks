using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bootcamp_hw1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bootcamp_hw1.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<BootCamp> BootCamp{ get; set; }

        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BootCamp>().ToTable("DbBootCamp");
            builder.Entity<BootCamp>().HasKey(p => p.Id);
            builder.Entity<BootCamp>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<BootCamp>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<BootCamp>().Property(p => p.Description).HasMaxLength(50);

            builder.Entity<BootCamp>().HasData
            (
                new BootCamp { Id = 1, Name ="LC Waikiki", Description = ".NET Core Bootcamp"},
                new BootCamp { Id = 2, Name ="HP", Description = "Spring Boot Bootcamp"},
                new BootCamp { Id = 3, Name ="Patika.dev", Description = "C# Bootcamp"}
            );
        }
    }
}