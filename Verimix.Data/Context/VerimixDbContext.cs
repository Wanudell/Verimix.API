using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verimix.Data.Entities;

namespace Verimix.Data.Context
{
    public class VerimixDbContext : DbContext
    {
        public VerimixDbContext(DbContextOptions<VerimixDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}