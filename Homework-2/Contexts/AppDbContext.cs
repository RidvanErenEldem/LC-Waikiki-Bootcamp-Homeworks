using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Director> Directors { get; set; }

        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Director>().HasKey(p => p.Id);
            builder.Entity<Director>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Director>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Director>().Property(p => p.Birthday).HasColumnType("date");

            builder.Entity<Director>().HasData(
                new Director { Id = 1 , Name = "Christopher Nolan", Birthday = new DateTime(1970, 07,30)},
                new Director { Id = 2, Name = "Joe Russo", Birthday = new DateTime(1971,07,18)},
                new Director { Id = 3, Name = "George Lucas", Birthday = new DateTime(1944,05,14)}
            );

            builder.Entity<Movie>().HasKey(p => p.Id);
            builder.Entity<Movie>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Movie>().Property(p => p.Title).IsRequired().HasMaxLength(100);
            builder.Entity<Movie>().Property(p => p.Genre).HasMaxLength(20);
            builder.Entity<Movie>().Property(p => p.ReleaseDate).HasColumnType("date");
            
            builder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Avengers Endgame", Genre = "Super Hero", ReleaseDate = new DateTime(2019, 04, 26), DirectorId = 2, Rating = 8}
            );
        }
    }
}