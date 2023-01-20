namespace VMix.Data.Context
{
    public class VMixDbContext : DbContext
    {
        public VMixDbContext(DbContextOptions<VMixDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ConfigNavMenu> ConfigNavMenus { get; set; }
        public DbSet<Permission> Permissions { get; set; }
    }
}