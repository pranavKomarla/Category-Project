using System;
using Microsoft.EntityFrameworkCore;
using TheFirst.Models;

namespace TheFirst.Controllers.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}



