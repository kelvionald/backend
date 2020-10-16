using lab7.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace lab7.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Bike> Bikes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = ./storage/db.db");
        }
    }
}