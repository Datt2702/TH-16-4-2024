    using Microsoft.EntityFrameworkCore;
    using ThucHanhAPI.Models;

    namespace ThucHanhAPI.Data
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }

            public DbSet<Author> Authors { get; set; }
            public DbSet<Book> Books { get; set; }
            public DbSet<Publisher> Publisher { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
            {

            }
    }
}
//A man who doesn’t spend time with his family can never be a real man.
//Copyright by Duc Dat aka NoFallDamage