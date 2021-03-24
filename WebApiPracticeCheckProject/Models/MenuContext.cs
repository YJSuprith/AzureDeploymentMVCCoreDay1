using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPracticeCheckProject.Models
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<MenuItem> menuItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>().HasData(new MenuItem()
            {
                MenuId = 101,
                MenuName = "Watch"
            });
        }
    }
}
