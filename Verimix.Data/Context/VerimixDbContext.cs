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