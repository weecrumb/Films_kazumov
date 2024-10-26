using Films_kazumov.Classes.Database;
using Films_kazumov.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Films_kazumov.Context
{
    public class FilmsContext : DbContext
    {
        public DbSet<Films> Films { get; set; }
        public FilmsContext()
        {
            Database.EnsureCreated();
            Films.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql(Config.connection, Config.version);
    }
}
