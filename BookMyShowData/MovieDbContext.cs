using BookMyShowEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BookMyShowData
{
    public class MovieDbContext:DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }
        public DbSet<Movie> movies { get; set; }
        public DbSet<Theatre> theatres { get; set; }
        public DbSet<ShowTiming> showTimings { get; set; } 
        public DbSet<User> users { get; set; }
        public DbSet<Booking> bookings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("Data Source=VDC01LTC2125;Initial Catalog=BookMyShowShowDb;Integrated Security=True;");
        }
    }
}
