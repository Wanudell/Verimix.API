namespace VMix.Data.Context
{
    public class VMixDbContext : DbContext
    {
        public VMixDbContext(DbContextOptions<VMixDbContext> options) : base(options)
        {
        }

        public DbSet<AuthUser> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AuthRole> Roles { get; set; }
        public DbSet<ConfigNavMenu> ConfigNavMenus { get; set; }
        public DbSet<AuthPermission> Permissions { get; set; }
    }
}